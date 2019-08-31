using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTravel.Common
{
    public class EmailAction
    {
        private static BookingEntities db = new BookingEntities();
        public static string SendMail(string Email, string code)
        {
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
            m.From = new System.Net.Mail.MailAddress("xuanhung3296@gmail.com");
            m.To.Add(Email);
            m.Subject = "Email confirmation";
            m.Body = string.Format("<BR/> Cảm ơn bạn đã đến với trang TopTravel.com.vn . Hãy nhập mã sau đây để thực hiện đăng ký tour: <BR/>{0}" ,code);
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("xuanhung3296@gmail.com", "03021996");
            smtp.EnableSsl = true;
            smtp.Send(m);
            return "Success" ;
        }


        public static string SendMailPaymentCode(string Email, string id, string code)
        {
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
            m.From = new System.Net.Mail.MailAddress("xuanhung3296@gmail.com");
            m.To.Add(Email);
            m.Subject = "Email confirmation";
            var newID = Convert.ToInt32(id);
            var tour = db.Tours.FirstOrDefault(u => u.TourID.Equals(newID));
            m.Body = string.Format("<BR/> Cảm ơn bạn đã đến với trang TopTravel.com.vn .<BR/> Bạn đã book tour {1} thành công, xin hãy mang mã code sau đến các cơ sở để thanh toán hoặc chuyển khoản theo hướng dẫn: <BR/>{0}", code,tour.TourName);
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("xuanhung3296@gmail.com", "03021996");
            smtp.EnableSsl = true;
            smtp.Send(m);
            return "Success";
        }
    }
}