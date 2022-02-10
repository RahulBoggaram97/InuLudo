using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace com.impactionalGames.LudoPrime
{
    public class MoneyManager : MonoBehaviour
    {
        public Text moneyText;

        private void Awake()
        {
            lobbyUITemplate.manageFee += HandleFeeManagement;
        }

        private void OnDestroy()
        {
            lobbyUITemplate.manageFee -= HandleFeeManagement;
        }

        private void Start()
        {
            
            moneyText.text = playerPermData.getMoney().ToString();
        }

        public void HandleFeeManagement(int enteryFee)
        {
            int currentMoney = playerPermData.getMoney();

            currentMoney = currentMoney - enteryFee;

            playerPermData.setMoney(currentMoney);

            moneyText.text = playerPermData.getMoney().ToString();
        }


       
    }
}
