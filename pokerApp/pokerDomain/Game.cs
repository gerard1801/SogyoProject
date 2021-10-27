using System;

namespace Poker.Domain {
    public class Game {

        private CommunityCards communityCards;
        private Deck deck;
        public Game() {
            this.communityCards = new CommunityCards();
            this.deck = new Deck();
        }
    }


}