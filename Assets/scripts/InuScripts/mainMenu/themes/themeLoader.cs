using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace com.impactionalGames.LudoInu
{
    public class themeLoader : MonoBehaviour
    {
        public List<GameObject> backgroundImages = new List<GameObject>();

        private void Awake()
        {
           
            themeManager.onThemeChanged += changeThemeRealtime;
        }

        private void OnDestroy()
        {
            themeManager.onThemeChanged -= changeThemeRealtime;
        }

        private void Start()
        {
            string directoryPath = Application.persistentDataPath + "/" + "ThemeImages" + "/";

            if (!Directory.Exists(directoryPath))
            {
                return;
            }
            else
            {
                foreach (GameObject themeBackground in backgroundImages)
                {
                   themeManager.ConvertToTextureAndLoad(themeBackground);

                    if(themeBackground.GetComponent<SpriteRenderer>() != null)
                    {
                        themeBackground.transform.localPosition = new Vector3(-4, -7);
                        themeBackground.transform.localScale = new Vector3(0.8f, 0.7f, 0.8f);
                    }
                }

            }

        }



     
        private void changeThemeRealtime()
        {
            foreach (GameObject themeBackground in backgroundImages)
            {
                themeManager.ConvertToTextureAndLoad(themeBackground);
            }
        }
    }

}