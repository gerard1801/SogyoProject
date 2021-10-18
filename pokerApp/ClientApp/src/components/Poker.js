import React, { Component } from "react";

const Emoji = props => (
    <span
        className="emoji"
        role="img"
        aria-label={props.label ? props.label : ""}
        aria-hidden={props.label ? "false" : "true"}
        >
            {props.symbol}
        </span>
);

function AddEmojiToHTMLDiv(Suit, Rank) {
    console.log(Rank);
    console.log(Suit);
    if (Suit === 3) {
        
        //const rootElement = document.getElementById('CardDiv');
        //const element = (<Emoji symbol="♦️" label="Diamond"/>);
        //rootElement.appendChild(element);
    }
}

export default Emoji;

export class Poker extends Component{
    async getCardFromDeck() {
        try {
            const response = await fetch('GetCardFromDeck', {
                method: 'GET',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
            if (response.ok) {
                const topCard = await response.json();
                const topCardSuit = topCard["getSuit"];
                const topCardRank = topCard["getRank"];
                AddEmojiToHTMLDiv(topCardSuit, topCardRank);
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
                <div id="CardDiv">
                    <Emoji symbol="♣️" label="Club"/>
                    <Emoji symbol="♦️" label="Diamond"/>
                    <Emoji symbol="♠️" label="Spade"/>
                    <Emoji symbol="♥️" label="Heart"/>
                </div>
                
            </div>
        )
    }
}