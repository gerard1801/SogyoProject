import React, { Component, useState } from "react";
import './Poker.css';

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

//export default Emoji;

function Poker1() {
    return (
        <div>
            <h2>Poker</h2>
        </div>
    )
}



export class Poker extends Component {
    constructor(props) {
        super(props);
        this.state = {
            communityCards: [],
        };
    }




    UpdateCommunityCards = (communityCards) => {
        const newState = [];
        for (let i = 0; i< communityCards.length; i++) {
            const card = communityCards[i];
            if (card["suit"] === 0) {
                newState.push({cardRanks: card["rank"], cardSuitsSymbol: "♣️", cardSuitsLabel: "clubs", id: "comCard" + i})
            }
            if (card["suit"] === 1) {
                newState.push({cardRanks: card["rank"], cardSuitsSymbol: "♦️", cardSuitsLabel: "diamonds", id: "comCard" + i})
            }
            if (card["suit"] === 2) {
                newState.push({cardRanks: card["rank"], cardSuitsSymbol: "♥️", cardSuitsLabel: "hearts", id: "comCard" + i})
            }
            if (card["suit"] === 3) {
                newState.push({cardRanks: card["rank"], cardSuitsSymbol: "♠️", cardSuitsLabel: "spades", id: "comCard" + i})
            }
        }
        this.setState({communityCards: newState})
    }

    render() {
        return (
            <div>
                <h2>Poker</h2>
                <button onClick={() => this.getCardFromDeck()}>kaart</button>
                <button onClick={() => this.GetNewShuffledDeck()}>deck laden</button>
                <button onClick={() => this.getCommunityCards()}>communityCards</button>
                <body>
                    <div id="oval">
                        <div id="communityCards">
                            {this.state.communityCards.map(cards => (
                                <div key={cards.id} className="outline shadow rounded"> 
                                    <div className="top">
                                        <span>{cards.cardRanks}</span>
                                        <span><Emoji symbol={cards.cardSuitsSymbol} label={cards.cardSuitsLabel}/></span>
                                    </div>
                                    <h1><Emoji symbol={cards.cardSuitsSymbol} label={cards.cardSuitsLabel}/></h1>
                                    <div className="bottom">
                                        <span><Emoji symbol={cards.cardSuitsSymbol} label={cards.cardSuitsLabel}/></span>
                                        <span>{cards.cardRanks}</span>
                                    </div>
                                </div>  
                            ))}
                        </div>
                    </div>
                </body>
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
                //this.addCardToState(topCard["suit"], topCard["rank"])
            } else {
                console.error(response.statusText);
            }
        } catch (error) {
            console.error(error.toString());
        }
    }

    async getCommunityCards() {
        try {
            const response = await fetch('StartNewRound', {
                method: 'GET',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
            if (response.ok) {
                const communityCards = await response.json();
                this.UpdateCommunityCards(communityCards.communityCards);
            } else {
                console.error(response.statusText);
            }
        } catch (error) {
            console.error(error.toString());
        }
    }
}