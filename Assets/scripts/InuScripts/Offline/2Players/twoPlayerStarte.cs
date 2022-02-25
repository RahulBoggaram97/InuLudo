using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{
    public class twoPlayerStarte : MonoBehaviour
    {
        public colorSelection2player selectedColor;
        public gameManagerOffline gm;

        public rollinDiceOffline[] rollingDiceCollect;

        public LudoHomes[] colorPieces;


        public GameObject selectionPanel;
        public GameObject playerChoosePanel;

        public void startTwoPlayerGame()
        {
            gm.totalPlayersCanPlay = 2;
            foreach(rollinDiceOffline i in gm.rollingDiceList)
            {
                i.gameObject.SetActive(false);
            }
            setPlayerOne();
            setPlayerTwo();

            OfflineManager.instance.gameStarted = true;

            selectionPanel.SetActive(false);
            playerChoosePanel.SetActive(false);
        }


        void setPlayerOne()
        {
            switch (selectedColor.player1Colour)
            {
                case "red":
                    gm.rollingDiceList[0] = rollingDiceCollect[0];
                    gm.rollingDiceList[0].gameObject.SetActive(true);
                    activateColourPiece(0);
                    break;
                case "green":
                    gm.rollingDiceList[0] = rollingDiceCollect[1];
                    gm.rollingDiceList[0].gameObject.SetActive(true);
                    activateColourPiece(1);
                    break;
                case "yellow":
                    gm.rollingDiceList[0] = rollingDiceCollect[2];
                    gm.rollingDiceList[0].gameObject.SetActive(true);
                    activateColourPiece(2);
                    break;
                case "blue":
                    gm.rollingDiceList[0] = rollingDiceCollect[3];
                    gm.rollingDiceList[0].gameObject.SetActive(true);
                    activateColourPiece(3);
                    break;
            }
        }


        void setPlayerTwo()
        {
            switch (selectedColor.player2Colour)
            {
                case "red":
                    gm.rollingDiceList[2] = rollingDiceCollect[0];
                   
                    activateColourPiece(0);
                    break;
                case "green":
                    gm.rollingDiceList[2] = rollingDiceCollect[1];
                   
                    activateColourPiece(1);
                    break;
                case "yellow":
                    gm.rollingDiceList[2] = rollingDiceCollect[2];
                   
                    activateColourPiece(2);
                    break;
                case "blue":
                    gm.rollingDiceList[2] = rollingDiceCollect[3];
                   
                    activateColourPiece(3);
                    break;
            }
        }

        void activateColourPiece(int index)
        {
            for (int i = 0; i < 4; i++)
            {
                colorPieces[index].playerPieces[i].SetActive(true);
            }

        }
    }
}