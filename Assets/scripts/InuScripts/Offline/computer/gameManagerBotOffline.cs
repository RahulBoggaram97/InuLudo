using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{
    public class gameManagerBotOffline : MonoBehaviour
    {
        [Header("Completed Players")]
        public int yellowCompletedPlayers = 0;
        public int redCompletedPlayers = 0;
        public int blueCompletedPlayers = 0;
        public int greenCompletedPlayers = 0;

        public int totalPlayersCanPlay;

        [Header("Out Players")]
        public int yellowOutPlayers;
        public int greenOutPlayers;
        public int redOutPlayers;
        public int blueOutPlayers;

        int nextDice;
        public static gameManagerBotOffline gm;
        List<pathPointsBotOffline> playerOnPathPointsList = new List<pathPointsBotOffline>();

        [Header("Bools to track Dice")]
        public bool canDiceRoll = true;
        public bool transferDice = false;
        public bool selfDice = false;
        public bool CanPlayerMove;

        [Header("Dice List")]
        public List<rollindiceBotOffline> rollingDiceList;
        public rollindiceBotOffline rolleddice;

        [Header("enemy bots")]
        public greenPlayerPieceBotOffline greenBot;
        public yellowPlayerPieceBotOffline yellowBot;
        public bluePlayerPieceBotOffline blueBot;

        [Header("Number of steps to move")]
        public int numOfStepsToMove;

        [Header("Scenes")]
        public string walletCanvasname;


        private void Start()
        {
            gm = this;



        }

        public void AddPathPoint(pathPointsBotOffline pathPoint_)
        {
            playerOnPathPointsList.Add(pathPoint_);
        }

        public void RemovePathPoint(pathPointsBotOffline pathPoint_)
        {
            if (playerOnPathPointsList.Contains(pathPoint_))
            {
                playerOnPathPointsList.Remove(pathPoint_);
            }

            else
            {
                Debug.Log("Path point not found");
            }
        }



        public void RollingDiceManager()
        {
            //if no 6 is rolled or a piece is cut or you reach the center
            if (transferDice && rolleddice.hasMoved)
            {
                rolleddice.hasMoved = false;
                rolleddice.hasRolled = false;
                shiftDice();
               
                Debug.Log("hasMoved set to false");
            }
            //if 6 is rolled or a piece is cut or you reach the center
            else if (selfDice)
            {

                selfDice = false;
                rolleddice.hasMoved = false;
                rolleddice.hasRolled = false;
                //numOfStepsToMove = 0;
                Debug.Log("rooled dice in dice mangaer, has moved is set to: " + rolleddice.hasMoved + " the dice is :  " + rolleddice.ToString());
            }
            else
            {
                return;
            }

        }



        void shiftDice()
        {
            if (rolleddice == rollingDiceList[0])
            {
                rollingDiceList[0].gameObject.SetActive(false);
                rollingDiceList[1].gameObject.SetActive(true);
                greenBot.rollDice();
            }
            else if(rolleddice == rollingDiceList[1])
            {
                rollingDiceList[1].gameObject.SetActive(false);
                rollingDiceList[2].gameObject.SetActive(true);
                yellowBot.rollDice();
            }
            else if(rolleddice == rollingDiceList[2])
            {
                rollingDiceList[2].gameObject.SetActive(false);
                rollingDiceList[3].gameObject.SetActive(true);
                blueBot.rollDice();
            }
            else if(rolleddice == rollingDiceList[3])
            {
                rollingDiceList[3].gameObject.SetActive(false);
               
                rollingDiceList[0].gameObject.SetActive(true);
                Debug.Log("red dice can move");
            }
        }
    }
}
