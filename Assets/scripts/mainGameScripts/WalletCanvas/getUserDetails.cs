using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;


namespace com.impactionalGames.LudoInu
{
    public class getUserDetails : MonoBehaviour
    {

        

        private void Start()
        {
            playerPermData.setPhoneNumber("+919876543210");

            getUserDet();

            

            Debug.Log("phone number in the start" + playerPermData.getPhoneNumber());

        }

        public void getUserDet() => StartCoroutine(getUserDeatails_coroutine());

        public void updateUser() => StartCoroutine(updateUser_Coroutine());

        IEnumerator getUserDeatails_coroutine()
        {
            string phone = playerPermData.getPhoneNumber();

            string uri = "https://ludo-inu.herokuapp.com/api/getUserDetails/" + playerPermData.getPhoneNumber() ;

            Debug.Log(uri);
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    Debug.Log(request.downloadHandler.text);

                    JSONNode node = JSON.Parse(request.downloadHandler.text);

                    //[{ "UserId":1646904850877,
                    //        "Phone":"+919876543210",
                    //        "Joined":"2022-03-10T09:34:11.000Z",
                    //        "Name":"prime1646904850877",
                    //        "ProfilePic":"undefined",
                    //        "Wallet":0,
                    //        "ReferralCode":null,
                    //        "Referrer":null,
                    //        "Diamonds":null,
                    //        "Talktime":null,
                    //        "Type":"",
                    //        "Points":100,
                    //        "Won":0,
                    //        "Lose":0,
                    //        "Drawn":0,
                    //        "Total":0,
                    //        "LastGame":0,
                    //        "MatchPoints":null}]

                    Debug.Log(node[0]["Name"].ToString());

                    string username = node[0]["Name"].ToString();

                    playerPermData.setUserName(username.Substring(1, username.Length - 2));
                    Debug.Log(playerPermData.getUserName());

                    string imageurl = node[0]["ProfilePic"].ToString();

                    //removing the invert commas for better use in the end;
                    playerPermData.setProfilePicUrl(imageurl.Substring(1, imageurl.Length - 2));


                    playerPermData.setMoney(int.Parse(node[0]["Wallet"].ToString()));

                    playerPermData.setReferCode(node[0]["ReferralCode"].ToString());

                    playerPermData.setDiamonds(node[0]["Diamonds"].ToString());

                    playerPermData.setWonMatches(node[0]["Won"].ToString());

                    playerPermData.setLoseMatches(node[0]["Lose"].ToString());

                    playerPermData.setDrawnMatches(node[0]["Drawn"].ToString());

                    playerPermData.setTotalMatches(node[0]["Total"].ToString());

                    //webMan.status.text = "get user details got called    " + playerPermData.getMoney();

                }
            }
        }


        IEnumerator updateUser_Coroutine()
        {
            Debug.Log(playerPermData.getPhoneNumber());
            Debug.Log(playerPermData.getUserName());
            Debug.Log("updating username");

            string url = "https://ludo-inu.herokuapp.com/api/updateUser";
            WWWForm form = new WWWForm();
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("Name", playerPermData.getUserName());

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
