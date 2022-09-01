using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace com.impactionalGames.LudoInu
{
    public class greenPlayerPieceBotOffline : EnemyBot
    {
        public override bool checkIfAllPeiceNOTOut()
        {
            if (gm.greenOutPlayers != 4)
            {
                Debug.Log("green all players are not out");
                return true;
            }
            return false;

        }

        public override bool checkIfZeroPeiceOut()
        {
            if (gm.greenOutPlayers == 0)
            {
                return true;
            }
            return false;
        }


        public override void openPiece()
        {

            playerPieces[gm.greenOutPlayers].MakePlayerReadyToMove(playerPieces[gm.greenOutPlayers].pathsParent.greenPathPoints);

            gm.greenOutPlayers++;
            gm.numOfStepsToMove = 0;

        }





        public override bool checkWhichPieceCut()
        {

            for (int i = 0; i < gm.greenOutPlayers; i++)
            {
                Debug.Log(this.name + " numOfStepsAlreadyMoved :" + playerPieces[i].numberOfStepsAlreadyMoved + ", numOfStepsToMove : " + gm.numOfStepsToMove);
                if (playerPieces[i].pathsParent.greenPathPoints[playerPieces[i].numberOfStepsAlreadyMoved + gm.numOfStepsToMove - 1].playerPieces.Count != 0)
                {
                    playerPieces[i].MoveSteps(playerPieces[i].pathsParent.greenPathPoints);
                    gm.rolleddice.hasMoved = false;
                    gm.rolleddice.hasRolled = false;
                    Debug.Log(gm.rolleddice.name + " cut a piece, rolling it again");
                    rollDice();
                    return true;
                }
            }


            return false;


        }


        public override bool checkIfCanFinish()
        {

            for (int i = 0; i < gm.greenOutPlayers; i++)
            {

                if (playerPieces[i].numberOfStepsAlreadyMoved + gm.numOfStepsToMove == 56)
                {
                    playerPieces[i].MoveSteps(playerPieces[i].pathsParent.greenPathPoints);
                    gm.rolleddice.hasMoved = false;
                    gm.rolleddice.hasRolled = false;
                    return true;
                }
            }

            return false;


        }

        public override void moveTheFathestPiece()
        {

            List<int> listOfNumOfStepsMoved = new List<int> { playerPieces[0].numberOfStepsAlreadyMoved, playerPieces[1].numberOfStepsAlreadyMoved, playerPieces[2].numberOfStepsAlreadyMoved, playerPieces[3].numberOfStepsAlreadyMoved };



            int maxNumOfStepsAlreadyMoved = (from number in listOfNumOfStepsMoved
                                             orderby number descending
                                             select number).Distinct().First();





            for (int i = 0; i < listOfNumOfStepsMoved.Count; i++)
            {
                if (maxNumOfStepsAlreadyMoved == playerPieces[i].numberOfStepsAlreadyMoved)
                {
                    if (!gm.rolleddice.hasMoved)
                    {

                        playerPieces[i].canMove = true;
                        gm.rolleddice.hasMoved = true;
                        playerPieces[i].MoveSteps(playerPieces[i].pathsParent.greenPathPoints);
                        Debug.Log("farthest peice moved");
                    }

                    //check if there is any other peice to move

                    //if no player to move endTurn;
                }
            }

        }
    }
}
