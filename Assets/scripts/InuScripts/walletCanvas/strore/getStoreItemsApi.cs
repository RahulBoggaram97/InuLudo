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

        public Transform placeToInstatiate;

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
                            GameObject summonedPack = Instantiate(packPrefab, placeToInstatiate);
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
        }
    }
}
