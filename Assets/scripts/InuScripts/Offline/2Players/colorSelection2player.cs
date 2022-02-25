using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.impactionalGames.LudoInu
{
    public class colorSelection2player : MonoBehaviour
    {
        public string player1Colour;
        public string player2Colour;

        public Image[] border;
        public Image[] border2;
        

        public void selectRed1Colour()
        {
            for(int i = 0; i < border.Length; i++)
            {
                border[i].gameObject.SetActive(false);
            }


            border[0].gameObject.SetActive(true);

            player1Colour = "red";
        }

        public void selectGreen1Colour()
        {
            for (int i = 0; i < border.Length; i++)
            {
                border[i].gameObject.SetActive(false);
            }


            border[1].gameObject.SetActive(true);

            player1Colour = "green";
        }

        public void selectYellow1Colour()
        {
            for (int i = 0; i < border.Length; i++)
            {
                border[i].gameObject.SetActive(false);
            }


            border[2].gameObject.SetActive(true);

            player1Colour = "yellow";
        }

        public void selectBlue1Colour()
        {
            for (int i = 0; i < border.Length; i++)
            {
                border[i].gameObject.SetActive(false);
            }


            border[3].gameObject.SetActive(true);

            player1Colour = "blue";
        }


        public void selectRed2Colour()
        {
            for (int i = 0; i < border2.Length; i++)
            {
                border2[i].gameObject.SetActive(false);
            }


            border2[0].gameObject.SetActive(true);

            player2Colour = "red";
        }

        public void selectGreen2Colour()
        {
            for (int i = 0; i < border2.Length; i++)
            {
                border2[i].gameObject.SetActive(false);
            }


            border2[1].gameObject.SetActive(true);

            player2Colour = "green";
        }

        public void selectYellow2Colour()
        {
            for (int i = 0; i < border2.Length; i++)
            {
                border2[i].gameObject.SetActive(false);
            }


            border2[2].gameObject.SetActive(true);

            player2Colour = "yellow";
        }

        public void selectBlue2Colour()
        {
            for (int i = 0; i < border2.Length; i++)
            {
                border2[i].gameObject.SetActive(false);
            }


            border2[3].gameObject.SetActive(true);

            player2Colour = "blue";
        }


        
    }
}
