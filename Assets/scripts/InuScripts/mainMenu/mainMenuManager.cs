using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace com.impactionalGames.LudoInu
{
    public enum mainMenuState
    {
        loading,
        backFromLobby,
        initial,
        online,
        withFriends,
        offline, 
        computerbot, 
        themes
    }

    public class mainMenuManager : genricSingletonClass<mainMenuManager>
    {
      
        public static mainMenuState state;
        public static event Action<mainMenuState> onMenuStateChanged;

        [Header("Objects to be decativated when loading other scenes")]
        public GameObject MainMenuCanvas;
        public GameObject _camera;
        public GameObject eventSystem;

        public Image backFromLobbyFadeInImage;

        [Header("Panles")]
     

        public GameObject loadingPanel;
        public GameObject mainMenuPanel;
        public GameObject OnlinePanel;
        public GameObject WithFriendsPanel;
        public GameObject themePanel;

        public GameObject extraCanvaseForBg;



        [Header("Scenes")]
        public string offlineSceneName;
        public string walletUiSceneName;
        public string botOfflineSceneName;

        [Header("DebugText")]
        public TextMeshProUGUI LoadingDebugText;

        

        public override void Awake()
        {
            base.Awake();
            
        }



        private void Start()
        {
            SceneManager.LoadSceneAsync(walletUiSceneName, LoadSceneMode.Additive);
            updateMainMenuState(mainMenuState.loading);
            
        }

        private void Update()
        {
            
                if (Input.GetKeyDown(KeyCode.Escape) && MainMenuCanvas.activeSelf == true)
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
                case mainMenuState.backFromLobby:
                    handleBackFromLobbyState();
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
                case mainMenuState.themes:
                    handleThemeState();
                    break;
            }

            onMenuStateChanged?.Invoke(state);
        }

       

        private void handleLoadingState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);
            extraCanvaseForBg.SetActive(true);
            extraCanvaseForBg.GetComponent<Canvas>().sortingOrder = 1;

            loadingPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(false);

            themePanel.SetActive(false);

            backFromLobbyFadeInImage.gameObject.SetActive(false);
            
        }


        private void handleBackFromLobbyState()
        {
            MainMenuCanvas.SetActive(true);

           
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(false);



            extraCanvaseForBg.SetActive(true);
            extraCanvaseForBg.GetComponent<Canvas>().sortingOrder = 1;

            backFromLobbyFadeInImage.gameObject.SetActive(true);

            //walletManager.Instance.updateWalletState(walletState.backFromLobby);
            loadingPanel.SetActive(true);

          
            _camera.SetActive(false);
            eventSystem.SetActive(false);
          

            StartCoroutine(setObjectActiveAfterLobbyback());
        }

        IEnumerator setObjectActiveAfterLobbyback()
        {
            yield return new WaitForFixedUpdate();

            //mainMenuManager.Instance.updateMainMenuState(mainMenuState.initial);
        }

        private void handleIntialState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);
            extraCanvaseForBg.SetActive(true);
            extraCanvaseForBg.GetComponent<Canvas>().sortingOrder = -5;

            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(false);

            themePanel.SetActive(false);

            backFromLobbyFadeInImage.gameObject.SetActive(false);

        }

        private void handleOnlineState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);
            extraCanvaseForBg.SetActive(true);
            extraCanvaseForBg.GetComponent<Canvas>().sortingOrder = -5;


            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(true);
            WithFriendsPanel.SetActive(false);

            themePanel.SetActive(false);

            backFromLobbyFadeInImage.gameObject.SetActive(false);

        }

        private void handleWithFriendsState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);
            extraCanvaseForBg.SetActive(true);
            extraCanvaseForBg.GetComponent<Canvas>().sortingOrder = -5;


            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(true);

            themePanel.SetActive(false);

            backFromLobbyFadeInImage.gameObject.SetActive(false);

        }

        private void handleOfflineState()
        {
          SceneManager.LoadSceneAsync(offlineSceneName, LoadSceneMode.Additive);
            MainMenuCanvas.SetActive(false);
            _camera.SetActive(false);
            eventSystem.SetActive(false);
            extraCanvaseForBg.SetActive(false);

            backFromLobbyFadeInImage.gameObject.SetActive(false);
        }


        private void handleBotOfflineState()
        {
            SceneManager.LoadSceneAsync(botOfflineSceneName, LoadSceneMode.Additive);
            Debug.Log("ascynfuntiongotcalled");

            MainMenuCanvas.SetActive(false);
            _camera.SetActive(false);
            eventSystem.SetActive(false);
            extraCanvaseForBg.SetActive(false);

            backFromLobbyFadeInImage.gameObject.SetActive(false);
        }

        private void handleThemeState()
        {
            MainMenuCanvas.SetActive(true);
            _camera.SetActive(true);
            eventSystem.SetActive(true);
            extraCanvaseForBg.SetActive(true);
            extraCanvaseForBg.GetComponent<Canvas>().sortingOrder = -5;

            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            OnlinePanel.SetActive(false);
            WithFriendsPanel.SetActive(false);

            themePanel.SetActive(true);

            backFromLobbyFadeInImage.gameObject.SetActive(false);

        }

        public void LoadingOnClick()
        {
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.loading);
        }

        public void IntialOnClick()
        {
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.initial);
        }

        public void OnlineOnClick()
        {
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.online);
        }

        public void WithFriendsOnClick()
        {
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.withFriends);
        }

        public void OfflineOnClick()
        {
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.offline);
        }

        public void BotOfflineOnClick()
        {
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.computerbot);
        }

        public void ThemeOnClick()
        {
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.themes);
        }


    }


}
