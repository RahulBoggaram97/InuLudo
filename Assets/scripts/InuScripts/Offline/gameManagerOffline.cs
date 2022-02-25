using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{

    public class gameManagerOffline : MonoBehaviour
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
        public static gameManagerOffline gm;
        List<pathPointsOffline> playerOnPathPointsList = new List<pathPointsOffline>();

        [Header("Bools to track Dice")]
        public bool canDiceRoll = true;
        public bool transferDice = false;
        public bool selfDice = false;
        public bool CanPlayerMove;

        [Header("Dice List")]
        public List<rollinDiceOffline> rollingDiceList;
        public rollinDiceOffline rolleddice;

        [Header("Number of steps to move")]
        public int numOfStepsToMove;

        [Header("Scenes")]
        public string walletCanvasname;


        private void Start()
        {
            gm = this;

            

        }

        public void AddPathPoint(pathPointsOffline pathPoint_)
        {
            playerOnPathPointsList.Add(pathPoint_);
        }

        public void RemovePathPoint(pathPointsOffline pathPoint_)
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
            
            if (transferDice && rolleddice.hasMoved)
            {
                shiftDice();
                rolleddice.hasMoved = false;
                rolleddice.hasRolled = false;
                Debug.Log("hasMoved set to false");
            }
            else if (selfDice)
            {

                selfDice = false;
                rolleddice.hasMoved = false;
                rolleddice.hasRolled = false;
                //numOfStepsToMove = 0;
                Debug.Log("rooled dice in dice mangaer, has moved is set to: " + rolleddice.hasMoved  + " the dice is :  "  + rolleddice.ToString());
            }
            else
            {
                return;
            }

        }



        void shiftDice()
        {
            if (totalPlayersCanPlay == 1)
            {
                return;

            }
            else if (totalPlayersCanPlay == 2)
            {
                if (rolleddice == rollingDiceList[0])
                {
                    rollingDiceList[0].gameObject.SetActive(false);
                    rollingDiceList[2].gameObject.SetActive(true);
                    rollingDiceList[2].hasMoved = false;
                }
                else
                {
                    rollingDiceList[0].gameObject.SetActive(true);
                    rollingDiceList[0].hasMoved = false;
                    rollingDiceList[2].gameObject.SetActive(false);
                }
            }
            else if (totalPlayersCanPlay == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        nextDice = 1;
                    }
                    if (i == 1)
                    {
                        nextDice = 2;
                    }

                    if (i == 2)
                    {
                        nextDice = 0;
                    }
                    if (rolleddice == rollingDiceList[i])
                    {
                        rollingDiceList[i].gameObject.SetActive(false);
                        rollingDiceList[nextDice].gameObject.SetActive(true);
                        rollingDiceList[nextDice].hasMoved = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0) { nextDice = 1; }
                    if (i == 1) { nextDice = 2; }
                    if (i == 2) { nextDice = 3; }
                    if (i == 3) { nextDice = 0; }
                    if (rolleddice == rollingDiceList[i])
                    {
                        rollingDiceList[i].gameObject.SetActive(false);
                        rollingDiceList[nextDice].gameObject.SetActive(true);
                        rollingDiceList[nextDice].hasMoved = false;
                    }
                }
            }
        }
    }


   
}
