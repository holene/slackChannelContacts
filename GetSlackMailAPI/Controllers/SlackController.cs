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

        public void Index()
        {
            string channelID = "C0X725W2G";
            string requesterID = "U93STPZ2L";

            _mailBot.Run(channelID, requesterID);
            //return Content();
        }
    }
}