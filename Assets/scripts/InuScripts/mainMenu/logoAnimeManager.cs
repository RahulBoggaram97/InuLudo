using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace com.impactionalGames.LudoInu
{
    public class logoAnimeManager : MonoBehaviour
    {

        public Animator animator;

        private void Awake()
        {
            mainMenuManager.onMenuStateChanged += HandleMainMenuStateChanged;
        }

        private void HandleMainMenuStateChanged(mainMenuState state)
        {
            if(state == mainMenuState.initial)
            {
                animator.SetTrigger("bounce");
            }
            
        }
    }
}
