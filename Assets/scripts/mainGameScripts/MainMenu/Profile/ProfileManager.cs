using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using SimpleJSON;

namespace com.impactionalGames.LudoInu
{
    public class ProfileManager : MonoBehaviour
    {
        public InputField playerNameField;

        [Header("other scripts")]
    
        public getUserDetails getuseDetObject;


        [Header("Text elements")]
        public Text phoneNum;
        public Text walletCoinsText;
        public Text diamondsText;
        public Text totalmatchesText;
        public Text wonMatchesText;
        public Text loseMatchesText;
        public Text refrelCodeText;


        private void Start()
        {
            getPlayerName();

            getuseDetObject.getUserDet();

            Debug.Log("profile start called");

           

            

            getPlayerName();

            //phoneNum.text = playerPermData.getPhoneNumber();

            walletCoinsText.text = playerPermData.getMoney().ToString();

            diamondsText.text = playerPermData.getDiamonds();

            //totalmatchesText.text = playerPermData.getTotalMatches();

            wonMatchesText.text = playerPermData.getWonMatches();

            //loseMatchesText.text = playerPermData.getLoseMatchesr();

            //refrelCodeText.text = "Refrel Code: " + playerPermData.getReferCode();

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