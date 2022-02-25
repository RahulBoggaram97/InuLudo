using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{
    public class yellowPlayerOffline : playerPeiceOffline
    {
        public gameManagerOffline gm;
        public rollinDiceOffline yellowDice;
        public int individualScore;



        private void OnMouseDown()
        {
            movePiece();

        }






        void movePiece()
        {
            if (!isReady)
            {
                if (gm.rolleddice == yellowDice && gm.numOfStepsToMove == 6)
                {
                    gm.yellowOutPlayers += 1;
                    MakePlayerReadyToMove(pathsParent.yellowPathPoints);
                    gm.numOfStepsToMove = 0;
                  
                    return;
                }
            }
            else
            {



                if (gm.rolleddice == yellowDice && gm.rolleddice.hasRolled && !gm.rolleddice.hasMoved && yellowDice.gameObject.activeSelf)
                {
                    if (gm.numOfStepsToMove != 0)
                    {
                        canMove = true;
                        gm.rolleddice.hasMoved = true;
                        MoveSteps(pathsParent.yellowPathPoints);


                    }
                    else
                    {
                        Debug.Log("numOfSetpsToMove is zero, there is a problem with the dice");
                    }

                }
                else
                {
                    Debug.Log("rolled dice is " + gm.rolleddice.gameObject.name + "" +
                        "hasRolled value:" + gm.rolleddice.hasRolled + "" +
                        "hasMoved value:" + gm.rolleddice.hasMoved + "" +
                        "yellowice activeSelf value:" + yellowDice.gameObject.activeSelf);
                }
            }
        }


    }
}
