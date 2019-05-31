using System.Threading.Tasks;
using ACE_it.Data;
using Microsoft.AspNetCore.Mvc;

namespace ACE_it.Controllers.API
{
    public class VoiceApiController : Controller
    {
        [Route("API/Voice")]
        public ObjectResult Parse(string voice, int sessionId, int viewIndex)
        {
            var action = "";
            var s = voice.ToLower();

            if (s.Contains("next"))
            {
                action = "redirect,/SessionRecipe/Update?sessionId=" + sessionId;
            } else if (s.Contains("previous") && viewIndex > 0)
            {
                action = "redirect,/SessionRecipe/Show?sessionId=" + sessionId + "&viewIndex=" + (viewIndex-1);
            }

            return Ok(action);
        }
    }
}
