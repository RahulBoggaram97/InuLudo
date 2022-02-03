using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] int numberGot;
    [SerializeField] GameObject rollingDiceAnim;
    [SerializeField] SpriteRenderer numberedSpriteHolder;
    [SerializeField] Sprite[] numberedSprites;


    Coroutine generaterandomNumberOnDice_Coroutine;
    public int outPieces;

    public PathObjectsParent pathParent;
    PlayerPiece[] currentplayerpieces;
    PathPoints[] pathPointToMoveOn_;
    Coroutine moveSteps_Coroutine;
    PlayerPiece outPlayerPiece;

    private void Awake()
    {
        pathParent = FindObjectOfType<PathObjectsParent>();
    }

    private void OnMouseDown()
    {
        generaterandomNumberOnDice_Coroutine = StartCoroutine(RollingDices());
    }

    IEnumerator RollingDices()
    {
        yield return new WaitForEndOfFrame();
        if (GameManager.gm.canDiceRoll)
        {
            GameManager.gm.canDiceRoll = false;
            numberedSpriteHolder.gameObject.SetActive(false);
            rollingDiceAnim.SetActive(true);
            yield return new WaitForSeconds(1f);
            numberGot = Random.Range(0, 6);
            numberedSpriteHolder.sprite = numberedSprites[numberGot];
            numberGot += 1;

            GameManager.gm.numOfStepsToMove = numberGot;
            GameManager.gm.rolledDice = this;

            numberedSpriteHolder.gameObject.SetActive(true);
            rollingDiceAnim.SetActive(false);
            yield return new WaitForEndOfFrame();

            int numberedGot = GameManager.gm.numOfStepsToMove;
            if (PlayerCanNotMove())
            {
                yield return new WaitForSeconds(0.5f);

                if (numberedGot != 6) { GameManager.gm.transferDice = true; }
                else { GameManager.gm.selfDice = true; }
            }
            else
            {


                if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[0]) { outPieces = GameManager.gm.yellowOutPlayers; }
                else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[1]) { outPieces = GameManager.gm.greenOutPlayers; }
                else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[2]) { outPieces = GameManager.gm.redOutPlayers; }
                else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[3]) { outPieces = GameManager.gm.blueOutPlayers; }

                if (outPieces == 0 && numberedGot != 6)
                {
                    yield return new WaitForSeconds(0.5f);
                    GameManager.gm.transferDice = true;
                }
                else
                {
                    if (outPieces == 0 && numberedGot == 6)
                    {
                        MakePlayerReadyToMove(0);
                    }
                    else if (outPieces == 1 && numberedGot != 6 && GameManager.gm.CanPlayerMove)
                    {
                        int playerPiecePosition = CheckOutPlayer();
                        if (playerPiecePosition >= 0)
                        {
                            GameManager.gm.CanPlayerMove = false;
                            moveSteps_Coroutine = StartCoroutine(MoveSteps_Enum(playerPiecePosition));
                        }
                        else
                        {
                            yield return new WaitForSeconds(0.5f);

                            if (numberedGot != 6) { GameManager.gm.transferDice = true; }
                            else { GameManager.gm.selfDice = true; }
                        }
                    }
                }

                // if (GameManager.gm.numOfStepsToMove != 6 && outPieces == 0)
                // {
                //     GameManager.gm.canDiceRoll = true;
                //     GameManager.gm.selfDice = false;
                //     GameManager.gm.transferDice = true;

                //    yield return new WaitForSeconds(0.8f);
                //GameManager.gm.RollingDiceManager();
                //}
            }

            GameManager.gm.RollingDiceManager();

            if (generaterandomNumberOnDice_Coroutine != null)
            {
                StopCoroutine(RollingDices());
            }
        }
    }

    int CheckOutPlayer()
    {
        if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[0]) { currentplayerpieces = GameManager.gm.yellowPlayerPiece; pathPointToMoveOn_ = pathParent.yellowPathPoints; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[1]) { currentplayerpieces = GameManager.gm.greenPlayerPiece; pathPointToMoveOn_ = pathParent.greenPathPoints; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[2]) { currentplayerpieces = GameManager.gm.redPlayerPiece; pathPointToMoveOn_ = pathParent.redPathPoints; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[3]) { currentplayerpieces = GameManager.gm.bluePlayerPiece; pathPointToMoveOn_ = pathParent.bluePathPoints; }

        for (int i = 0; i < currentplayerpieces.Length; i++)
        {
            if (currentplayerpieces[i].isReady && isPathPointsAvailableToMove(GameManager.gm.numOfStepsToMove, currentplayerpieces[i].numberOfStepsAlreadyMoved, pathPointToMoveOn_))
            {
                return i;
            }
        }
        return -1;
    }

    public bool PlayerCanNotMove()
    {
        if (outPieces > 0)
        {
            bool canNotMove = false;
            if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[0]) { currentplayerpieces = GameManager.gm.yellowPlayerPiece; pathPointToMoveOn_ = pathParent.yellowPathPoints; }
            else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[1]) { currentplayerpieces = GameManager.gm.yellowPlayerPiece; pathPointToMoveOn_ = pathParent.yellowPathPoints; }
            else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[2]) { currentplayerpieces = GameManager.gm.yellowPlayerPiece; pathPointToMoveOn_ = pathParent.yellowPathPoints; }
            else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[3]) { currentplayerpieces = GameManager.gm.yellowPlayerPiece; pathPointToMoveOn_ = pathParent.yellowPathPoints; }

            for (int i = 0; i < currentplayerpieces.Length; i++)
            {
                if (currentplayerpieces[i].isReady)
                {
                    if (isPathPointsAvailableToMove(GameManager.gm.numOfStepsToMove, currentplayerpieces[i].numberOfStepsAlreadyMoved, pathPointToMoveOn_))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!canNotMove) { canNotMove = true; }
                }


            }
            if (canNotMove)
            {
                return true;
            }
        }
        return false;
    }
    bool isPathPointsAvailableToMove(int numOfStepsToMove_, int numOfstepsAlreadyMoved_, PathPoints[] pathPointToMove_)
    {
        if (numOfStepsToMove_ == 0)
        {
            return false; ;
        }
        int leftNumOfpathPoints = pathPointToMove_.Length - numOfstepsAlreadyMoved_;
        if (leftNumOfpathPoints >= numOfStepsToMove_)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MakePlayerReadyToMove(int outPlayer)
    {
        if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[0]) { outPlayerPiece = GameManager.gm.yellowPlayerPiece[outPlayer]; pathPointToMoveOn_ = pathParent.yellowPathPoints; GameManager.gm.yellowOutPlayers += 1; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[1]) { outPlayerPiece = GameManager.gm.greenPlayerPiece[outPlayer]; pathPointToMoveOn_ = pathParent.greenPathPoints; GameManager.gm.greenOutPlayers += 1; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[2]) { outPlayerPiece = GameManager.gm.redPlayerPiece[outPlayer]; pathPointToMoveOn_ = pathParent.redPathPoints; GameManager.gm.redOutPlayers += 1; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[3]) { outPlayerPiece = GameManager.gm.bluePlayerPiece[outPlayer]; pathPointToMoveOn_ = pathParent.bluePathPoints; GameManager.gm.blueOutPlayers += 1; }

        outPlayerPiece.isReady = true;
        outPlayerPiece.transform.position = pathPointToMoveOn_[0].transform.position;
        outPlayerPiece.numberOfStepsAlreadyMoved = 1;

        outPlayerPiece.previousPathPoint = pathPointToMoveOn_[0];
        outPlayerPiece.currentPathPoint = pathPointToMoveOn_[0];
        GameManager.gm.RemovePathPoint(outPlayerPiece.previousPathPoint);
        GameManager.gm.AddPathPoint(outPlayerPiece.currentPathPoint);

        GameManager.gm.canDiceRoll = true;
        GameManager.gm.selfDice = true;
        GameManager.gm.transferDice = false;
        GameManager.gm.numOfStepsToMove = 0;
    }
    IEnumerator MoveSteps_Enum(int movePlayer)
    {
        if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[0]) { outPlayerPiece = GameManager.gm.yellowPlayerPiece[movePlayer]; pathPointToMoveOn_ = pathParent.yellowPathPoints; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[1]) { outPlayerPiece = GameManager.gm.greenPlayerPiece[movePlayer]; pathPointToMoveOn_ = pathParent.greenPathPoints; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[2]) { outPlayerPiece = GameManager.gm.redPlayerPiece[movePlayer]; pathPointToMoveOn_ = pathParent.redPathPoints; }
        else if (GameManager.gm.rolledDice == GameManager.gm.manageRollingDice[3]) { outPlayerPiece = GameManager.gm.bluePlayerPiece[movePlayer]; pathPointToMoveOn_ = pathParent.bluePathPoints; }

        GameManager.gm.transferDice = false;
        yield return new WaitForSeconds(0.5f);
        int numOfStepsToMove = GameManager.gm.numOfStepsToMove;




        for (int i = outPlayerPiece.numberOfStepsAlreadyMoved; i < (outPlayerPiece.numberOfStepsAlreadyMoved + numOfStepsToMove); i++)
        {
            if (isPathPointsAvailableToMove(numOfStepsToMove, outPlayerPiece.numberOfStepsAlreadyMoved, pathPointToMoveOn_))
            {
                outPlayerPiece.transform.position = pathPointToMoveOn_[i].transform.position;

                yield return new WaitForSeconds(0.5f);
            }
        }


        if (isPathPointsAvailableToMove(numOfStepsToMove, outPlayerPiece.numberOfStepsAlreadyMoved, pathPointToMoveOn_))
        {
            //GameManager.gm.transferDice = false;
            outPlayerPiece.numberOfStepsAlreadyMoved += numOfStepsToMove;
            //GameManager.gm.numOfStepsToMove = 0;

            GameManager.gm.RemovePathPoint(outPlayerPiece.previousPathPoint);
            outPlayerPiece.previousPathPoint.RemovePlayerPiece(outPlayerPiece);
            outPlayerPiece.currentPathPoint = pathPointToMoveOn_[outPlayerPiece.numberOfStepsAlreadyMoved - 1];

            if (outPlayerPiece.currentPathPoint.AddPlayerPiece(outPlayerPiece))
            {
                if (outPlayerPiece.numberOfStepsAlreadyMoved == 57)
                {
                    GameManager.gm.selfDice = true;
                }
                else
                {
                    if (GameManager.gm.numOfStepsToMove != 6)
                    {
                        //GameManager.gm.selfDice = false;
                        GameManager.gm.transferDice = true;
                    }
                    else
                    {
                        GameManager.gm.selfDice = true;
                        // GameManager.gm.transferDice = false;
                    }
                }
            }
            else
            {
                GameManager.gm.selfDice = true;
            }


            GameManager.gm.AddPathPoint(outPlayerPiece.currentPathPoint);
            outPlayerPiece.previousPathPoint = outPlayerPiece.currentPathPoint;

            GameManager.gm.numOfStepsToMove = 0;

        }
        GameManager.gm.CanPlayerMove = true;
        GameManager.gm.RollingDiceManager();

        if (moveSteps_Coroutine != null)
        {
            StopCoroutine("moveSteps_Coroutine");
        }
    }
}
