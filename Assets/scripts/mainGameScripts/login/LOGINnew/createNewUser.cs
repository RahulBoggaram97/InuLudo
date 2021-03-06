using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

namespace com.impactionalGames.LudoInu
{
    public class createNewUser : MonoBehaviour
    {

        public Text debugText;

        //private void Awake()
        //{
        //    authManager.loginStateChanged += HandleOnAuthenticate;
        //}

        //private void OnDestroy()
        //{
        //    authManager.loginStateChanged -= HandleOnAuthenticate;
        //}

        //private void HandleOnAuthenticate(loginState state)
        //{
        //    if(state == loginState.authenticated)
        //    {
        //        createUser();
        //    }
        //}

        public void createUser() => StartCoroutine(createNewUser_Coroutine());

        

       IEnumerator createNewUser_Coroutine()
        {
          

            string url = "https://ludo-inu.herokuapp.com/api/createUser";
            WWWForm form = new WWWForm();
            form.AddField("Phone", playerPermData.getPhoneNumber());

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
            {
                yield return request.SendWebRequest();
                if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    //debugText.text = request.error;
                    Debug.Log(request.error);
                    Debug.Log(request.downloadHandler.text); 
                }
                else
                {
                    //debugText.text = request.error;
                    //authManager.instance.updateLoginState(loginState.loggedIn);
                    Debug.Log(request.downloadHandler.text);
                }
            }
        }


       

    }
}
