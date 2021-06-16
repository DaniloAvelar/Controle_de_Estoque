using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string solicitante, string message, string idproduto);
    }
}
