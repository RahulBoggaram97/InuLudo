using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

namespace com.impactionalGames.LudoInu
{
    public class EndGameManager : MonoBehaviourPunCallbacks
    {
        public GameObject winImage;
        public GameObject lossImage;
        public static EndGameManager egm;

        public RollinDice[] scoreDice;

        public Text[] ranktext;

        public string levelToLoad;

        private void Start()
        {
            egm = this;
        }
        public void winStarterMethod()
        {
            checkWhichLobby();
        }

        void checkWhichLobby()
        {
            

            if (checkIfItsOneVoneLobby())
            {
                declareOneVoneGame();



            }
            else if (!chechIfItsCustomLobby())
            {
                
            }
            else
            {
                
            }
        }

        bool checkIfItsOneVoneLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneVoneOne":
                    return true;
                case "oneVoneFive":
                    return true;
                case "oneVoneTen":
                    return true;
                case "oneVoneTwentyFive":
                    return true;
                case "oneVoneFifty":
                    return true;
                case "oneVoneHundred":
                    return true;
                default:
                    return false;
            }

        }

        bool chechIfItsCustomLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "customLobby":
                    return true;
                default:
                    return false;
            }

        }


        void declareOneVoneGame()
        {
            if(scoreDice[0].score > scoreDice[2].score)
            {
                if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
                {
                    winImage.SetActive(true);

                    //setting up the leaderboardNames
                    setUpleaderBoardName(0, 1, -1, -1);

                    return;

                }
                else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[1])
                {
                    lossImage.SetActive(true);

                    //setting up the leaderboardNames
                    setUpleaderBoardName(0, 1, -1, -1);

                    return;

                }
            }
            else
            {
                if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
                {
                    lossImage.SetActive(true);

                    //setting up the leaderboardNames
                    setUpleaderBoardName(1, 0, -1, -1);

                    return;


                }
                else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[1])
                {
                    winImage.SetActive(true);

                    //setting up the leaderboardNames
                    setUpleaderBoardName(1, 0, -1, -1);

                    return;

                }

            }
        }

        void setUpleaderBoardName(int rank1, int rank2, int rank3, int rank4)
        {
            ranktext[0].text = PhotonNetwork.PlayerList[rank1].NickName;
            ranktext[1].text = PhotonNetwork.PlayerList[rank2].NickName;

            if(rank3 != -1)
            {
                ranktext[2].text = PhotonNetwork.PlayerList[rank3].NickName;
            }
            else
            {
                return;
            }
            if (rank4 != -1)
            {
                ranktext[3].text = PhotonNetwork.PlayerList[rank4].NickName;
            }
            else
            {
                return;
            }

        }





    }
}
