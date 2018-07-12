using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using GetSlackMailAPI.Services;
//using Microsoft.AspNetCore.Mvc;
//using GetSlackMailAPI.WebLogic;


//namespace GetSlackMailAPI.Controllers
//{
//    [Route("debug/index")]
//    public class DebugController : Controller
//    {
//        private ITokenProvider _tokenProvider;
//        private IMailBot _mailBot;
//        private IWebClient _webClient;

//        public DebugController(ITokenProvider tokenProvider, IMailBot mailbot, IWebClient webclient)
//        {
//            _tokenProvider = tokenProvider;
//            _mailBot = mailbot;
//            _webClient = webclient;
//        }
//        public void Index(string channel_id, string user_id)
//        {

//            _mailBot.Run(channel_id, user_id);

//        }
//    }
//}