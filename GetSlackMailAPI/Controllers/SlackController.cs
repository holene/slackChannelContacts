using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetSlackMailAPI.Services;
using Microsoft.AspNetCore.Mvc;
using GetEmailSlackBot.WebLogic;


namespace GetSlackMailAPI.Controllers
{
    [Route("slack/index")]
    public class SlackController : Controller
    {
        private ITokenProvider _tokenProvider;

        public SlackController(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider; 
        }

        public IActionResult Index()
        {
            //return Content(_tokenProvider.GetToken());
        }
    }
}