using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClubRepo
    {
        private readonly ClubManagementContext context;
        public ClubRepo()
        {
            context = new ClubManagementContext();
        }
        public List<Club> GetAllClub()
        {
            return context.Clubs
                .Include(c => c.UserClubs)
                .ThenInclude(uc => uc.User)
                .ToList();
        }

        public List<Club> SearchClubByName(string clubName) 
        {
            return context.Clubs.Where(c => c.ClubName.Contains(clubName)).ToList();
        }

        public bool AddNewClub(Club club)
        {
            try
            {
                context.Clubs.Add(club);
                return context.SaveChanges() > 0; // Trả về true nếu có ít nhất 1 bản ghi được thêm
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateClub(Club club)
        {
            try
            {
                var existingClub = context.Clubs.FirstOrDefault(c => c.ClubId == club.ClubId);
                if (existingClub == null)
                {
                    return false; // Không tìm thấy user để cập nhật
                }
                existingClub.ClubName = club.ClubName;
                existingClub.Description = club.Description;
                existingClub.EstablishedDate = club.EstablishedDate;
                existingClub.Status = club.Status;

                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteClub(int clubId)
        {
            try
            {
                var deleteClub = GetAllClub().Where(club => club.ClubId == clubId).FirstOrDefault();
                context.Remove(deleteClub);
                return context.SaveChanges() > 0; // Trả về true nếu có ít nhất 1 bản ghi được update
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
