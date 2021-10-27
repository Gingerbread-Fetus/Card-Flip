using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using UI;
using UnityEngine;

namespace Core
{   
    public class Dealer : MonoBehaviour 
    {
        [SerializeField] Deck baseDeck;
        [SerializeField] List<CardButton> cardButtons;
        Stack<Card> playDeck;
        List<Card> discard;
        List<Card> playedCards = new List<Card>(2);
        [HideInInspector]
        private bool b_isBetPlaced = false;
        int wager = 0;
        int multiplier = 0;
        public int roundsPlayed = 0;

        private void Awake() 
        {
            playDeck = new Stack<Card>(baseDeck.Shuffle());
            GetNextCards();
        }

        private IEnumerator EndRound()
        {
            yield return new WaitForSeconds(3.0f);//TODO See if I can make this wait until the payout is resolved
            foreach(CardButton cb in cardButtons) cb.ChangeText("Card Back");
            print("Reset the state here");
            ResetDeck();
            GetNextCards();
            roundsPlayed += 1;
            print("Rounds played: " + roundsPlayed);
            b_isBetPlaced = false;
        }

        private void GetNextCards()
        {
            playedCards.Clear();
            playedCards.Add(GetCard());
            playedCards.Add(GetCard());
        }

        private void ResetDeck()
        {
            if (playDeck.Count == 0)
            {
                print("Checking deck reset");
                playDeck.Clear();
                foreach (Card c in baseDeck.Shuffle())
                {
                    playDeck.Push(c);
                }
            }
        }

        private Card GetCard()
        {
            return playDeck.Pop();
        }

        //TODO Note that this should not be possible to call before they have placed their bet.
        public void ChooseCard(int i)
        {
            if(b_isBetPlaced) 
            {
                // Reveal card
                cardButtons[i].ChangeText(playedCards[i].value + " of " + playedCards[i].Suit.ToString());
                // Card ChosenCard = playedCards[i];
                // foreach(Card card in playedCards) discard.Add(card);
                // playedCards.Clear();
                // roundsPlayed++;
                // Resolve bet
                StartCoroutine(EndRound());
            }
        }


        public void PlaceWager(int newWager)
        {
            wager = newWager;
            b_isBetPlaced = true;
        }

        public void SetMultiplier(int newMultiplier)
        {
            multiplier = newMultiplier;
        }
    }
}