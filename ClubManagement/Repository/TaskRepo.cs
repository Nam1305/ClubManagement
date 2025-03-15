using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TaskRepository
    {
        private readonly ClubManagementContext _context;

        public TaskRepository()
        {
            _context = new ClubManagementContext();
        }

        public List<ClubTask> GetTasksByGroupId(int groupId)
        {
            return _context.ClubTasks
                .Include(t => t.AssignedToNavigation) // Sửa từ AssignedTo thành AssignedToNavigation
                .Where(t => t.GroupId == groupId)
                .ToList();
        }

        public void CreateTask(ClubTask task)
        {
            if (CurrentUser.RoleId != 3)
                throw new UnauthorizedAccessException("Only Vice Chairman can create tasks for groups.");

            if (CurrentUser.ClubId != task.ClubId)
                throw new UnauthorizedAccessException("You can only create tasks for your current club.");

            task.AssignedBy = CurrentUser.UserId;
            task.Status = "pending";

            try
            {
                _context.ClubTasks.Add(task);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Ghi log chi tiết lỗi
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                System.Diagnostics.Debug.WriteLine($"Lỗi khi tạo task: {errorMessage}");
                throw new Exception($"Lỗi khi tạo task: {errorMessage}", ex);
            }
        }

        public void UpdateTask(ClubTask task)
        {
            var existingTask = _context.ClubTasks.FirstOrDefault(t => t.TaskId == task.TaskId);
            if (existingTask == null)
                throw new Exception("Task not found.");

            if (CurrentUser.RoleId == 3) // Vice Chairman cập nhật thông tin chung
            {
                existingTask.TaskName = task.TaskName;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.GroupId = task.GroupId;
            }
            else if (CurrentUser.RoleId == 4) // Leader gán thành viên cụ thể
            {
                var group = _context.Groups.FirstOrDefault(g => g.GroupId == existingTask.GroupId);
                if (group?.LeaderId != CurrentUser.UserId)
                    throw new UnauthorizedAccessException("Only the group leader can assign tasks to members.");

                existingTask.AssignedTo = task.AssignedTo;
                existingTask.Status = task.Status; // Leader cập nhật trạng thái
            }
            else
            {
                throw new UnauthorizedAccessException("Unauthorized to update this task.");
            }

            try
            {
                _context.ClubTasks.Update(existingTask);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                System.Diagnostics.Debug.WriteLine($"Lỗi khi cập nhật task: {errorMessage}");
                throw new Exception($"Lỗi khi cập nhật task: {errorMessage}", ex);
            }
        }
    }
}