using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class BankHandler : MonoBehaviour
    {
        [SerializeField] Wallet playerWallet;

        [SerializeField] Dealer dealer;
        [SerializeField] TMP_InputField textField;

        public void SendToDealer()
        {
            int wager = Int32.Parse(textField.text);
            if(playerWallet.coins >= wager && wager > 0)
            {
                playerWallet.coins -= wager;
                dealer.PlaceWager(wager);
                gameObject.SetActive(false);
            }
            else
            {
                print("number must be a positive integer!");
                textField.text = "1";
            }
        }
    }
}
