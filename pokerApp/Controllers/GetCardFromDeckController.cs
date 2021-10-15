using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace pokerApp.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class GetTopCardFromDeckController : ControllerBase {
        //


    [HttpGet]
    public string getcard() {
        return "test";
    }
    }
}