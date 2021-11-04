using System.Collections;
using System.Collections.Generic;
using Cards;
using Core;
using UnityEngine;
using UnityEngine.UI;

public class UIWagerButton : MonoBehaviour
{
    [SerializeField] int multiplier = 0;
    [SerializeField] bool isClicked;
    [SerializeField] CardCollection validCards;
    // Start is called before the first frame update
    
    public void SendMultiplier()
    {
        var dealer = GameObject.FindWithTag("Dealer").GetComponent<Dealer>();
        dealer.SetMultiplier(multiplier);
    }

    public void SendAnswerSet()
    {
        var dealer = GameObject.FindWithTag("Dealer").GetComponent<Dealer>();
        dealer.SetAnswerSet(validCards);
    }

    public void DeactivateButton()
    {
        GetComponent<Button>().interactable = false;
    }

    public void ReenableButton()
    {
        GetComponent<Button>().interactable = true;
    }

    public bool containsCard(Card card)
    {
        return validCards.GetValidCards().Contains(card);
    }
}
