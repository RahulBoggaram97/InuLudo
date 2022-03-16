using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace com.impactionalGames.LudoInu
{
    public class getLastSpinApi : MonoBehaviour
    {

        public void getLastSpin() => StartCoroutine(getLastSpinApi_Coroutine());

        public void addCoinsFromWheel(string spinCoins) => StartCoroutine(addCoinsFromWheelCoroutine(spinCoins));

        IEnumerator getLastSpinApi_Coroutine()
        {
            string url = "https://ludo-inu.herokuapp.com/api/getLastSpin";

            WWWForm form = new WWWForm();
            form.AddField("userid", playerPermData.getPhoneNumber());

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
        

        IEnumerator addCoinsFromWheelCoroutine(string spinCoins)
        {
            string url = "https://ludo-inu.herokuapp.com/api/addCoins";

            WWWForm form = new WWWForm();
            Debug.Log(playerPermData.getPhoneNumber());
            form.AddField("userid", playerPermData.getPhoneNumber());
            form.AddField("coins", spinCoins);

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

