using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Poker.Domain;
using System.Web;
using Newtonsoft.Json; 

namespace pokerApp.Controllers {
    [ApiController]
    [Route("[controller]")]

    public class GetNewShuffledDeckController : ControllerBase {
        [HttpGet]
        public Deck SetDeckInSession() {
            Deck deck = new Deck();
            //deck.ShuffleDeck();
            HttpContext.Session.SetObjectAsJson("deck", deck.deck.ToList());
            CommunityCards communityCards = new CommunityCards();
            HttpContext.Session.SetObjectAsJson("communityCards", communityCards.communityCards);
            return deck;
        }
    }
    public static class SessionExtensions {
        public static void SetObjectAsJson(this ISession session, string key, object value) 
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key) 
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}