using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Services
{
    public class PasswordResetService
    {
        UserRepo repo;
        public PasswordResetService()
        {
            repo = new UserRepo();
        }
        public bool ResetPassword(string email)
        {
            try
            {
                string tempPassword = repo.ResetPassword(email);
                if (tempPassword == null)
                {
                    return false;
                }

                SendResetEmail(email, tempPassword);
                return true;
            }
            catch (Exception ex)
            {
                // Có thể thêm logging ở đây nếu cần
                Console.WriteLine($"Error resetting password: {ex.Message}");
                return false;
            }
        }

        private void SendResetEmail(string email, string tempPassword)
        {
            var fromAddress = new MailAddress("anhdai317392@gmail.com", "Club Management");
            var toAddress = new MailAddress(email);
            const string fromPassword = "enrx bvrf lbse umev";
            const string subject = "Password Reset Request";
            string body = $"Your temporary password is: {tempPassword}\n" +
                          "Please login and change your password immediately.\n" +
                          "This password will expire in 24 hours.";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}

