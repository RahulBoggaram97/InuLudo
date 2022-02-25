using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace com.impactionalGames.LudoInu
{

    public class yellowPlayerPieceBotOffline : EnemyBot
    {
        public override bool checkIfAllPeiceNOTOut()
        {
            if (gm.yellowOutPlayers != 4)
            {
                return true;
            }
            return false;

        }

        public override bool checkIfZeroPeiceOut()
        {
            if (gm.yellowOutPlayers == 0)
            {
                return true;
            }
            return false;
        }


        public override void openPiece()
        {

            playerPieces[gm.yellowOutPlayers].MakePlayerReadyToMove(playerPieces[gm.yellowOutPlayers].pathsParent.yellowPathPoints);
            gm.yellowOutPlayers++;
            gm.numOfStepsToMove = 0;

        }





        public override void checkWhichPieceCut()
        {

            for (int i = 0; i < gm.yellowOutPlayers; i++)
            {
                if (playerPieces[i].pathsParent.yellowPathPoints[playerPieces[i].numberOfStepsAlreadyMoved + gm.numOfStepsToMove].playerPieces.Count != 0)
                {
                    playerPieces[i].MoveSteps(playerPieces[i].pathsParent.yellowPathPoints);
                    gm.rolleddice.hasMoved = true;
                    rollDice();
                    return;
                }
            }


            if (!gm.rolleddice.hasMoved)
            {
                checkIfCanFinish();
            }


        }


        public override void checkIfCanFinish()
        {

            for (int i = 0; i < gm.yellowOutPlayers; i++)
            {

                if (playerPieces[i].numberOfStepsAlreadyMoved + gm.numOfStepsToMove == 56)
                {
                    playerPieces[i].MoveSteps(playerPieces[i].pathsParent.yellowPathPoints);
                    gm.rolleddice.hasMoved = true;
                }
            }

            if (!gm.rolleddice.hasMoved)
            {
                moveTheFathestPiece();

            }


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


                    playerPieces[i].canMove = true;
                    gm.rolleddice.hasMoved = true;
                    playerPieces[i].MoveSteps(playerPieces[i].pathsParent.yellowPathPoints);

                    //check if there is any other peice to move

                    //if no player to move endTurn;
                }
            }

        }
    }
}
