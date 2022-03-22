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

        public List<GameObject> uiObjects = new List<GameObject>();



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
            Debug.Log("setting the pack values");
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
                reScalePrefab(coinsObject);
            }
            else
            {
                CoinsText.text = Discount;
            }


            if (Diamounds == "null")
            {
                DiamondsObject.SetActive(false);
                reScalePrefab(DiamondsObject);
            }
            else
            {
                DiamondsText.text = Discount;
            }

            if (TalkTime == "null")
            {
                talkTimeObject.SetActive(false);
                reScalePrefab(talkTimeObject);
            }
            else
            {
                TalkTimeText.text = Discount;
            }

            if(RemoveAds.Substring(1, 5) == "False")
            {
                removeAddsImage.SetActive(false);
                reScalePrefab(removeAddsImage);
                Debug.Log(RemoveAds);
            }
            else
            {
                removeAddsImage.SetActive(true);
            }
           


        }

        int reScaledUiIterationCount = 0;
        GameObject previouslyNulledObject;
        GameObject previouslyNulledObject2;

        public void reScalePrefab(GameObject theObject)
        {
            switch (reScaledUiIterationCount)
            {
                case 0:
                    reScaleUi(theObject);
                    break;
                case 1:
                    reScaleUi(previouslyNulledObject, theObject);
                    break ;
                case 2:
                    reScaleUi(previouslyNulledObject, previouslyNulledObject2, theObject);
                    break;
                    default:
                    break;

            }
        }



        public void reScaleUi(GameObject notAvailObject)
        {
            previouslyNulledObject = notAvailObject;
            RectTransform rect;

            int j = 0;

            for(int i = 0;i < uiObjects.Count; i++)
            {
                if(uiObjects[i].name != notAvailObject.name)
                {
                    rect = uiObjects[i].GetComponent<RectTransform>();
                    rect.anchoredPosition = new Vector2(-200 + (200*j), 40);
                    j++;
                }

                
            }

            reScaledUiIterationCount++;
        }

        public void reScaleUi(GameObject notAvalObject1, GameObject noAvailObject2)
        {
            previouslyNulledObject2 = noAvailObject2;
            RectTransform rect;

            int j = 0;

            for (int i = 0; i < uiObjects.Count; i++)
            {

                if (uiObjects[i].name != notAvalObject1.name && uiObjects[i].name != noAvailObject2.name)
                {
                    rect = uiObjects[i].GetComponent<RectTransform>();
                    rect.anchoredPosition = new Vector2(-200 + (400 * j), 40);
                    j ++;
                }
                


            }
            reScaledUiIterationCount++;
        }

        public void reScaleUi(GameObject notAvalObject1, GameObject noAvailObject2, GameObject noAvailObject3)
        {
            
            RectTransform rect;



            for (int i = 0; i < uiObjects.Count; i++)
            {

                if (uiObjects[i].name != notAvalObject1.name || uiObjects[i].name != noAvailObject2.name || uiObjects[i].name != noAvailObject3.name)
                {
                    rect = uiObjects[i].GetComponent<RectTransform>();
                    rect.anchoredPosition = new Vector2(0, 40);
                }
                else
                {
                    i--;
                }
            }
            
        }

        public void Buy()
        {

        }



    }
}
