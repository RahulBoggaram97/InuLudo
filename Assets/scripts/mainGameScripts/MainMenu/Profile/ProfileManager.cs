using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using SimpleJSON;

namespace com.impactionalGames.LudoPrime
{
    public class ProfileManager : MonoBehaviour
    {
        public InputField playerNameField;

        public Text phoneNum;
        public Text emailId;
      

        private void Start()
        {
            getPlayerName();

            phoneNum.text = playerPermData.getPhoneNumber();
            //emailId.text = playerPermData.getEmail();
        }


        public void getPlayerName()
        {
            string defaultName = string.Empty;
            if (playerNameField != null)
            {
                if (PlayerPrefs.HasKey(playerPermData.USERNAME_PREF_KEY))
                {
                    defaultName = PlayerPrefs.GetString(playerPermData.USERNAME_PREF_KEY);
                    playerNameField.text = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
        

        }

        public void setPlayerName()
        {
            if (playerNameField.text != string.Empty)
            {
                PhotonNetwork.NickName = playerNameField.text;
                playerPermData.setUserName(playerNameField.text);
            }
            else
            {

                return;
            }
        }

        void getUserDataFromRest()
        {

        }

    }
}