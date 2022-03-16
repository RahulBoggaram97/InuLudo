using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace com.impactionalGames.LudoInu
{
    public class getLeaderBoradApi : MonoBehaviour
    {

        public void getLeaderBoard() => StartCoroutine(getLeaderBoard_coroutine());

        IEnumerator getLeaderBoard_coroutine()
        {
            string url = "https://ludo-inu.herokuapp.com/api/getLeaderBoard";

            WWWForm form = new WWWForm();
            Debug.Log(playerPermData.getPhoneNumber());
            

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
