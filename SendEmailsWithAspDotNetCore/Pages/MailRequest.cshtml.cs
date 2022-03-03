using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendEmailsWithAspDotNetCore.Models;

namespace SendEmailsWithAspDotNetCore.Pages
{
    public class MailRequestModel : PageModel
    {
        private readonly ILogger<MailRequestModel> _logger;
        private readonly IMailService mailService;
        public MailRequestModel(ILogger<MailRequestModel> logger, IMailService mailService)
        {
            _logger = logger;
            this.mailService = mailService;
        }

        public void OnGet()
        {

        }
        public MailRequest MailRequest { get; set; }
        public async Task<IActionResult> OnPost([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}