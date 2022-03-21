using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace com.impactionalGames.LudoInu
{
    public enum storeMenuState
    {
        coinStore,
        diamondStore,
        talkTimeStore,
        themesStore,
        discountStore
    }

    public class storeManager : MonoBehaviour
    {
        public static storeManager instance;
        public storeMenuState state;

        public static event Action<storeMenuState> onStoreMenuStateChanged;




        [Header("Panels")]
        public GameObject coinStorePanel;
        public GameObject diamondStorePanel;
        public GameObject talkTimeStorePanel;
        public GameObject themeStorePanel;
        public GameObject discounStorePanel;

        [Header("Button")]
        public List<Image> buttonList;
        public Sprite BackButtonSpirte;
        public Sprite FrontButtonSprite;



        private void Awake()
        {
            if(instance == null)
                instance = this;
        }

        public void updateStoreMenuState(storeMenuState newState)
        {
            state = newState;
            switch (state)
            {
                case storeMenuState.coinStore:
                    handleCoinStoreState();
                    break;
                case storeMenuState.diamondStore:
                    handlediamondStoreState();
                    break;
                case storeMenuState.talkTimeStore:
                    handletalkTimeStoreState();
                    break;
                case storeMenuState.themesStore:
                    handlethemesStoreState();
                    break;
                case storeMenuState.discountStore:
                    handlediscountStoreState();
                    break;
            }

            onStoreMenuStateChanged?.Invoke(state);
        }

        private void handleCoinStoreState()
        {
            coinStorePanel.SetActive(true);
            diamondStorePanel.SetActive(false);
            talkTimeStorePanel.SetActive(false);
            themeStorePanel.SetActive(false);
            discounStorePanel.SetActive(false);

            setButtonbackGround(0);

        }

        private void handlediamondStoreState()
        {
            coinStorePanel.SetActive(false);
            diamondStorePanel.SetActive(true);
            talkTimeStorePanel.SetActive(false);
            themeStorePanel.SetActive(false);
            discounStorePanel.SetActive(false);

            setButtonbackGround(1);
        }

        private void handletalkTimeStoreState()
        {
            coinStorePanel.SetActive(false);
            diamondStorePanel.SetActive(false);
            talkTimeStorePanel.SetActive(true);
            themeStorePanel.SetActive(false);
            discounStorePanel.SetActive(false);

            setButtonbackGround(2);
        }
        private void handlethemesStoreState()
        {
            coinStorePanel.SetActive(false);
            diamondStorePanel.SetActive(false);
            talkTimeStorePanel.SetActive(false);
            themeStorePanel.SetActive(true);
            discounStorePanel.SetActive(false);

            setButtonbackGround(3);
        }
        private void handlediscountStoreState()
        {
            coinStorePanel.SetActive(false);
            diamondStorePanel.SetActive(false);
            talkTimeStorePanel.SetActive(false);
            themeStorePanel.SetActive(false);
            discounStorePanel.SetActive(true);

            setButtonbackGround(4);
        }



        public void CoinOnClick()
        {
            storeManager.instance.updateStoreMenuState(storeMenuState.coinStore);
        }

        public void DiamondsOnClick()
        {
            storeManager.instance.updateStoreMenuState(storeMenuState.diamondStore);
        }

        public void TalkTimeOnClick()
        {
            storeManager.instance.updateStoreMenuState(storeMenuState.talkTimeStore);
        }

        public void ThemesOnClick()
        {
            storeManager.instance.updateStoreMenuState(storeMenuState.themesStore);
        }

        public void DiscountOnClick()
        {
            storeManager.instance.updateStoreMenuState(storeMenuState.discountStore);
        }





        void setButtonbackGround(int index)
        {
           for(int i = 0; i< buttonList.Count; i++)
            {
                if(i!= index)
                {
                    buttonList[i].sprite = BackButtonSpirte;

                }
                else
                {
                    buttonList[i].sprite = FrontButtonSprite;
                }
            }
        }
    }
}