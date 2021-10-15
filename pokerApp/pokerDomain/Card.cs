using System;

namespace poker {

    public enum Suits {
        CLUBS, DIAMONS, HEARTS, SPADES
    }

    public enum Ranks {
        ACE=1, TWO=2, THREE=3, FOUR=4, FIVE=5, SIX=6, SEVEN=7,
        EIGHT=8, NINE=9, TEN=10, JACK=11, QUEEN=12, KING=13
    }
    public class Card {
        private Suits suit;
        private Ranks rank;

        public Card(Suits suit, Ranks rank) {
            this.suit = suit;
            this.rank = rank;
        }

        public Suits getSuit() {
            return this.suit;
        }

        public Ranks getRank() {
            return this.rank;
        }

        public int getRankValue() {
            return (int) this.rank;
        }
    }
}
