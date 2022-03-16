using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using System;

namespace com.impactionalGames.LudoInu
{
    public enum spinState
    {
        spinAble,
        timeCountDown
    }

    public class spineManager : MonoBehaviour
    {
        [SerializeField] private Button uiSpinButton;
        [SerializeField] private Text uiSpinText;

        [SerializeField] private PickerWheel pickWheel;


        public spinState state;


        [Header("Panels")]
        public GameObject pickerWheelPanel;
        public GameObject timeToSpinWheelPanel;











        public Text nextTimeToSpinText;
        public Text wonCoinText;


        private void Start()
        {
            uiSpinButton.onClick.AddListener(spinWhell);

            //if (ShowWheelToPlayer())
            //{
            //    updateWheelState(spinState.spinAble);
            //}
            //else
            //{
            //    updateWheelState(spinState.timeCountDown);
            //}

        }


        void updateWheelState(spinState newState)
        {
            state = newState;

            switch (state)
            {
                case spinState.spinAble:
                    handleSpinableState();
                    break;
                case spinState.timeCountDown:
                    handleTimeCountDownState();
                    break;
            }


        }

        private void handleSpinableState()
        {
            pickerWheelPanel.SetActive(true);
            timeToSpinWheelPanel.SetActive(false);
        }

        private void handleTimeCountDownState()
        {
            pickerWheelPanel.SetActive(false);
            timeToSpinWheelPanel.SetActive(true);

            nextTimeToSpinText.text = long.Parse(PlayerPrefs.GetString("LastDateSpun")).ToString();
        }



        public void spinWhell()
        {
            uiSpinButton.interactable = false;
            uiSpinText.text = "Spinning..";

            pickWheel.OnSpinEnd(wheelPiece =>
            {
                Debug.Log("Spin End: Type : " + wheelPiece.Label + ", Amount: " + wheelPiece.Amount);
                uiSpinButton.interactable = true;
                uiSpinText.text = "Spin";

                wonCoinText.text = wheelPiece.Amount.ToString();
                updateWheelState(spinState.timeCountDown);
            });


            pickWheel.Spin();

            OnWheelSpun();

            

        }



        bool ShowWheelToPlayer()
        {
            if (DateTime.Now.Ticks - TimeSpan.TicksPerDay > long.Parse(PlayerPrefs.GetString("LastDateSpun", "0")))
                return true;
            else
                return false;
        }

        void OnWheelSpun()
        {
            PlayerPrefs.SetString("LastDateSpun", DateTime.Now.Ticks.ToString());
        }
        

    }
}