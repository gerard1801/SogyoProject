using System;

namespace Poker.Domain {

    public enum Suits {
        CLUBS, DIAMONDS, HEARTS, SPADES
    }

    public enum Ranks {
        ACE=1, TWO=2, THREE=3, FOUR=4, FIVE=5, SIX=6, SEVEN=7,
        EIGHT=8, NINE=9, TEN=10, JACK=11, QUEEN=12, KING=13
    }
    public class Card {
        public Suits GetSuit { get; }
        public Ranks GetRank { get; }

        public Card(Suits suit, Ranks rank) {
            this.GetSuit = suit;
            this.GetRank = rank;
        }

        public Suits getSuitValue() {
            return this.GetSuit;
        }
        public int getRankValue() {
            return (int) this.GetRank;
        }
    }
}
