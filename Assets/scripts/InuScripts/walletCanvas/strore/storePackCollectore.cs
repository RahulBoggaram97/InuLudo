using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.impactionalGames.LudoInu
{
    public class storePackCollectore : MonoBehaviour
    {
        [Header("Text Elements")]
        public Text ItemNameText;
        public Text PriceText;
        public Text DiscountText;
        public Text CoinsText;
        public Text DiamondsText;
        public Text TalkTimeText;

        [Header("GameObjects")]

        public GameObject removeAddsImage;
        public GameObject discountObject;
        public GameObject coinsObject;
        public GameObject talkTimeObject;
        public GameObject DiamondsObject;



        [Header("Strings")]
        public string id;
        public string ItemName;
        public string Type;
        public string Price;
        public string PackName;
        public string Discount;
        public string Coins;
        public string Diamounds;
        public string RemoveAds;
        public string TalkTime;

        public void setPackValues()
        {
            ItemNameText.text = ItemName;
            PriceText.text = Price;

            if(Discount == "null")
            {
                discountObject.SetActive(false);
            }
            else
            {
                DiscountText.text = Discount;
            }

            if (Coins == "null")
            {
                coinsObject.SetActive(false);
            }
            else
            {
                CoinsText.text = Discount;
            }


            if (Diamounds == "null")
            {
                DiamondsObject.SetActive(false);
            }
            else
            {
                DiamondsText.text = Discount;
            }

            if (TalkTime == "null")
            {
                talkTimeObject.SetActive(false);
            }
            else
            {
                TalkTimeText.text = Discount;
            }


            
        }


        public void Buy()
        {

        }



    }
}
