using System;
using System.Collections.Generic;
using System.Linq;
using ClubManagement;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TaskRepo
    {
        private readonly ClubManagementContext _context;

        public TaskRepo()
        {
            _context = new ClubManagementContext();
        }

        public List<ClubTask> GetTasksByGroupId(int groupId)
        {
            try
            {
                return _context.ClubTasks
                    .Include(t => t.AssignedToNavigation)
                    .Where(t => t.GroupId == groupId)
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetTasksByGroupId: {ex.Message}");
                throw;
            }
        }

        public void CreateTask(ClubTask task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            if (CurrentUser.RoleId != 3 && CurrentUser.RoleId != 4)
                throw new UnauthorizedAccessException("Only Vice Chairman or Group Leader can create tasks for groups.");

            if (CurrentUser.ClubId != task.ClubId)
                throw new UnauthorizedAccessException("You can only create tasks for your current club.");

            if (CurrentUser.RoleId == 4)
            {
                var group = _context.Groups.FirstOrDefault(g => g.GroupId == task.GroupId);
                if (group == null || group.LeaderId != CurrentUser.UserId)
                    throw new UnauthorizedAccessException("You can only create tasks for groups where you are the leader.");
            }

            task.AssignedBy = CurrentUser.UserId;
            task.Status = task.Status ?? "pending";

            try
            {
                _context.ClubTasks.Add(task);
                int rowsAffected = _context.SaveChanges();
                System.Diagnostics.Debug.WriteLine($"Task created, rows affected: {rowsAffected}");
            }
            catch (DbUpdateException ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                System.Diagnostics.Debug.WriteLine($"Database error in CreateTask: {errorMessage}");
                throw new Exception($"Database error while creating task: {errorMessage}", ex);
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
                existingTask.Status = task.Status;
            }
            else
            {
                throw new UnauthorizedAccessException("Unauthorized to update this task.");
            }

            try
            {
                _context.ClubTasks.Update(existingTask);
                int rowsAffected = _context.SaveChanges();
                System.Diagnostics.Debug.WriteLine($"Task updated, rows affected: {rowsAffected}");
            }
            catch (DbUpdateException ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                System.Diagnostics.Debug.WriteLine($"Database error in UpdateTask: {errorMessage}");
                throw new Exception($"Database error while updating task: {errorMessage}", ex);
            }
        }
    }
}