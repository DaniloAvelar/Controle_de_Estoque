using Controle_de_Estoque.Models;
using Controle_de_Estoque.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Controllers
{
    public class TesteEmailController : Controller
    {
        private readonly IEmailSender _emailSender;
        public TesteEmailController(IEmailSender emailSender, IHostingEnvironment env)
        {
            _emailSender = emailSender;
        }

        public IActionResult EnviaEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnviaEmail(EmailModel email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.Destino, email.Assunto, email.Solicitante, email.Mensagem).GetAwaiter();
                    return RedirectToAction("EmailEnviado");
                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }
            return View(email);
        }
        public async Task TesteEnvioEmail(string email, string assunto, string solicitante, string mensagem)
        {
            try
            {
                //email destino, assunto do email, mensagem a enviar
                await _emailSender.SendEmailAsync(email, assunto, solicitante, mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult EmailEnviado()
        {
            return View();
        }
        public ActionResult EmailFalhou()
        {
            return View();
        }
    }
}
