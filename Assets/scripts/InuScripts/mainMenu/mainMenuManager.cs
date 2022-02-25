using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoInu
{
    public class mainMenuManager : MonoBehaviour
    {
        public static mainMenuManager instance;
        public static mainMenuState state;
        public static event Action<mainMenuState> onMenuStateChanged;


        [Header("Panles")]
        public GameObject loadingPanel;
        public GameObject mainMenuPanel;
        public GameObject OnlinePanel;
        public GameObject WithFriendsPanel;


        [Header("Scenes")]
        public string offlineSceneName;
        public string walletUiSceneName;

        private void Awake()
        {
            if(instance == null)
            instance = this;
            
        }

        private void Start()
        {
            updateMainMenuState(mainMenuState.loading);
            SceneManager.LoadSceneAsync(walletUiSceneName, LoadSceneMode.Additive);
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
            }

            onMenuStateChanged?.Invoke(state);
        }

        private void handleLoadingState()
        {
            loadingPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(false);
        }

        private void handleIntialState()
        {
            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(false);

            

            
            


        }

        private void handleOnlineState()
        {
            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(true);
            WithFriendsPanel.SetActive(false);
            
        }

        private void handleWithFriendsState()
        {
            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(true);
            
        }

        private void handleOfflineState()
        {
           SceneManager.LoadScene(offlineSceneName);
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


    }

    public enum mainMenuState
    {
        loading,
        initial,
        online,
        withFriends,
        offline
    }
}
