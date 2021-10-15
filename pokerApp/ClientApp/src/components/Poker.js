import React, { Component } from "react";

export class Poker extends Component{
    async getCardFromDeck() {
        console.log("klik");
        try {
            const response = await fetch('http://localhost:5000/GetTopCardFromDeck/getcard', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
            if (response.ok) {
                const topCard = await response.json();
                console.log(topCard);
                //const topCardSuit = topCard["topCardFromDeck"]["suit"];
                //const topCardRank = topCard["topCardFromDeck"]["rank"];
                //console.log(topCardSuit);
                //console.log(topCardRank);
            } else {
                console.error(response.statusText);
            }
        } catch (error) {
            console.error(error.toString());
        }
    }

    render() {
        return (
            <div>
                <h2>Poker</h2>
                <p>
                    Poker imp
                </p>
                <button onClick={() => this.getCardFromDeck()}>kaart</button>
            </div>
        )
    }
}