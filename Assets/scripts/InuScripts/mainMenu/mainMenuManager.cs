using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoInu
{
    public enum mainMenuState
    {
        loading,
        initial,
        online,
        withFriends,
        offline, 
        computerbot
    }

    public class mainMenuManager : MonoBehaviour
    {
        public static mainMenuManager instance;
        public static mainMenuState state;
        public static event Action<mainMenuState> onMenuStateChanged;

        [Header("Objects to be decativated when loading other scenes")]
        public GameObject MainMenuCanvas;
        public GameObject _camera;
        public GameObject eventSystem;

        [Header("Panles")]
     

        public GameObject loadingPanel;
        public GameObject mainMenuPanel;
        public GameObject OnlinePanel;
        public GameObject WithFriendsPanel;



        [Header("Scenes")]
        public string offlineSceneName;
        public string walletUiSceneName;
        public string botOfflineSceneName;


        private void Awake()
        {
            
            if(instance == null)
            instance = this;
            SceneManager.LoadSceneAsync(walletUiSceneName, LoadSceneMode.Additive);



        }

        

        private void Start()
        {
            updateMainMenuState(mainMenuState.loading);
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                updateMainMenuState(mainMenuState.initial);
            }
        }

        public void updateMainMenuState(mainMenuState newState)
        {
            state = newState;

            switch (state)
            {
                case mainMenuState.loading:
                    handleLoadingState();
                    break;
                case mainMenuState.initial:
                    handleIntialState();
                    break;
                case mainMenuState.online:
                    handleOnlineState();
                    break;
                case mainMenuState.withFriends:
                    handleWithFriendsState();
                    break;
                case mainMenuState.offline:
                    handleOfflineState();
                    break;
                case mainMenuState.computerbot:
                    handleBotOfflineState();
                    break;
            }

            onMenuStateChanged?.Invoke(state);
        }

       

        private void handleLoadingState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);
            
            loadingPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(false);
        }

        private void handleIntialState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);

            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(false);
        }

        private void handleOnlineState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);

            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(true);
            WithFriendsPanel.SetActive(false);
            
        }

        private void handleWithFriendsState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);


            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(true);
            
        }

        private void handleOfflineState()
        {
          SceneManager.LoadSceneAsync(offlineSceneName, LoadSceneMode.Additive);
            MainMenuCanvas.SetActive(false);
            _camera.SetActive(false);
            eventSystem.SetActive(false);

        }


        private void handleBotOfflineState()
        {
            SceneManager.LoadScene(botOfflineSceneName);
            
        }

        public void LoadingOnClick()
        {
            mainMenuManager.instance.updateMainMenuState(mainMenuState.loading);
        }

        public void IntialOnClick()
        {
            mainMenuManager.instance.updateMainMenuState(mainMenuState.initial);
        }

        public void OnlineOnClick()
        {
            mainMenuManager.instance.updateMainMenuState(mainMenuState.online);
        }

        public void WithFriendsOnClick()
        {
            mainMenuManager.instance.updateMainMenuState(mainMenuState.withFriends);
        }

        public void OfflineOnClick()
        {
            mainMenuManager.instance.updateMainMenuState(mainMenuState.offline);
        }

        public void BotOfflineOnClick()
        {
            mainMenuManager.instance.updateMainMenuState(mainMenuState.computerbot);
        }


    }


}
