using Microsoft.AspNet.Identity;
using RAP.Domain.Entities;
using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Domain.Services
{
    class PatientsEmailDeliveryService : IEmailDeliveryService
    {
        private readonly EmailService emailService;
        private readonly IdentityMessage message; 

        public PatientsEmailDeliveryService()
        {
            emailService = new EmailService();
            message = new IdentityMessage();
        }

        public async Task MakeDeliveryToMail(IEnumerable<Patient> patients, string text)
        {
            foreach (var item in patients)
            {
                message.Destination = item.Email;
                message.Subject = GetMessageSubject();
                message.Body = GetMessageBody(item, text);

                await emailService.SendAsync(message);
            }
        }

        private string GetMessageBody(Patient patient, string text)
        {
            StringBuilder messBuilder = new StringBuilder();
            messBuilder.AppendLine($"Dear Mr./Ms. {patient.FName} {patient.LName}!");
            messBuilder.AppendLine(text);
            messBuilder.AppendLine("With regards, RAP.");

            return messBuilder.ToString();
        }

        private string GetMessageSubject()
        {
            return $"RAP email delivery from {DateTime.Now.ToShortDateString()}";
        }
    }
}
