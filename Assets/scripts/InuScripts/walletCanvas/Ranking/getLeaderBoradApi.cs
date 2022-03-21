using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

namespace com.impactionalGames.LudoInu
{
    public class getLeaderBoradApi : MonoBehaviour
    {
        

        public List<Text> nameList = new List<Text>();
        public List<Text> diamaondsList = new List<Text>();

        public void getLeaderBoard() => StartCoroutine(getLeaderBoard_coroutine());

        IEnumerator getLeaderBoard_coroutine()
        {
            Debug.Log("fteching leaderboard");
            string url = "https://ludo-inu.herokuapp.com/api/getLeaderBoard";

            WWWForm form = new WWWForm();
            Debug.Log(playerPermData.getPhoneNumber());
            

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


                    JSONNode node = JSON.Parse(request.downloadHandler.text);

                    Debug.Log(node[0]["Name"].ToString() + "     this player 1");

                    Debug.Log(node[1]["Name"].ToString());

                    Debug.Log(node[2]["Name"].ToString());

                    fillRankingTexts(node);

                }
            }
        }


        void fillRankingTexts(JSONNode node)
        {
           for(int i = 0; i <=10; i++)
            {
                if (node[i] != null)
                {
                    nameList[i].text = node[i]["Name"];
                    diamaondsList[i].text = node[i]["Diamonds"];
                }
            }
        }
    }
}
