using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    PathPoints[] pathpointToMoveon_;
    public PathObjectsParent pathObjectParent;
    public List<PlayerPiece> playerPieces = new List<PlayerPiece>();

     void Start()
    {
        pathObjectParent = GetComponentInParent<PathObjectsParent>();
    }

    public bool AddPlayerPiece(PlayerPiece playerPiece_)
    {
        if(this.name == "CentreHomePoint") { Completed(playerPiece_); }
        if (this.name != "PathPoints" && this.name != "PathPoints (8)" && this.name != "PathPoints (13)" && this.name != "PathPoints (21)" && this.name != "PathPoints (26)" && this.name != "PathPoints (34)" && this.name != "PathPoints (39)" && this.name != "PathPoints (47)" && this.name != "CentreHomePoint")
        {
            if (playerPieces.Count == 1)
            {
                string prePlayerPieceName = playerPieces[0].name;
                string curPlayerPieceName = playerPiece_.name;
                curPlayerPieceName = curPlayerPieceName.Substring(0, curPlayerPieceName.Length - 4);

                if (!prePlayerPieceName.Contains(curPlayerPieceName))
                {
                    playerPieces[0].isReady = false;

                    revertOnStart(playerPieces[0]);


                    playerPieces[0].numberOfStepsAlreadyMoved = 0;
                    RemovePlayerPiece(playerPieces[0]);
                    playerPieces.Add(playerPiece_);

                    return false;
                }
            }
        }
        addPlayer(playerPiece_);
        return true;
    }

    void revertOnStart(PlayerPiece playerPiece_)
    {
        //if (name.Contains("Yellow")) { GameManager.gm.yellowOutPlayers -= 1; pathpointToMoveon_ = pathObjectParent.yellowPathPoints; }
       // else if (name.Contains("Green")) { GameManager.gm.greenOutPlayers -= 1; pathpointToMoveon_ = pathObjectParent.greenPathPoints; }
       // else if (name.Contains("Red")) { GameManager.gm.redOutPlayers -= 1; pathpointToMoveon_ = pathObjectParent.redPathPoints; }
      //  else if (name.Contains("Blue")) { GameManager.gm.blueOutPlayers -= 1; pathpointToMoveon_ = pathObjectParent.bluePathPoints; }

       // for (int i = playerPiece_.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
        //{
       //     playerPiece_.transform.position = pathpointToMoveon_[i].transform.position;
       //     yield return new WaitForSeconds(0.03f);
       // }

        playerPiece_.transform.position = pathObjectParent.BasePoints[BasePointPosition(playerPiece_.name)].transform.position;
    }

    int BasePointPosition(string name)
    {
        if (name.Contains("Yellow")) { GameManager.gm.yellowOutPlayers -= 1; }
        else if (name.Contains("Green")) { GameManager.gm.greenOutPlayers -= 1; }
        else if (name.Contains("Red")) { GameManager.gm.redOutPlayers -= 1; }
        else if (name.Contains("Blue")) { GameManager.gm.blueOutPlayers -= 1; }


        for (int i = 0; i< pathObjectParent.BasePoints.Length; i++)
        {
            if(pathObjectParent.BasePoints[i].name == name)
            {
                return i;
            }
        }
        return -1;
    }
    

    void addPlayer(PlayerPiece  playerPiece_ )
    {
        playerPieces.Add(playerPiece_);
    }

    public void RemovePlayerPiece(PlayerPiece playerPiece_)
    {
        if(playerPieces.Contains(playerPiece_))
        {
            playerPieces.Remove(playerPiece_);
        }
    }

    private void Completed(PlayerPiece playerPiece_)
    {
        if (name.Contains("Yellow")) { GameManager.gm.yellowCompletedPlayers += 1; GameManager.gm.yellowOutPlayers -= 1; if (GameManager.gm.yellowCompletedPlayers == 4) { ShowCelebration(); } }
        else if (name.Contains("Green")) { GameManager.gm.greenCompletedPlayers += 1; GameManager.gm.greenOutPlayers -= 1; if (GameManager.gm.greenCompletedPlayers == 4) { ShowCelebration(); } }
        else if (name.Contains("Red")) { GameManager.gm.redCompletedPlayers += 1; GameManager.gm.redOutPlayers -= 1; if (GameManager.gm.redCompletedPlayers == 4) { ShowCelebration(); } }
        else if (name.Contains("Blue")) { GameManager.gm.blueCompletedPlayers += 1; GameManager.gm.blueOutPlayers -= 1; if (GameManager.gm.blueCompletedPlayers == 4) { ShowCelebration(); } }

    }

    void ShowCelebration()
    {

    }
}
