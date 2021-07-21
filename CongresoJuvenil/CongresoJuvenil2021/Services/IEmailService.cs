using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenil2021.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = "");
    }
}
