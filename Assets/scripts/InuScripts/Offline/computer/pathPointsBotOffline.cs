using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{
    public class pathPointsBotOffline : MonoBehaviour
    {
        pathPointsBotOffline[] pathpointToMoveon_;
        public pathObjectParentBotOffline pathObjectParent;
        public List<playerPieceBotOffine> playerPieces = new List<playerPieceBotOffine>();

        void Start()
        {
            pathObjectParent = GetComponentInParent<pathObjectParentBotOffline>();
        }

        public bool AddPlayerPiece(playerPieceBotOffine playerPiece_)
        {
            if (this.name == "CentreHomePoint") { Completed(playerPiece_); }
            else if (this.name != "pathpointsBotOffline" && this.name != "pathpointsBotOffline (8)" && this.name != "pathpointsBotOffline (13)" && this.name != "pathpointsBotOffline (21)" && this.name != "pathpointsBotOffline (26)" && this.name != "pathpointsBotOffline (34)" && this.name != "pathpointsBotOffline (39)" && this.name != "pathpointsBotOffline (47)" && this.name != "CentreHomePoint")
            {
                if (playerPieces.Count == 1)
                {
                    string prePlayerPieceName = playerPieces[0].name;
                    string curPlayerPieceName = playerPiece_.name;
                    curPlayerPieceName = curPlayerPieceName.Substring(0, curPlayerPieceName.Length - 4);

                    if (!prePlayerPieceName.Contains(curPlayerPieceName))
                    {


                        StartCoroutine(revertOnStart(playerPieces[0]));


                        playerPieces[0].numberOfStepsAlreadyMoved = 0;


                        RemovePlayerPiece(playerPieces[0]);
                        playerPieces.Add(playerPiece_);



                        ////playerpiece.dice.setScore(-previousPlayer.indivdualScore);
                        return false;
                    }

                    else if (prePlayerPieceName.Contains(curPlayerPieceName))
                    {
                        //if they are of same colour we lower the scale and offsets them a bit
                        playerPieces[0].gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);


                        playerPieces[0].transform.position = playerPieces[0].transform.position + new Vector3(0.07f, 0f, 0f);

                        playerPiece_.gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);


                        playerPiece_.transform.position = playerPieces[0].transform.position + new Vector3(-0.14f, 0f, 0f);


                        addPlayer(playerPiece_);
                        return true;
                    }
                }


            }
            addPlayer(playerPiece_);
            return true;
        }

        IEnumerator revertOnStart(playerPieceBotOffine playerPiece_)
        {
            if (playerPiece_.name.Contains("Yellow"))
            {
                gameManagerBotOffline.gm.yellowOutPlayers -= 1;
                pathpointToMoveon_ = pathObjectParent.yellowPathPoints;
            }
            else if (playerPiece_.name.Contains("Green"))
            {
                gameManagerBotOffline.gm.greenOutPlayers -= 1;
                pathpointToMoveon_ = pathObjectParent.greenPathPoints;
            }
            else if (playerPiece_.name.Contains("Red"))
            {
                gameManagerBotOffline.gm.redOutPlayers -= 1;
                pathpointToMoveon_ = pathObjectParent.redPathPoints;
            }
            else if (playerPiece_.name.Contains("Blue"))
            {
                gameManagerBotOffline.gm.blueOutPlayers -= 1;
                pathpointToMoveon_ = pathObjectParent.bluePathPoints;
            }

            for (int i = playerPiece_.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
            {
                playerPiece_.transform.position = pathpointToMoveon_[i].transform.position;
                yield return new WaitForSeconds(0.03f);
            }

            playerPiece_.transform.position = pathObjectParent.BasePoints[BasePointPosition(playerPiece_)].transform.position;
            playerPiece_.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
        }

        int BasePointPosition(playerPieceBotOffine playerPiece_)
        {
            if (playerPiece_.name.Contains("Yellow"))
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (pathObjectParent.BasePoints[i].playerPieces.Count == 0)
                    {
                        pathObjectParent.BasePoints[i].addPlayer(playerPiece_);
                        return i;
                    }
                }
            }
            else if (playerPiece_.name.Contains("Green"))
            {
                for (int i = 4; i <= 7; i++)
                {
                    if (pathObjectParent.BasePoints[i].playerPieces.Count == 0)
                    {
                        pathObjectParent.BasePoints[i].addPlayer(playerPiece_);
                        return i;
                    }
                }
            }
            else if (playerPiece_.name.Contains("Red"))
            {
                for (int i = 8; i <= 11; i++)
                {
                    if (pathObjectParent.BasePoints[i].playerPieces.Count == 0)
                    {
                        pathObjectParent.BasePoints[i].addPlayer(playerPiece_);
                        return i;
                    }
                }
            }
            else if (playerPiece_.name.Contains("Blue"))
            {
                for (int i = 12; i <= 15; i++)
                {
                    if (pathObjectParent.BasePoints[i].playerPieces.Count == 0)
                    {
                        pathObjectParent.BasePoints[i].addPlayer(playerPiece_);
                        return i;
                    }
                }
            }

            return -1;
        }

        void addPlayer(playerPieceBotOffine playerPiece_)
        {
            playerPieces.Add(playerPiece_);
        }

        public void RemovePlayerPiece(playerPieceBotOffine playerPiece_)
        {
            if (playerPieces.Contains(playerPiece_))
            {
                playerPieces.Remove(playerPiece_);
            }
            else
            {
                return;
            }
        }




        private void Completed(playerPieceBotOffine playerPiece_)
        {
            if (playerPiece_.name.Contains("Yellow"))
            {
                gameManagerBotOffline.gm.yellowCompletedPlayers += 1;

                if (gameManagerBotOffline.gm.yellowCompletedPlayers == 4)
                {
                    manageWin();
                }
            }
            else if (playerPiece_.name.Contains("Green"))
            {
                gameManagerBotOffline.gm.greenCompletedPlayers += 1;

                if (gameManagerBotOffline.gm.greenCompletedPlayers == 4)
                {
                    manageWin();
                }
            }
            else if (playerPiece_.name.Contains("Red"))
            {
                gameManagerBotOffline.gm.redCompletedPlayers += 1;
                if (gameManagerBotOffline.gm.redCompletedPlayers == 4)
                {
                    manageWin();
                }
            }
            else if (playerPiece_.name.Contains("Blue"))
            {
                gameManagerBotOffline.gm.blueCompletedPlayers += 1;
                if (gameManagerBotOffline.gm.blueCompletedPlayers == 4)
                {
                    manageWin();
                }
            }

        }

        void manageWin()
        {
            //declare winner;
        }


    }
}

