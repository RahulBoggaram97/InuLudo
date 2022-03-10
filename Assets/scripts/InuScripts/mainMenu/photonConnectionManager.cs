using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

namespace com.impactionalGames.LudoInu
{
    public class photonConnectionManager : MonoBehaviourPunCallbacks
    {

        [Header("Photon Vars")]
        public string gameVersion = "1";
        public string levleToLoadAfterJoiningTheGame;


        private void Awake()
        {
            mainMenuManager.onMenuStateChanged += HandleMainMenuStateChanged;
            
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        private void HandleMainMenuStateChanged(mainMenuState state)
        {
           if(state == mainMenuState.loading)
            {
                
                connect();
                
            }
        }

        public void connect()
        {
            Debug.Log("the connect method got called from photon connection manager");
            if (PhotonNetwork.IsConnected)
            {

                Debug.Log(PhotonNetwork.CurrentLobby.Name + " is the lobby and  the room is " + PhotonNetwork.CurrentRoom.Name);
                mainMenuManager.instance.updateMainMenuState(mainMenuState.initial);
            }
            else
            {

                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
           
        }

        public override void OnConnectedToMaster()
        {

            //have to wait for this message in order to use the create button
            Debug.Log("the server has made or connected, now we can create room");
            mainMenuManager.instance.updateMainMenuState(mainMenuState.initial);

        }


     


    }
}
