using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendEmailsWithAspDotNetCore.Models;

namespace SendEmailsWithAspDotNetCore.Pages
{
    public class WelcomeRequestModel : PageModel
    {
        private readonly ILogger<WelcomeRequestModel> _logger;
        private readonly IMailService mailService;
        public WelcomeRequestModel(ILogger<WelcomeRequestModel> logger, IMailService mailService)
        {
            _logger = logger;
            this.mailService = mailService;
        }

        public void OnGet()
        {

        }
        public WelcomeRequest WelcomeRequest { get; set; }
        public async Task<IActionResult> OnPost([FromForm] WelcomeRequest welcomeRequest)
        {
            try
            {
                await mailService.SendWelcomeEmailAsync(welcomeRequest);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}