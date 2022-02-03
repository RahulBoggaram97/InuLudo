using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int numOfStepsToMove;
    public RollingDice rolledDice;
    public bool CanPlayerMove = true;
   

    List<PathPoints> playerOnPathPointsList = new List<PathPoints>();

    public bool canDiceRoll = true;
    public bool transferDice = false;
    public bool selfDice = false;

    public int yellowOutPlayers;
    public int greenOutPlayers;
    public int redOutPlayers;
    public int blueOutPlayers;

    public int yellowCompletedPlayers;
    public int greenCompletedPlayers;
    public int redCompletedPlayers;
    public int blueCompletedPlayers;

    public RollingDice[] manageRollingDice;

    public PlayerPiece[] yellowPlayerPiece; 
    public PlayerPiece[] greenPlayerPiece; 
    public PlayerPiece[] redPlayerPiece; 
    public PlayerPiece[] bluePlayerPiece;

    public int totalPlayersCanPlay;

    private void Awake()
    {
        gm = this;
    }

    public void AddPathPoint(PathPoints pathPoint_)
    {
        playerOnPathPointsList.Add(pathPoint_);
    }
    public void RemovePathPoint(PathPoints pathPoint_)
    {
        if (playerOnPathPointsList.Contains(pathPoint_))
        {
            playerOnPathPointsList.Remove(pathPoint_);
        }

        else
        {
            Debug.Log("Path point not found");
        }
    }

    public void RollingDiceManager()
    {
        //int nextDice;
        if(GameManager.gm.transferDice)
        {
            if (GameManager.gm.numOfStepsToMove != 6)
            {
                ShiftDice();
            }
            //ShiftDice();
            //for(int i = 0; i < 4; i++)
            //{
            //    if(i==3) { nextDice = 0; } else { nextDice = i + 1; } 
            //    if(GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[i])
            //    {
            //        GameManager.gm.manageRollingDice[i].gameObject.SetActive(false);
            //        GameManager.gm.manageRollingDice[nextDice].gameObject.SetActive(true);
            //    }
            //}
            GameManager.gm.canDiceRoll = true;
        }
        else
        {
            if(GameManager.gm.selfDice)
            {
                GameManager.gm.selfDice = false;
                GameManager.gm.canDiceRoll = true;
            }
        }
    }

    void ShiftDice()
    {
        int nextDice;
        if (GameManager.gm.totalPlayersCanPlay == 1)
        {

        }
        else if(GameManager.gm.totalPlayersCanPlay == 2)
        {
            if(GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[0])
            {
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(false);
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(true);
            }
            else
            {
                GameManager.gm.manageRollingDice[0].gameObject.SetActive(true);
                GameManager.gm.manageRollingDice[2].gameObject.SetActive(false);
            }
        }
        else if (GameManager.gm.totalPlayersCanPlay == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 2) { nextDice = 0; } else { nextDice = i + 1; }
                if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[i])
                {
                    GameManager.gm.manageRollingDice[i].gameObject.SetActive(false);
                    GameManager.gm.manageRollingDice[nextDice].gameObject.SetActive(true);
                }
            }
        }
        else 
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 3) { nextDice = 0; } else { nextDice = i + 1; }
                if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[i])
                {
                    GameManager.gm.manageRollingDice[i].gameObject.SetActive(false);
                    GameManager.gm.manageRollingDice[nextDice].gameObject.SetActive(true);
                }
            }
        }
    }
}
