using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System;

namespace com.impactionalGames.LudoInu
{
    public class getStoreItemsApi : MonoBehaviour
    {

        private void Awake()
        {
            walletManager.onWalletStateChanged += menuStateisStore;
        }

        private void OnDestroy()
        {
            walletManager.onWalletStateChanged -= menuStateisStore;
        }

        private void menuStateisStore(walletState state)
        {
            if(state == walletState.store)
            {
                getAllItemsInStore();
            }
        }

        public GameObject packPrefab;

        public Transform[] placeToInstatiate =  new Transform[4];

        public void getAllItemsInStore() => StartCoroutine(getAllItemsInStore_coroutine()); 

        IEnumerator getAllItemsInStore_coroutine()
        {
            string url = "https://ludo-inu.herokuapp.com/api/getAllItemsInStore";

            Debug.Log("calling the api...");

            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error);
                    Debug.Log(request.downloadHandler.text);
                }
                else
                {
                    Debug.Log(request.downloadHandler.text);

                    {
                        //"ID":1,
                        //"ItemName":"Starter Pack",
                        //"Type":"Coins",
                        //"Price":100,
                        //"Pack":"Starter",
                        //"Discount":200,
                        //"CoinsAmount":10000,
                        //"DiamondsAmount":null,
                        //"RemoveAds":"False",
                        //"TalkTime":3600

                        JSONNode node = JSON.Parse(request.downloadHandler.text);

                        Debug.Log(node[0].ToString());

                        int i = 0;

                        while (node[i] != null)
                        {
                            string typeShortend = node[i]["Type"].ToString().Substring(1, node[i]["Type"].ToString().Length -2);
                            Debug.Log("type shortend is: " + typeShortend);

                            Vector3 postionForinstantiate = new Vector3(0, sectionToInstatiate(typeShortend).position.y + (i * -800), 0);
                            Debug.Log(node[i]["Type"].ToString());
                           
                            

                            GameObject summonedPack = Instantiate(packPrefab, sectionToInstatiate(typeShortend));
                            RectTransform rectTransform = summonedPack.GetComponent<RectTransform>();


                            rectTransform.anchoredPosition = new Vector2(0,  (i * -600));
                            Debug.Log(sectionToInstatiate(typeShortend).position.y + (i * -650));
                            storePackCollectore packVariabls = summonedPack.GetComponent<storePackCollectore>();

                            packVariabls.id = node[i]["ID"].ToString();
                            packVariabls.ItemName = node[i]["ItemName"].ToString();
                            packVariabls.Type = node[i]["Type"].ToString();
                            packVariabls.Price = "Price: " + node[i]["Price"].ToString();
                            packVariabls.Discount = node[i]["Discount"].ToString();
                            packVariabls.Coins = node[i]["CoinsAmount"].ToString();
                            packVariabls.Diamounds = node[i]["DiamondsAmount"].ToString();
                            packVariabls.RemoveAds = node[i]["RemoveAds"].ToString();
                            packVariabls.TalkTime = node[i]["TalkTime"].ToString();

                            packVariabls.setPackValues();

                            i++;
                        }
                    }

                }
            }



            Transform sectionToInstatiate(string type)
            {
                switch (type)
                {
                    case "Coins":
                        return placeToInstatiate[0];
                        break;
                    case "Diamonds":
                        return placeToInstatiate[1];
                        break;
                    case "TalkTime":
                        return placeToInstatiate[2];
                        break;
                    case "Theme":
                        return placeToInstatiate[3];
                        break;
                    case "Discount":
                        return placeToInstatiate[4];
                        break;
                    default:
                        return placeToInstatiate[0];
                }
            }
        }
    }
}
