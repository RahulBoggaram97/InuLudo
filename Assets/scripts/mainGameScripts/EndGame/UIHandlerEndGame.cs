using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

namespace com.impactionalGames.LudoInu
{
    public class UIHandlerEndGame : MonoBehaviourPunCallbacks
    {
        public EndGameManager endGameManager;
        public WinnerDecider winDec;

        public GameObject leaderBoard;


        public void exitButton()
        {

            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
            PhotonNetwork.Disconnect();

            
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            Destroy(walletManager.Instance);
            Destroy(walletManager.Instance.gameObject);
            
            Destroy(mainMenuManager.Instance.gameObject);

            StartCoroutine(backLoadtheGame());
            
        }


        IEnumerator backLoadtheGame()
        {
            yield return new WaitForSeconds(1);

            yield return SceneManager.LoadSceneAsync("GameMenu", LoadSceneMode.Additive);




            //mainMenuManager.Instance.MainMenuCanvas.SetActive(false);
            //mainMenuManager.Instance.eventSystem.SetActive(false);
            //mainMenuManager.Instance._camera.SetActive(false);
            //mainMenuManager.Instance.extraCanvaseForBg.SetActive(false);
            //walletManager.Instance.walletCanvas.SetActive(false);

            yield return new WaitForFixedUpdate();

            SceneManager.UnloadScene("LudoBoard");


        }


        public void UpdateLeaderBoard()
        {
            leaderBoard.SetActive(true);
            rpc_updateLeaderBoard();
        }

        void rpc_updateLeaderBoard()
        {
            endGameManager.ranktext[0].text = PhotonNetwork.PlayerList[winDec.rank1Index].NickName;
            endGameManager.ranktext[1].text = PhotonNetwork.PlayerList[winDec.rank2Index].NickName;

            if (PhotonNetwork.PlayerList.Length > 2)
            {

                endGameManager.ranktext[2].text = PhotonNetwork.PlayerList[winDec.rank3Index].NickName;
                endGameManager.ranktext[3].text = PhotonNetwork.PlayerList[winDec.rank4Index].NickName;
            }
            else
            {
                return;
            }
        }
    }

}