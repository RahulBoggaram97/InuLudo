using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

namespace com.impactionalGames.LudoInu
{
    public enum walletState
    {
        loading,
        backFromLobby,
        intial,
        profile,
        editProfile,
        settings, 
        spin, 
        ranking, 
        store, 
        wallet

    }

    public class walletManager : genricSingletonClass<walletManager>
    {
        public GameObject walletCanvas;
   
        [Header("otherScripts")]
        public ProfileManager profileMan;
        public getStoreItemsApi storeMan;
        public getLastSpinApi spinMan;
        public getLeaderBoradApi leaderBoardMan;
        public int coroutineCount = 0;

        [Header("Buttons")]
        public Button settingButton;
        public Button leaderBoardButton;
        public Button giftButton;
        public GameObject spinButton;
        //public Button referAndEarnButton;


        [Header("Panles")]
        public GameObject profilePanel;
        public GameObject editProfilePanel;
        public GameObject settingsPanel;
        public GameObject spinPanel;
        public GameObject rankingPanel;
        public GameObject storePanel;
        public GameObject walletPanel;

        [Header("Currency text lists")]
        public List<Text> coinTextList = new List<Text>();
        public List<Text> diamondTextList = new List<Text>();



      
        public static event Action<walletState> onWalletStateChanged;

        public override void Awake()
        {
            base.Awake();
            mainMenuManager.onMenuStateChanged += HandleMenuStateChanged;

        }

        private void OnDestroy()
        { 
            mainMenuManager.onMenuStateChanged -= HandleMenuStateChanged;
        }

       

        private void HandleMenuStateChanged(mainMenuState state)
        {
           if(state != mainMenuState.initial)
            {
                settingButton.gameObject.SetActive(false);
                leaderBoardButton.gameObject.SetActive(false);
                giftButton.gameObject.SetActive(false);
                spinButton.SetActive(false);
                //referAndEarnButton.gameObject.SetActive(false);

               
            }
            else
            {
                settingButton.gameObject.SetActive(true);
                leaderBoardButton.gameObject.SetActive(true);
                giftButton.gameObject.SetActive(true);
                spinButton.SetActive(true);
                //referAndEarnButton.gameObject.SetActive(true);
                

            }
        }



      


        private void Start()
        {
           

            foreach(Text item in coinTextList)
            {
                item.text = playerPermData.getMoney().ToString();
            }
            foreach(Text item in diamondTextList)
            {
                item.text = playerPermData.getDiamonds();
            }
            
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
                case walletState.loading:
                    handleLoadingState();
                    break;
                case walletState.backFromLobby:
                    handleBackFromLobbyState();
                    break;
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
                case walletState.store:
                    handleStoreState();
                    break;
                case walletState.wallet:
                    handleWalletState();
                    break;
                
            }

            onWalletStateChanged?.Invoke(State);
        }


        private void handleLoadingState()
        {
            

            profileMan.profileLoad();
            storeMan.getAllItemsInStore();
            spinMan.getLastSpin();
            leaderBoardMan.getLeaderBoard();

            StartCoroutine(setStateToIntial());


        }

        IEnumerator setStateToIntial()
        {
            yield return new WaitUntil(()=> coroutineCount == 4);
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.initial);
            walletManager.Instance.updateWalletState(walletState.intial);
        }

        private void handleBackFromLobbyState()
        {
           
        }


        private void handleIntialState()
        {
            walletCanvas.GetComponent<Canvas>().sortingOrder = -1;

            profilePanel.SetActive(false);    
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);
            storePanel.SetActive(false);
            walletPanel.SetActive(false);

        }

        private void handleProfileState()
        {
            walletCanvas.GetComponent<Canvas>().sortingOrder = 3;

            profilePanel.SetActive(true);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);
            storePanel.SetActive(false);
            walletPanel.SetActive(false);

        }
 
        private void handleEditProfileState()
        {
            walletCanvas.GetComponent<Canvas>().sortingOrder = 3;

            profilePanel.SetActive(false);
            editProfilePanel.SetActive(true);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);
            storePanel.SetActive(false);
            walletPanel.SetActive(false);

        }
        private void handleSettingsState()
        {
            walletCanvas.GetComponent<Canvas>().sortingOrder = 3;


            profilePanel.SetActive(false);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(true);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);
            storePanel.SetActive(false);
            walletPanel.SetActive(false);


        }
        private void handleSpinState()
        {
            walletCanvas.GetComponent<Canvas>().sortingOrder = 3;

            profilePanel.SetActive(false);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(true);
            rankingPanel.SetActive(false);
            storePanel.SetActive(false);
            walletPanel.SetActive(false);

            spinPanel.GetComponent<spineManager>().ShowWheelToPlayer();

        }

        private void handleRankingState()
        {
            walletCanvas.GetComponent<Canvas>().sortingOrder = 3;

            profilePanel.SetActive(false);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(true); 
            storePanel.SetActive(false);
            walletPanel.SetActive(false);


        }

        private void handleStoreState()
        {
            walletCanvas.GetComponent<Canvas>().sortingOrder = 3;

            profilePanel.SetActive(false);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);
            storePanel.SetActive(true);
            walletPanel.SetActive(false);
        }

        private void handleWalletState()
        {
            walletCanvas.GetComponent<Canvas>().sortingOrder = 3;

            profilePanel.SetActive(false);
            editProfilePanel.SetActive(false);
            settingsPanel.SetActive(false);
            spinPanel.SetActive(false);
            rankingPanel.SetActive(false);
            storePanel.SetActive(false);
            walletPanel.SetActive(true);
        }

        //FOR FLUTTER CALLS
        public void IntialOnClick()
        {
           walletManager.Instance.updateWalletState(walletState.intial);
        }

        public void AddMoneyOnClick()
        {
            //walletManager.instance.updateWalletState(walletState.addMoney);
            Debug.Log("sent message to fullter");
            UnityMessageManager.Instance.SendMessageToFlutter("AddMoney");
        }

        public void WithdrawOnClick()
        {
            //walletManager.instance.updateWalletState(walletState.withdraw);
            UnityMessageManager.Instance.SendMessageToFlutter("Withdrawl");
            Debug.Log("withdraw called");

        }


        //FOR FLUTTER CALLS END




        public void ProfileOnClick()
        {
            walletManager.Instance.updateWalletState(walletState.profile);
            Debug.Log("profile button called");
        }


        public void EditProflieOnClick()
        {
            walletManager.Instance.updateWalletState(walletState.editProfile);
        }

        public void SettingsOnClick()
        {
            walletManager.Instance.updateWalletState(walletState.settings);
        }

        public void SpinOnClick()
        {
            walletManager.Instance.updateWalletState(walletState.spin);
        }

        public void RankingOnClick()
        {
            walletManager.Instance.updateWalletState(walletState.ranking);
        }

        public void StoreOnClick()
        {
            walletManager.Instance.updateWalletState(walletState.store);
        }

        public void ThemeOnClick()
        {
            mainMenuManager.Instance.updateMainMenuState(mainMenuState.themes);
            walletManager.Instance.updateWalletState(walletState.intial);
        }

        public void WalletOnClick()
        {
            walletManager.Instance.updateWalletState(walletState.wallet);
        }

    }



}