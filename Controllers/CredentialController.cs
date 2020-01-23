using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using routine_explorer.Data;
using routine_explorer.Models;

namespace routine_explorer.Controllers
{
    public class CredentialController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<IdentityUser> _authToken;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CredentialController(DatabaseContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _authToken = userManager;
            _signInManager = signInManager;
        }
        
        [HttpPost]
        public async Task<JsonResult> Initiation([FromBody]Credential credential)
        {
            if (!ModelState.IsValid)
                return Json(ModelState.Values.SelectMany(v => v.Errors));

            try
            {
                await _authToken.CreateAsync(
                    new IdentityUser
                    {
                        Id = credential.CredentialId,
                        UserName = credential.CredentialUser,
                        Email = credential.CredentialEmail,
                        PhoneNumber = credential.PhoneNumber
                    }, 
                credential.CredentialKey);

                return Json(new PostLog
                {
                    Message = "Credential verified",
                    HasError = false,
                    TimeStamp = DateTime.Now
                });
            }
            catch (Exception e)
            {
                return Json(new PostLog
                {
                    Message = e.Message,
                    HasError = true,
                    TimeStamp = DateTime.Now
                });
            }
        }
    }
}