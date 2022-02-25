using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace com.impactionalGames.LudoInu
{
    public class photonConnectionManager : MonoBehaviourPunCallbacks
    {

        [Header("Photon Vars")]
        public string gameVersion = "1";

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

            if (PhotonNetwork.IsConnected)
            {

                PhotonNetwork.JoinRandomRoom();
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
