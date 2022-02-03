using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.impactionalGames.LudoInu
{
    public class handleButtonTabGlow : MonoBehaviour
    {
        public GameObject[] panelToTrack;
        public Button[] buttonToActivate;

        // Update is called once per frame
        void Update()
        {
            glowButtonManager();
        }

        void glowButtonManager()
        {
            for(int i = 0; i < panelToTrack.Length; i++)
            {
                if(panelToTrack[i].activeSelf == true)
                {
                    buttonToActivate[i].Select();
                }
            }
        }
    }
}
