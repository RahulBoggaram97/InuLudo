using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace com.impactionalGames.LudoInu
{
    public class getLastSpinApi : MonoBehaviour
    {
        public spineManager spinManager;

        public bool canSpin;

        public void getLastSpin() 
        {
            this.gameObject.SetActive(true);
            StartCoroutine(getLastSpinApi_Coroutine());
        }


        public void addCoinsFromWheel(string spinCoins) => StartCoroutine(addCoinsFromWheelCoroutine(spinCoins));

        IEnumerator getLastSpinApi_Coroutine()
        {
           

            mainMenuManager.Instance.LoadingDebugText.text = "Setting up spin...";
            string url = "https://ludo-inu.herokuapp.com/api/getLastSpin";

            Debug.Log("getting last spin data...");

            WWWForm form = new WWWForm();

            
            //headers["Content-Type"] = "application / x - form - url - encoded";


            form.AddField("Phone", playerPermData.getPhoneNumber());

            Debug.Log(form.ToString());

            

         

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))

            {

                
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error + "this is from lastSpinApi");

                    if (request.downloadHandler.text == "Failure")
                    {
                        canSpin = false;
                    }
                        
                    else  if(request.downloadHandler.text == "Success")
                    {
                        canSpin = true;
                    }
                    Debug.Log(canSpin);
                   
                }
                else
                {
                    if (request.downloadHandler.text == "Success")
                        canSpin = true;
                    else canSpin = false;
                    Debug.Log(request.downloadHandler.text);
                    Debug.Log(canSpin);
                    
                    

                }

                mainMenuManager.Instance.LoadingDebugText.text = "Spin all set up.";
                walletManager.Instance.coroutineCount++;
            }
        }
        

        IEnumerator addCoinsFromWheelCoroutine(string spinCoins)
        {
            string url = "https://ludo-inu.herokuapp.com/api/addSpinCoins";

            WWWForm form = new WWWForm();
            Debug.Log(playerPermData.getPhoneNumber());
            form.AddField("Phone", playerPermData.getPhoneNumber());
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

