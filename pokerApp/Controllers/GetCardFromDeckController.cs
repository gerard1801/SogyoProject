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

    [HttpGet]
    public Card GetTopCard() {
        var obj = HttpContext.Session.GetObjectFromJson<IList<Card>>("deck");
        Deck deck = new Deck(obj);
        Card topCard = deck.GetTopCardFromDeck();
        deck.RemoveTopCardFromDeck();

        HttpContext.Session.SetObjectAsJson("deck", deck.deck.ToList());

        return topCard;
    }
    }
}