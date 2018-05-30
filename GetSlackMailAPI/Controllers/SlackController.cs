using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetSlackMailAPI.Services;
using Microsoft.AspNetCore.Mvc;
using GetSlackMailAPI.WebLogic;


namespace GetSlackMailAPI.Controllers
{
    [Route("slack/index")]
    public class SlackController : Controller
    {
        private ITokenProvider _tokenProvider;
        private IMailBot _mailBot;
        private IWebClient _webClient;

        public SlackController(ITokenProvider tokenProvider,IMailBot mailbot, IWebClient webclient )
        {
            _tokenProvider = tokenProvider;
            _mailBot = mailbot;
            _webClient = webclient;
        }
        [HttpPost]
        public void Index()
        {


            string postVerificationToken = Request.Form["token"];
            if(postVerificationToken == _tokenProvider.GetVerificationToken())
            {
                string channelID = Request.Form["channel_id"];
                string requesterID = Request.Form["user_id"];
                _mailBot.Run(channelID, requesterID);
            }
            
        }
    }
}