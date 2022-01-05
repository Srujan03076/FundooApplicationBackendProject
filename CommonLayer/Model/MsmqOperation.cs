using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Experimental.System.Messaging;

namespace CommonLayer.Model
{
    public class MsmqOperation
    {
        MessageQueue msmq = new MessageQueue();
        public void Sender(string token)
        {

            msmq.Path = @".\private$\Tokens";
            if (!MessageQueue.Exists(msmq.Path))
            {
                MessageQueue.Create(msmq.Path);
            }
            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            msmq.ReceiveCompleted += Msmq_ReceiveCompleted;
            msmq.Send(token);
            msmq.BeginReceive();
            msmq.Close();
        }

        private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = msmq.EndReceive(e.AsyncResult);
            string token = msg.Body.ToString();
            // mail sending code smtp 
            string mailReceiver = JwtDecode(token).ToString();
            MailMessage message = new MailMessage("srujantesting123@gmail.com", mailReceiver);
            string bodymessage = "for reset click here <a href='https://localhost:44320/api/User/GetAllUserdetails'> click me</a>" +
                "copy the token Provided here : " + token;


            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = bodymessage;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("srujantesting123@gmail.com", "srujan@03");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }
           catch (Exception ex)
            {
                throw ex;
            }

            // msmq receiver
            msmq.BeginReceive();
        }
        public static string JwtDecode(string token)
        {
            var jwtDecode = token;
            var handler = new JwtSecurityTokenHandler();
            var decoded = handler.ReadJwtToken((jwtDecode));
            var result = decoded.Claims.FirstOrDefault().Value;
            return result;
        }
    }
}


        
       



            

           
           



   
                
               
                //msmq.BeginReceive();
        


   









   



