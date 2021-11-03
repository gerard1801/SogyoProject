using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poker.Domain;

namespace pokerApp.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class getHandStrengthController : ControllerBase {

        [HttpGet]
        public void getHandStrength() {
            Game game = new Game();

        }
    }
}