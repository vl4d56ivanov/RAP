using RAP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Domain.Interfaces
{
    public interface IEmailDeliveryService
    {
        Task MakeDeliveryToMail(IEnumerable<Patient> patients, string text);
    }
}
