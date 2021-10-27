using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using Poker.Domain;

namespace pokerApp.Controllers {
    [ApiController]
    [Route("[controller]")]

    public class StartNewRoundController : ControllerBase {
        [HttpGet]
        public CommunityCards GetCommunityCards() {
            var deckSessionObject = HttpContext.Session.GetObjectFromJson<IList<Card>>("deck");
            Deck deck = new Deck(deckSessionObject);
            var communityCardsObject = HttpContext.Session.GetObjectFromJson<IList<Card>>("communityCards");
            CommunityCards communityCards = new CommunityCards(communityCardsObject);
            
            communityCards.RecieveCard(deck.GetTopCardFromDeck());
            deck.RemoveTopCardFromDeck();

            HttpContext.Session.SetObjectAsJson("deck", deck.deck.ToList());
            HttpContext.Session.SetObjectAsJson("communityCards", communityCards.communityCards);
            return communityCards;
        }
    }
}