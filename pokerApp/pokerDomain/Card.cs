using System;

namespace Poker.Domain {

    public enum Suits {
        CLUBS, DIAMONDS, HEARTS, SPADES
    }

    public enum Ranks {
        TWO=2, THREE=3, FOUR=4, FIVE=5, SIX=6, SEVEN=7,
        EIGHT=8, NINE=9, TEN=10, JACK=11, QUEEN=12, KING=13, ACE=14
    }
    public class Card {
        public Suits suit { get; private set; }
        public Ranks rank { get; private set; }

        public Card(Suits suit, Ranks rank) 
        {
            this.suit = suit;
            this.rank = rank;
        }

        public Suits GetSuitValue() {
            return this.suit;
        }
        public int GetRankValue() {
            return (int) this.rank;
        }
        public String CompareCards(Card Card1, Card Card2) {
            if (Card1.rank > Card2.rank) {
                return "First";
            } else if (Card1.rank < Card2.rank) {
                return "Second";
            } else {
                return "Equal";
            }
        }
    }
}
