using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


namespace com.impactionalGames.LudoInu
{
    public class twoWinners : lobbyUITemplate
    {
        public TypedLobby twoWinnersLobby1 = new TypedLobby("twoWinnersOne", LobbyType.Default);
        public TypedLobby twoWinnersLobby5 = new TypedLobby("twoWinnersFive", LobbyType.Default);
        public TypedLobby twoWinnersLobby10 = new TypedLobby("twoWinnersTen", LobbyType.Default);
        public TypedLobby twoWinnersLobby25 = new TypedLobby("twoWinnersTwentyFive", LobbyType.Default);
        public TypedLobby twoWinnersLobby50 = new TypedLobby("twoWinnersFifty", LobbyType.Default);
        public TypedLobby twoWinnersLobby100 = new TypedLobby("twoWinnersHundred", LobbyType.Default);


        public async void jointwoWinners1()
        {
            await manageTheFee();

            PhotonNetwork.JoinLobby(twoWinnersLobby1);
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointwoWinners5()
        {
            await manageTheFee();

            PhotonNetwork.JoinLobby(twoWinnersLobby5);
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointwoWinners10()
        {
            await manageTheFee();

            PhotonNetwork.JoinLobby(twoWinnersLobby10);
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointwoWinners25()
        {
            await manageTheFee();

            PhotonNetwork.JoinLobby(twoWinnersLobby25);
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointwoWinners50()
        {
            await manageTheFee();

            PhotonNetwork.JoinLobby(twoWinnersLobby50);
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointwoWinners100()
        {
            await manageTheFee();

            PhotonNetwork.JoinLobby(twoWinnersLobby100);
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }


    }
}