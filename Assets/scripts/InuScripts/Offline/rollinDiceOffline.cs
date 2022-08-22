using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace com.impactionalGames.LudoInu {
    public class rollinDiceOffline : MonoBehaviour
    {
        public gameManagerOffline gm;

        [SerializeField] int numberGot;
        [SerializeField] GameObject rollinDiceAnime;
        [SerializeField] Sprite[] diceSprites;
        [SerializeField] SpriteRenderer dicRender;


        public bool hasRolled = false;
        public bool hasMoved = false;


        private void OnMouseDown()
        {
            preRollDice();
        }


        async void preRollDice()
        {
            if (!this.hasRolled && !this.hasMoved)
                StartCoroutine(rollDice());
            else
                Debug.Log("has rolled value:" + this.hasRolled + "     " +
                    "has moved value:" + this.hasMoved);
        }


        IEnumerator rollDice()
        {
            numberGot = Random.Range(0, 6);
            dicRender.gameObject.SetActive(false);
            rollinDiceAnime.SetActive(true);
            yield return new WaitForSeconds(1);

            rollinDiceAnime.SetActive(false);
            dicRender.gameObject.SetActive(true);
            dicRender.sprite = diceSprites[numberGot];

            yield return new WaitForEndOfFrame();

            afterRoll();

        }

        void afterRoll()
        {

            gm.numOfStepsToMove = numberGot + 1;



            gm.rolleddice = this;
            this.hasRolled = true;
            transferIfNoOutPlayers();
            //changetocallphoton
            gm.RollingDiceManager();
        }


        void transferIfNoOutPlayers()
        {
            if (this.name.Contains("yellow") && gm.yellowOutPlayers == 0 && gm.numOfStepsToMove != 6)
            {
                this.hasMoved = true;
                gm.transferDice = true;
            }
            else if (this.name.Contains("red") && gm.redOutPlayers == 0 && gm.numOfStepsToMove != 6)
            {
                this.hasMoved = true;
                gm.transferDice = true;
            }
            else if (this.name.Contains("green") && gm.greenOutPlayers == 0 && gm.numOfStepsToMove != 6)
            {
                this.hasMoved = true;
                gm.transferDice = true;
            }
            else if (this.name.Contains("blue") && gm.blueOutPlayers == 0 && gm.numOfStepsToMove != 6)
            {
                this.hasMoved = true;
                gm.transferDice = true;
            }
        }

    }
}

