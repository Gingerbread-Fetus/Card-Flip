using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using Inventory;
using UI;
using UnityEngine;

namespace Core
{   
    public class Dealer : MonoBehaviour 
    {
        [SerializeField] Deck baseDeck;
        [SerializeField] List<CardButton> cardButtons;
        [SerializeField] Wallet playerWallet;
        Stack<Card> playDeck;
        List<Card> discard;
        List<Card> playedCards = new List<Card>(2);
        CardCollection answerSet;
        [HideInInspector]
        private bool b_isBetPlaced = false;
        int wager = 0;
        int multiplier = 0;
        [HideInInspector]
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

        public void ChooseCard(int i)
        {
            if(b_isBetPlaced) 
            {
                // Reveal card
                Card revealedCard = playedCards[i];
                cardButtons[i].ChangeText(revealedCard.value + " of " + revealedCard.Suit.ToString());
                if(answerSet.GetValidCards().Contains(revealedCard))
                {
                    print("Card match!");
                    int payout = wager * multiplier;
                    StartCoroutine(StartPayout(payout));
                }
                StartCoroutine(EndRound());
            }
        }

        private IEnumerator StartPayout(int winnings)
        {
            int total = playerWallet.coins + winnings;
            while(playerWallet.coins < total)
            {
                playerWallet.coins += 1;
                yield return new WaitForSeconds(.01f);
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

        public void SetAnswerSet(CardCollection newAnswers)
        {
            answerSet = newAnswers;
        }
    }
}
