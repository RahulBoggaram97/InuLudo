using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{
    public class bluePlayerOflline : playerPeiceOffline
    {
        public gameManagerOffline gm;
        public rollinDiceOffline blueDice;
        public int individualScore;



        private void OnMouseDown()
        {
            movePiece();

        }






        void movePiece()
        {
            if (!isReady)
            {
                if (gm.rolleddice == blueDice && gm.numOfStepsToMove == 6)
                {
                    gm.blueOutPlayers += 1;
                    MakePlayerReadyToMove(pathsParent.bluePathPoints);
                    gm.numOfStepsToMove = 0;
                    
                    return;
                }
            }
            else
            {




                if (gm.rolleddice == blueDice && gm.rolleddice.hasRolled && !gm.rolleddice.hasMoved && blueDice.gameObject.activeSelf)
                {
                    if (gm.numOfStepsToMove != 0)
                    {
                        canMove = true;
                        gm.rolleddice.hasMoved = true;
                        MoveSteps(pathsParent.bluePathPoints);


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
                        "redice activeSelf value:" + blueDice.gameObject.activeSelf);
                }

            }
        }


    }
}
