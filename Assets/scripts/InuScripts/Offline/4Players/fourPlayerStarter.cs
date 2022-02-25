using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoInu
{
    public class fourPlayerStarter : MonoBehaviour
    {
        public LudoHomes[] colorPieces;

        private void Awake()
        {
            OfflineManager.onTypeOfGameSelected += handleOnFourPlayerSelected;
        }

        private void handleOnFourPlayerSelected(typeOfGame state)
        {
            if (state == typeOfGame.fourPlayer)
            {
                gameManagerOffline.gm.totalPlayersCanPlay = 4;
                colorPieces[0].dice.gameObject.SetActive(true);
                colorPieces[1].dice.gameObject.SetActive(false);
                colorPieces[2].dice.gameObject.SetActive(false);
                colorPieces[3].dice.gameObject.SetActive(false);

                for (int i = 0; i < colorPieces.Length; i++)
                {
                    activateColourPiece(i);
                }
                
            }
            else return;
        }


        void activateColourPiece(int index)
        {
            for(int i = 0; i <4; i++)
            {
                colorPieces[index].playerPieces[i].SetActive(true);
            }

        }
    }
}
