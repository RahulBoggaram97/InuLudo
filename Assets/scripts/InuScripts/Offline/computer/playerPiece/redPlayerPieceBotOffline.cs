using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace com.impactionalGames.LudoInu
{
    public class redPlayerPieceBotOffline : playerPieceBotOffine
    {
        public gameManagerBotOffline gm;
        public rollindiceBotOffline redDice;
        public int individualScore;



        private void OnMouseDown()
        {
            movePiece();

        }






        void movePiece()
        {
            if (!isReady)
            {
                if (gm.rolleddice == redDice && gm.numOfStepsToMove == 6)
                {
                    gm.redOutPlayers += 1;
                    MakePlayerReadyToMove(pathsParent.redPathPoints);
                    gm.numOfStepsToMove = 0;

                    return;
                }
            }
            else
            {




                if (gm.rolleddice == redDice && gm.rolleddice.hasRolled && !gm.rolleddice.hasMoved && redDice.gameObject.activeSelf)
                {
                    if (gm.numOfStepsToMove != 0)
                    {
                        canMove = true;
                        gm.rolleddice.hasMoved = true;
                        MoveSteps(pathsParent.redPathPoints);


                    }
                    else
                    {
                        Debug.Log("numOfSetpsToMove is zero, there is a problem with the dice");
                    }

                }
                else
                {
                    Debug.Log("rolled dice is " + gm.rolleddice.gameObject.name + "    " +
                        "hasRolled value:" + gm.rolleddice.hasRolled + "    " +
                        "hasMoved value:" + gm.rolleddice.hasMoved + "   " +
                        "redice activeSelf value:" + redDice.gameObject.activeSelf);
                }

            }
        }
    }
}
