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
    public class GetCardFromDeckController : ControllerBase {
        
        //Card test = deck.getTopCardFromDeck();
        

    [HttpGet]
    public Card GetTopCard() {
        Deck deck = new Deck();
        Card TopCard = deck.GetTopCardFromDeck();
        deck.RemoveTopCardFromDeck();
        Console.WriteLine(TopCard);

        return TopCard;
    }
    }
}