using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTutor.Utility
{
    //Author: João Dâmaso
    //Purpose: This class is used to send emails

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Lógica para enviar email
            return Task.CompletedTask;
        }
    }
}
