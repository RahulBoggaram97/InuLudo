using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

namespace com.impactionalGames.LudoInu
{
    public class createAndJoinRooms : MonoBehaviourPunCallbacks
    {

        [Header("Input Field For Creating Private Room")]
        
        [SerializeField] private InputField joinFeild;


        public byte maxPlayerPerRoom = 4;

        public string levelToLoad;

        [Header("debug:")]
        public Text debugText;
        public string roomCode;

        TypedLobby customLobby = new TypedLobby("customLobby", LobbyType.Default);


        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;

        }


        //playerwithfriends create room
        public void joinLobby()
        {
            PhotonNetwork.JoinLobby(customLobby);
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("the lobby joined is : " + PhotonNetwork.CurrentLobby);
        }

        public void createRoom()
        {
           
            //Debug.Log("current lobby is " + PhotonNetwork.CurrentLobby.Name);

            roomCode = gernrateRandomRoomCode();

            PhotonNetwork.NickName = playerPermData.getUserName();

            PhotonNetwork.CreateRoom(roomCode);



        }


        //genrated a random 4 alphabets code for the room name
        private string gernrateRandomRoomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] stringchars = new char[4];



            for (int i = 0; i < stringchars.Length; i++)
            {
                stringchars[i] = chars[Random.Range(0, chars.Length - 1)];
               

            }

            string finalRoomCode = new string(stringchars);

            return finalRoomCode;
        }




        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            debugText.text = message + " " + returnCode.ToString();

            Debug.Log(returnCode.ToString());
        }




        //playewithFriends join Room
        public void joinRoom()
        {
            PhotonNetwork.NickName = playerPermData.getUserName();
            PhotonNetwork.JoinRoom(joinFeild.text);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            debugText.text = message + " " + returnCode.ToString();

            Debug.Log(returnCode.ToString());
        }


        public void onPressBackForPlayWithFriendsButton()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                PhotonNetwork.LeaveRoom();
            }
            PhotonNetwork.LeaveLobby();

        }

        //takes you to the other 
        public override void OnJoinedRoom()
        {
            //meaning that you have created or joined room;

            PhotonNetwork.LoadLevel(levelToLoad);

        }
    }
}
