using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


namespace com.impactionalGames.LudoInu
{
    public class OfflineManager : MonoBehaviour
    {
        //singleton
        public static OfflineManager instance;


        

        private void Awake()
        {
            if(instance == null)
            instance = this;
        }


       

        private void Start()
        {
           selectTypeOfGame(typeOfGame.selctionMenu);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gametype != typeOfGame.selctionMenu)
                {

                    selectTypeOfGame(typeOfGame.selctionMenu);
                }

                else 
                {
                    SceneManager.UnloadScene(selfSceneName);
                    mainMenuManager.Instance.updateMainMenuState(mainMenuState.initial);
                }



            }
        }
        //vars

        [Header("Panels")]
        public GameObject selctionMenu;
        public GameObject twoPlayerColorSelctionMenu;
        public bool gameStarted = false;


        [Header("Scene Names")]
        public string offlineBotSceneName;
        public string GameMenuSceneName;
        public string selfSceneName;

        public static event Action<typeOfGame> onTypeOfGameSelected;
        public typeOfGame gametype;

        public void selectTypeOfGame(typeOfGame newtype)
        {
            gametype = newtype;

            switch (gametype)
            {
                case typeOfGame.selctionMenu:
                    onSelectionMenu();
                    break;
                case typeOfGame.twoPlayer:
                    onSelctionOfTwoPlayerGame();
                    break;
               
                case typeOfGame.fourPlayer:
                    onSelctionOfFourPlayerGame();
                    break;
                case typeOfGame.computer:
                    onSelctionOfComputerGame();
                    break;
                
            }

            onTypeOfGameSelected?.Invoke(gametype);
        }

        private void onSelectionMenu()
        {
            selctionMenu.SetActive(true);
            twoPlayerColorSelctionMenu.SetActive(false);
        }

        private void onSelctionOfTwoPlayerGame()
        {
            selctionMenu.SetActive(false);
            twoPlayerColorSelctionMenu.SetActive(true);
        }

        

        private void onSelctionOfFourPlayerGame()
        {
            selctionMenu.SetActive(false);
            twoPlayerColorSelctionMenu.SetActive(false);
        }

        private void onSelctionOfComputerGame()
        {
            SceneManager.LoadScene(offlineBotSceneName);
        }

        public void TwoPlayerGameChoose()
        {
            selectTypeOfGame(typeOfGame.twoPlayer);
        }

        public void FourPlayerGameChoose()
        {
            selectTypeOfGame(typeOfGame.fourPlayer);
        }

        public void ComputerGameChoose()
        {
            selectTypeOfGame(typeOfGame.computer);
        }


    }

    public enum typeOfGame
    {
        selctionMenu,
        twoPlayer,
        fourPlayer,
        computer

    }
}
