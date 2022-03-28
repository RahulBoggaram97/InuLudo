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

        public Text debugText;


        public void selectRed1Colour()
        {
            if (player2Colour != "red")
            {
                for (int i = 0; i < border.Length; i++)
                {
                    border[i].gameObject.SetActive(false);
                }


                border[0].gameObject.SetActive(true);

                player1Colour = "red";
            }
            else
            {
                StartCoroutine(displayDebugText("Colour is already selected, select another one."));
            }
        }

        public void selectGreen1Colour()
        {
            if (player2Colour != "green")
            {
                for (int i = 0; i < border.Length; i++)
                {
                    border[i].gameObject.SetActive(false);
                }


                border[1].gameObject.SetActive(true);

                player1Colour = "green";
            }
            else
            {
                StartCoroutine(displayDebugText("Colour is already selected, select another one."));
            }
        }

        public void selectYellow1Colour()
        {
            if (player2Colour != "yellow")
            {
                for (int i = 0; i < border.Length; i++)
                {
                    border[i].gameObject.SetActive(false);
                }


                border[2].gameObject.SetActive(true);

                player1Colour = "yellow";
            }
            else
            {
                StartCoroutine(displayDebugText("Colour is already selected, select another one."));
            }
        }

        public void selectBlue1Colour()
        {
            if (player2Colour != "blue")
            {
                for (int i = 0; i < border.Length; i++)
                {
                    border[i].gameObject.SetActive(false);
                }


                border[3].gameObject.SetActive(true);

                player1Colour = "blue";
            }
            else
            {
                StartCoroutine(displayDebugText("Colour is already selected, select another one."));
            }
        }


        public void selectRed2Colour()
        {
            if (player1Colour != "red")
            {
                for (int i = 0; i < border2.Length; i++)
                {
                    border2[i].gameObject.SetActive(false);
                }


                border2[0].gameObject.SetActive(true);

                player2Colour = "red";
            }
            else
            {
                StartCoroutine(displayDebugText("Colour is already selected, select another one."));
            }
        }

        public void selectGreen2Colour()
        {
            if (player1Colour != "green")
            {
                for (int i = 0; i < border2.Length; i++)
                {
                    border2[i].gameObject.SetActive(false);
                }


                border2[1].gameObject.SetActive(true);

                player2Colour = "green";
            }
            else
            {
                StartCoroutine(displayDebugText("Colour is already selected, select another one."));
            }
        }

        public void selectYellow2Colour()
        {
            if (player1Colour != "yellow")
            {
                for (int i = 0; i < border2.Length; i++)
                {
                    border2[i].gameObject.SetActive(false);
                }


                border2[2].gameObject.SetActive(true);

                player2Colour = "yellow";
            }
            else
            {
                StartCoroutine(displayDebugText("Colour is already selected, select another one."));
            }
        }

        public void selectBlue2Colour()
        {
            if (player1Colour != "blue")
            {
                for (int i = 0; i < border2.Length; i++)
                {
                    border2[i].gameObject.SetActive(false);
                }


                border2[3].gameObject.SetActive(true);

                player2Colour = "blue";
            }
            else
            {
                StartCoroutine(displayDebugText("Colour is already selected, select another one."));
            }
        }

        IEnumerator displayDebugText(string newText)
        {
            debugText.text = newText;
            yield return new WaitForSeconds(5);
            debugText.text = "";
        }

    }
}
