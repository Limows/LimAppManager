using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
 
namespace LimAppServer
{
    class MailHelper
    {
        public static async Task SendEmailAsync()
        { 
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("somemail@gmail.com", "Limows");
            // кому отправляем
            MailAddress to = new MailAddress("somemail@yandex.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}