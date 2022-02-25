using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace com.impactionalGames.LudoInu
{
    public class bluePlayerPieceBotOffline : EnemyBot
    {
        public override bool checkIfAllPeiceNOTOut()
        {
            if ( gm.blueOutPlayers != 4)
            {
                return true;
            }
            return false;

        }

        public override bool checkIfZeroPeiceOut()
        {
            if ( gm.blueOutPlayers == 0)
            {
                return true;
            }
            return false;
        }


        public override void openPiece()
        {
            
                playerPieces[gm.blueOutPlayers].MakePlayerReadyToMove(playerPieces[gm.blueOutPlayers].pathsParent.bluePathPoints);
                gm.blueOutPlayers++;
                gm.numOfStepsToMove = 0;
            
        }





        public override void checkWhichPieceCut()
        {
            
                for (int i = 0; i < gm.blueOutPlayers; i++)
                {
                    if (playerPieces[i].pathsParent.bluePathPoints[playerPieces[i].numberOfStepsAlreadyMoved + gm.numOfStepsToMove].playerPieces.Count != 0)
                    {
                        playerPieces[i].MoveSteps(playerPieces[i].pathsParent.bluePathPoints);
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
            
                for (int i = 0; i < gm.blueOutPlayers; i++)
                {

                    if (playerPieces[i].numberOfStepsAlreadyMoved + gm.numOfStepsToMove == 56)
                    {
                        playerPieces[i].MoveSteps(playerPieces[i].pathsParent.bluePathPoints);
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
                        playerPieces[i].MoveSteps(playerPieces[i].pathsParent.bluePathPoints);

                        //check if there is any other peice to move

                        //if no player to move endTurn;
                    }
                }
      
        }
    }
}
