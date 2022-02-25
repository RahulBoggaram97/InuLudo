using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


namespace com.impactionalGames.LudoInu
{
    public class rollindiceBotOffline : MonoBehaviour
    {
        public gameManagerBotOffline gm;

        [SerializeField] int numberGot;
        [SerializeField] GameObject rollinDiceAnime;
        [SerializeField] Sprite[] diceSprites;
        [SerializeField] SpriteRenderer dicRender;


        public bool hasRolled = false;
        public bool hasMoved = false;

        public void OnMouseDown()
        {
            if(this.name.Contains("red"))
            preRollDice();
        }



        public async Task preRollDice()
        {
            

                if (!this.hasRolled && !this.hasMoved)
                {

                Debug.Log(this.name);

                await rollDice();

                


                    gm.numOfStepsToMove = numberGot + 1;



                    gm.rolleddice = this;
                    this.hasRolled = true;
                transferIfNoOutPlayers();


                gm.RollingDiceManager();

                
                //changetocallphoton

                
                
                }
                else
                {
                    Debug.Log("has rolled value:" + this.hasRolled + "     " +
                        "has moved value:" + this.hasMoved);
                }
            


        }


        async Task rollDice()
        {
            numberGot = Random.Range(0, 6);
            dicRender.gameObject.SetActive(false);
            rollinDiceAnime.SetActive(true);
            
                Debug.Log("green dice has been rolled");


            await Task.Delay(1000);

            rollinDiceAnime.SetActive(false);
            dicRender.gameObject.SetActive(true);
            dicRender.sprite = diceSprites[numberGot];

            await Task.Delay(1000);

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
