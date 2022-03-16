using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoInu
{
    public enum walletState
    {
        intial,
        profile,
        editProfile,
        settings, 
        spin, 
        ranking
    }

    public class walletManager : MonoBehaviour
    {
        public GameObject walletCanvas;


        [Header("Buttons")]
        public Button settingButton;
        public Button leaderBoardButton;
        public Button giftButton;
        public Button spinButton;
        public Button referAndEarnButton;


        [Header("Panles")]
        public GameObject profilePanel;
        public GameObject editProfilePanel;
        public GameObject settingsPanel;
        public GameObject spinPanel;
        public GameObject rankingPanel;
      

       

        
       


        public static walletManager instance;
        public static event Action<walletState> onWalletStateChanged;

        private void Awake()
        {
            if(instance == null)
            instance = this;



            SceneManager.sceneLoaded += onSceneLoaded;

            
            
            
        }

        private void onSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            mainMenuManager.onMenuStateChanged += HandleMenuStateChanged;
        }

        private void HandleMenuStateChanged(mainMenuState state)
        {
           if(state != mainMenuState.initial)
            {
                settingButton.gameObject.SetActive(false);
                leaderBoardButton.gameObject.SetActive(false);
                giftButton.gameObject.SetActive(false);
                spinButton.gameObject.SetActive(false);
                referAndEarnButton.gameObject.SetActive(false);
            }
            else
            {
                settingButton.gameObject.SetActive(true);
                leaderBoardButton.gameObject.SetActive(true);
                giftButton.gameObject.SetActive(true);
                spinButton.gameObject.SetActive(true);
                referAndEarnButton.gameObject.SetActive(true);

            }
        }

        private void Start()
        {
            updateWalletState(walletState.intial);
            
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                IntialOnClick();
            }
        }


        public walletState State;

        public void updateWalletState(walletState newstate)
        {
            this.State = newstate;

            switch (State)
            {
                case walletState.intial:
                    handleIntialState();
                    break;
                case walletState.profile:
                    handleProfileState();
                    break;
                case walletState.editProfile:
                   handleEditProfileState();
                    break;
                case walletState.settings:
                    handleSettingsState();
                    break;
                case walletState.spin:
                    handleSpinState();
                    break;
                case walletState.ranking:
                    handleRankingState();
                    break;
                
            }

            onWalletStateChanged?.Invoke(State);
        }



        private void handleIntialState()
        {
            profilePanel.SetActive(false);    
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);

        }

        private void handleProfileState()
        {
            profilePanel.SetActive(true);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);

        }
 
        private void handleEditProfileState()
        {
            profilePanel.SetActive(false);
            editProfilePanel.SetActive(true);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);

        }
        private void handleSettingsState()
        {
            profilePanel.SetActive(false);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(true);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);


        }
        private void handleSpinState()
        {
            profilePanel.SetActive(false);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(true);
            rankingPanel.SetActive(false);

        }

        private void handleRankingState()
        {
            profilePanel.SetActive(false);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(true);
        }
  
        public void IntialOnClick()
        {
           walletManager.instance.updateWalletState(walletState.intial);
        }

        public void ProfileOnClick()
        {
            walletManager.instance.updateWalletState(walletState.profile);
            Debug.Log("profile button called");
        }


        public void EditProflieOnClick()
        {
            walletManager.instance.updateWalletState(walletState.editProfile);
        }

        public void SettingsOnClick()
        {
            walletManager.instance.updateWalletState(walletState.settings);
        }

        public void SpinOnClick()
        {
            walletManager.instance.updateWalletState(walletState.spin);
        }

        public void RankingOnClick()
        {
            walletManager.instance.updateWalletState(walletState.ranking);
        }


    }



}