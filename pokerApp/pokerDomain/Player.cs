using System;
using System.Collections.Generic;

namespace Poker.Domain {
    public class Player {
        public string name; 
        public Hand hand;
        
        public Player(string playerName) 
        {
            this.name = playerName;  
            this.hand = new Hand();

        }
        public string GetPlayerName() 
        {
            return this.name;
        }
    }
}