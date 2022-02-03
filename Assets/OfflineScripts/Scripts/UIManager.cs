using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject GamePanel;

    public void Game1()
    {
        GameManager.gm.totalPlayersCanPlay = 2; 
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
        Game1Setting();
    }
    public void Game2()
    {
        GameManager.gm.totalPlayersCanPlay = 3;
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
        Game2Setting();
    }
    public void Game3()
    {
        GameManager.gm.totalPlayersCanPlay = 4;
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void Game4()
    {
        GameManager.gm.totalPlayersCanPlay = 1;
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
        Game1Setting();
    }

    void Game1Setting()
    {
        HidePlayers(GameManager.gm.greenPlayerPiece);
        HidePlayers(GameManager.gm.bluePlayerPiece);
    }

    void Game2Setting()
    {
        HidePlayers(GameManager.gm.bluePlayerPiece);
    }

    void HidePlayers(PlayerPiece[] PlayerPieces_)
    {
        for(int i = 0; i< PlayerPieces_.Length; i++)
        {
            PlayerPieces_[i].gameObject.SetActive(false); 
        }
    }
}
