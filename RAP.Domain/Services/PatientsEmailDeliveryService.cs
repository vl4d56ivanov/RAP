using Microsoft.AspNet.Identity;
using RAP.Domain.Entities;
using RAP.Domain.Identity;
using RAP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RAP.Domain.Services
{
    class PatientsEmailDeliveryService : IEmailDeliveryService
    {
        private readonly IEnumerable<Patient> _patients;
        private readonly string baseText;
        private readonly EmailService emailService;
        private readonly IdentityMessage message; 

        public PatientsEmailDeliveryService(IEnumerable<Patient> patients, string text)
        {
            _patients = patients;
            baseText = text;
            emailService = new EmailService();
            message = new IdentityMessage();
        }

        public void MakeDeliveryToMail()
        {
            foreach (var item in _patients)
            {
                //message.Destination = item.Email;
                message.Subject = GetMessageSubject();
                message.Body = GetMessageBody(item);

                emailService.SendAsync(message);
            }
        }

        private string GetMessageBody(Patient patient)
        {
            StringBuilder messBuilder = new StringBuilder();
            messBuilder.AppendLine($"Dear Ms./Mrs {patient.FName} {patient.LName}!");
            messBuilder.AppendLine(baseText);
            messBuilder.AppendLine("With regards, RAP.");

            return messBuilder.ToString();
        }

        private string GetMessageSubject()
        {
            return $"RAP email delivery from {DateTime.Now.ToShortDateString()}";
        }
    }
}
