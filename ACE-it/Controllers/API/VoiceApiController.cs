using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ACE_it.Controllers.API
{
    public class VoiceApiController : Controller
    {
        [Route("API/Voice")]
        public ObjectResult Parse(string voice, int sessionId)
        {
            var action = "";

            if (voice.ToLower().Contains("next"))
            {
                action = "redirect,/SessionRecipe/Update?sessionId=" + sessionId;
            }

            return Ok(action);
        }
    }
}
