using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace com.impactionalGames.LudoInu
{
    public class storeApis : MonoBehaviour
    {
        public void addCoins(string addedCoins) => StartCoroutine(addCoins_coroutine(addedCoins));

        public void addDiamonds(string addedDiamonds) => StartCoroutine(addCoins_coroutine(addedDiamonds));

        public void addTalkTime(string addedTalkTime) => StartCoroutine(addCoins_coroutine(addedTalkTime));




        IEnumerator addCoins_coroutine(string coins)
        {
            string url = "https://ludo-inu.herokuapp.com/api/addCoins";

            WWWForm form = new WWWForm();
            Debug.Log(playerPermData.getPhoneNumber());
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("Coins", coins);

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
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

                }
            }
        }




        IEnumerator addDiamonds_coroutine(string diamonds)
        {
            string url = "https://ludo-inu.herokuapp.com/api/addDiamonds";

            WWWForm form = new WWWForm();
            Debug.Log(playerPermData.getPhoneNumber());
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("Diamonds", diamonds);

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
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

                }
            }
        }

        IEnumerator addTalkTime_coroutine(string TalkTime)
        {
            string url = "https://ludo-inu.herokuapp.com/api/addTalkTime";

            WWWForm form = new WWWForm();
            Debug.Log(playerPermData.getPhoneNumber());
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("TalkTime", TalkTime);

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
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

                }
            }
        }


    }
}
