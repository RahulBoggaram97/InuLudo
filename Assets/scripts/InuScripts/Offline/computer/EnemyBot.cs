using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace com.impactionalGames.LudoInu
{
    public class EnemyBot : MonoBehaviour
    {
        public gameManagerBotOffline gm;

        public rollindiceBotOffline dice;

        public playerPieceBotOffine[] playerPieces;

        public void playEnemyBotTurn()
        {
            
        }

        public void rollDice()
        {
            StartCoroutine(rollDice_Coroutine());
        }

       public  IEnumerator rollDice_Coroutine()
        {
            dice.preRollDice();
            yield return new WaitForSeconds(2.01f);
            yield return new WaitForEndOfFrame();
            pseudoMoveAllPiecesAvailable();
        }



        void pseudoMoveAllPiecesAvailable()
        {
            Debug.Log(gm.numOfStepsToMove);

            if (gm.numOfStepsToMove == 6)
            {               
                if (checkIfAllPeiceNOTOut())
                {
                    openPiece();
                    rollDice();
                }
                else
                {
                    checkWhichPieceCut();
                }
                gm.RollingDiceManager();
                return;
            }
            else
            {
                if (!checkIfZeroPeiceOut())
                    checkWhichPieceCut();
                else
                    gm.RollingDiceManager();  
            }

            
            
        }


        public virtual  bool checkIfAllPeiceNOTOut()
        {
            //if (dice.name.Contains("green") && gm.greenOutPlayers != 4)
            //{
            //    return true;
            //}
             return false;
            
        }

        public virtual bool checkIfZeroPeiceOut()
        {
            
            return false;
        }


        public virtual void openPiece()
        {
            if (dice.name.Contains("green"))
            {
                playerPieces[gm.greenOutPlayers].MakePlayerReadyToMove(playerPieces[gm.greenOutPlayers].pathsParent.greenPathPoints);
                gm.greenOutPlayers++;
                gm.numOfStepsToMove = 0;
            }
        }


        


        public virtual void checkWhichPieceCut()
        {
            if (dice.name.Contains("green"))
            {
                for (int i = 0; i < gm.greenOutPlayers; i++)
                {
                   if( playerPieces[i].pathsParent.greenPathPoints[playerPieces[i].numberOfStepsAlreadyMoved + gm.numOfStepsToMove].playerPieces.Count != 0)
                    {
                        playerPieces[i].MoveSteps(playerPieces[i].pathsParent.greenPathPoints);
                        gm.rolleddice.hasMoved=true;
                        rollDice();
                        return;
                    }
                }

                if (!gm.rolleddice.hasMoved)
                    checkIfCanFinish();
            }

        }


        public virtual void checkIfCanFinish()
        {
            if (dice.name.Contains("green"))
            {
                for (int i = 0; i < gm.greenOutPlayers; i++)
                {

                    if (playerPieces[i].numberOfStepsAlreadyMoved + gm.numOfStepsToMove == 57)
                    {
                        playerPieces[i].MoveSteps(playerPieces[i].pathsParent.greenPathPoints);
                        gm.rolleddice.hasMoved = true;
                    }
                }

                if (!gm.rolleddice.hasMoved)
                    moveTheFathestPiece();
            }    

        }

        public virtual void moveTheFathestPiece()
        {
            if (dice.name.Contains("green"))
            {
                List<int> listOfNumOfStepsMoved = new List<int>();

                for (int i = 0; i < playerPieces.Length; i++)
                {
                    listOfNumOfStepsMoved.Add(playerPieces[i].numberOfStepsAlreadyMoved);
                }

                int maxNumOfStepsAlreadyMoved = (from number in listOfNumOfStepsMoved
                                                 orderby number descending
                                                 select number).Distinct().First();



                for (int i = 0; i < listOfNumOfStepsMoved.Count; i++)
                {
                    if (maxNumOfStepsAlreadyMoved == playerPieces[i].numberOfStepsAlreadyMoved)
                    {
                        

                        playerPieces[i].canMove = true;
                        gm.rolleddice.hasMoved = true;
                        playerPieces[i].MoveSteps(playerPieces[i].pathsParent.greenPathPoints);

                        //check if there is any other peice to move

                        //if no player to move endTurn;
                    }
                }



            }
        }
    }
}
