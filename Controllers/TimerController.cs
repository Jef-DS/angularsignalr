using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularsignalr.DataStorage;
using angularsignalr.HubConfig;
using angularsignalr.TimerFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace angularsignalr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerController : ControllerBase
    {
        private readonly IHubContext<TimerHub> _hub;
        public TimerController(IHubContext<TimerHub> hub)
        {
            this._hub = hub; 
        }
        public IActionResult Get()
        {
            var timerManager = new TimerManager(() =>
               _hub.Clients.All.SendAsync("transfertime", DataManager.GetTime()));
            return Ok(new { Message = " Request completed" });
        }
    }
}
