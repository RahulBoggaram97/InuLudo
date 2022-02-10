using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



namespace com.impactionalGames.LudoPrime
{
    public class languageManager : MonoBehaviour
    {


        public Dropdown langDrop;

       
       
       
  

        public void Start()
        {
            //updateLanguage();
            
        }


        public List<GameObject> textList = new List<GameObject>();

        public List<string> english = new List<string>();
        public List<string> hindi = new List<string>();

        

        public void updateLanguage()
        {
            for (int i = 0; i < textList.Count; i++)
            {
                if (langDrop.value == 1)
                {
                    if(textList[i].GetComponent<Text>() != null)
                    {
                        textList[i].GetComponent<Text>().text = hindi[i];
                    }
                    else if(textList[i].GetComponent<TextMeshProUGUI>() != null)
                    {
                        textList[i].GetComponent<TextMeshProUGUI>().text = hindi[i];
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (textList[i].GetComponent<Text>() != null)
                    {
                        textList[i].GetComponent<Text>().text = english[i];
                    }
                    else if (textList[i].GetComponent<TextMeshProUGUI>() != null)
                    {
                        textList[i].GetComponent<TextMeshProUGUI>().text = english[i];
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

    }

}