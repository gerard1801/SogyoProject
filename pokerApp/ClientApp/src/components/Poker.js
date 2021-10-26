import React, { Component, useState } from "react";


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

export default Emoji;

export class Poker extends Component{

    constructor(props) {
        super(props);
        this.state = {
            cards: [],
        };
    }

    addCardToState = (topCardSuit, topCardRank) => {
        const newState = [...this.state.cards];
        if (newState.length > 0) {
            var newIndex = newState[newState.length-1].id;
        } else {
            var newIndex = 0;
        }
        if (topCardSuit === 0) {
            newState.push({cardRanks: topCardRank, cardSuitsSymbol: "♣️", cardSuitsLabel: "clubs", id: newIndex+1})
        }
        if (topCardSuit === 1) {
            newState.push({cardRanks: topCardRank, cardSuitsSymbol: "♦️", cardSuitsLabel: "diamonds", id: newIndex+1})
        }
        if (topCardSuit === 2) {
            newState.push({cardRanks: topCardRank, cardSuitsSymbol: "♥️", cardSuitsLabel: "hearts", id: newIndex+1})
        }
        if (topCardSuit === 3) {
            newState.push({cardRanks: topCardRank, cardSuitsSymbol: "♠️", cardSuitsLabel: "spades", id: newIndex+1})
        }
        this.setState({cards: newState})
    }

    render() {
        return (
            <div>
                <h2>Poker</h2>
                <p>
                    Poker imp
                </p>
                <button onClick={() => this.getCardFromDeck()}>kaart</button>
                <button onClick={() => this.GetNewShuffledDeck()}>deck laden</button>
                <div id="CardDiv">
                    {this.state.cards.map(cards => (
                        <div key={cards.id}> 
                            <label>{cards.cardRanks}</label>
                            <Emoji symbol={cards.cardSuitsSymbol} label={cards.cardSuitsLabel}/>
                        </div>
                    ))}
                </div>
            </div>
        )
    }

    async GetNewShuffledDeck() {
        try {
            const response = await fetch('GetNewShuffledDeck', {
                method: 'GET',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
            if (response.ok) {
                const deck = await response.json();
            } else {
                console.error(response.statusText);
            }
        } catch (error) {
            console.error(error.toString());
        }
    }

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
                console.log(topCard)
                this.addCardToState(topCard["suit"], topCard["rank"])
            } else {
                console.error(response.statusText);
            }
        } catch (error) {
            console.error(error.toString());
        }
    }
}