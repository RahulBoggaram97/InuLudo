using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{
    public class greenPlayerOffline : playerPeiceOffline
    {
        public gameManagerOffline gm;
        public rollinDiceOffline greenDice;
        public int individualScore;



        private void OnMouseDown()
        {
            movePiece();

        }






        void movePiece()
        {
            if (!isReady)
            {
                if (gm.rolleddice == greenDice && gm.numOfStepsToMove == 6)
                {
                    
                    gm.greenOutPlayers += 1;
                    MakePlayerReadyToMove(pathsParent.greenPathPoints);
                    gm.numOfStepsToMove = 0;
                    
                    
                    return;
                }
            }
            else
            {

                if (gm.rolleddice == greenDice && gm.rolleddice.hasRolled && !gm.rolleddice.hasMoved && greenDice.gameObject.activeSelf)
                {
                    if (gm.numOfStepsToMove != 0)
                    {
                        canMove = true;
                        gm.rolleddice.hasMoved = true;
                        MoveSteps(pathsParent.greenPathPoints);


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
                        "greenice activeSelf value:" + greenDice.gameObject.activeSelf);
                }
            }
        }


    }
}
