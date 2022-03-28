using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class unloadScene : MonoBehaviour
    {
        public string selfScenename;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.UnloadSceneAsync(selfScenename);
               com.impactionalGames.LudoInu.mainMenuManager.Instance.updateMainMenuState(com.impactionalGames.LudoInu.mainMenuState.initial);
            }
        }
    }

