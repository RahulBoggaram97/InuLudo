using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


namespace com.impactionalGames.LudoInu
{
    public class settingManager : MonoBehaviour
    {
      

        public TMP_Dropdown language;
        public static event Action<string> onlangChanged;

        public void UpdateLanguage()
        {
            if (language.value == 1)
            {
                playerPermData.setLanguage(playerPermData.HINDI_KEY);
                onlangChanged?.Invoke(playerPermData.getLanguage());
            }
            else
            {
                playerPermData.setLanguage(playerPermData.ENGLISH_KEY);
                onlangChanged?.Invoke(playerPermData.getLanguage());
            }

        }
    }
}
