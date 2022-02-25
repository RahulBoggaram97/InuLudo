using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{
    public class playerPieceBotOffine : MonoBehaviour
    {
        public bool isReady;
        public bool canMove;
        public bool moveNow;
        public int numberOfStepsAlreadyMoved;
        public float speed = 100f;

        public pathObjectParentBotOffline pathsParent;
        public pathPointsBotOffline previousPathPoint;
        public pathPointsBotOffline currentPathPoint;

        Coroutine moveSteps_Coroutine;



        private void Awake()
        {
            pathsParent = FindObjectOfType<pathObjectParentBotOffline>();
        }

        public void MoveSteps(pathPointsBotOffline[] pathPointsToMoveOn_)
        {
            moveSteps_Coroutine = StartCoroutine(MoveSteps_Enum(pathPointsToMoveOn_));


        }


        public void MakePlayerReadyToMove(pathPointsBotOffline[] pathPointsToMoveOn_)
        {
            isReady = true;
            transform.position = pathPointsToMoveOn_[0].transform.position;
            numberOfStepsAlreadyMoved = 1;

            previousPathPoint = pathPointsToMoveOn_[0];
            currentPathPoint = pathPointsToMoveOn_[0];






            gameManagerBotOffline.gm.RemovePathPoint(previousPathPoint);
            gameManagerBotOffline.gm.AddPathPoint(currentPathPoint);

            gameManagerBotOffline.gm.canDiceRoll = true;
            gameManagerBotOffline.gm.selfDice = true;
            gameManagerBotOffline.gm.transferDice = false;
            gameManagerBotOffline.gm.rolleddice.hasMoved = true;
            gameManagerBotOffline.gm.RollingDiceManager();

            Debug.Log("tried to ready the player");
        }




        IEnumerator MoveSteps_Enum(pathPointsBotOffline[] pathPointsToMoveOn_)
        {
            yield return new WaitForSeconds(0.5f);
            int numOfStepsToMove = gameManagerBotOffline.gm.numOfStepsToMove;


            if (canMove)
            {
                for (int i = numberOfStepsAlreadyMoved; i < (numberOfStepsAlreadyMoved + numOfStepsToMove); i++)
                {
                    if (isPathPointsAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
                    {
                        transform.localScale = new Vector3(0.11f, 0.12f, 0.11f);
                        yield return new WaitForSeconds(0.025f);

                        transform.localScale = new Vector3(0.11f, 0.13f, 0.12f);
                        yield return new WaitForSeconds(0.025f);

                        transform.localScale = new Vector3(0.12f, 0.14f, 0.13f);
                        yield return new WaitForSeconds(0.025f);

                        transform.localScale = new Vector3(0.12f, 0.15f, 0.14f);
                        yield return new WaitForSeconds(0.025f);


                        transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                        transform.position = pathPointsToMoveOn_[i].transform.position;


                        transform.localScale = new Vector3(0.15f, 0.14f, 0.14f);
                        yield return new WaitForSeconds(0.025f);

                        transform.localScale = new Vector3(0.14f, 0.14f, 0.13f);
                        yield return new WaitForSeconds(0.025f);

                        transform.localScale = new Vector3(0.13f, 0.12f, 0.12f);
                        yield return new WaitForSeconds(0.025f);


                        transform.localScale = new Vector3(0.11f, 0.11f, 0.11f);
                        yield return new WaitForSeconds(0.025f);

                        transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);

                        yield return new WaitForSeconds(0.1f);



                    }
                }


            }

            if (isPathPointsAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
            {
                gameManagerBotOffline.gm.transferDice = false;
                numberOfStepsAlreadyMoved += numOfStepsToMove;
                //GameManager.gm.numOfStepsToMove = 0;




                gameManagerBotOffline.gm.RemovePathPoint(previousPathPoint);
                if (previousPathPoint != null)
                {
                    previousPathPoint.RemovePlayerPiece(this);
                }
                currentPathPoint = pathPointsToMoveOn_[numberOfStepsAlreadyMoved - 1];

                if (currentPathPoint.AddPlayerPiece(this))
                {
                    if (numberOfStepsAlreadyMoved == 57)
                    {
                        gameManagerBotOffline.gm.selfDice = true;
                    }
                    else
                    {
                        if (gameManagerBotOffline.gm.numOfStepsToMove != 6)
                        {
                            //GameManager.gm.selfDice = false;
                            gameManagerBotOffline.gm.transferDice = true;

                        }
                        else
                        {
                            gameManagerBotOffline.gm.selfDice = true;
                            // GameManager.gm.transferDice = false;
                        }
                    }
                }
                else
                {
                    gameManagerBotOffline.gm.selfDice = true;
                }



                gameManagerBotOffline.gm.AddPathPoint(currentPathPoint);
                previousPathPoint = currentPathPoint;

                //GameManager.gm.numOfStepsToMove = 0;

            }
            gameManagerBotOffline.gm.CanPlayerMove = true;
            gameManagerBotOffline.gm.RollingDiceManager();

            if (moveSteps_Coroutine != null)
            {
                StopCoroutine(moveSteps_Coroutine);
            }





        }




        bool isPathPointsAvailableToMove(int numOfStepsToMove_, int numOfstepsAlreadyMoved_, pathPointsBotOffline[] pathPointsToMoveOn_)
        {
            //if (numOfStepsToMove_ == 0)
            //{
            //    return false; ;
            // }
            int leftNumOfpathPoints = pathPointsToMoveOn_.Length - numOfstepsAlreadyMoved_;
            if (leftNumOfpathPoints >= numOfStepsToMove_)
            {
                return true;
            }
            return false;
        }
    }
}
