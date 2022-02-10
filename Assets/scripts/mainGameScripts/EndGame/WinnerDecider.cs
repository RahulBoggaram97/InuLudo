using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using System;

namespace com.impactionalGames.LudoPrime
{
    public class WinnerDecider : MonoBehaviour
    {
        public RollinDice[] scoreDice;

        public winOrLossState rank;

        public prizeDistibutor distributor;


        //FOR 2 PLAYERS
        public void decideOnevOneWinner()
        {
            int[] scorArr = new int[] {scoreDice[0].score, scoreDice[2].score};

            int maxScore = scorArr.Max();

            int rank1Index = 0;

            for (int i = 0; i < scoreDice.Length; i++)
            {
                if(maxScore == scoreDice[i].score)
                {
                    rank1Index = i;
                }
            }

            if(PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank1Index])
            {
                rank = winOrLossState.rankOne;
            }
            else
            {
                rank = winOrLossState.rankTwo;
            }

            //directs to the distributor
            distributor.distributePrizeOneVOne();
        }


        //FOR FOUR PLAYERS
        public void decideFourPlayerGameWinner()
        {
            List<int> scorArr = new List<int> { scoreDice[0].score, scoreDice[1].score, scoreDice[2].score, scoreDice[3].score };

            int maxScore = scorArr.Max();

            int rank1Index = 0;
            int rank2Index = 0;
            int rank3Index = 0;

            for (int i = 0; i < scoreDice.Length; i++)
            {
                if (maxScore == scoreDice[i].score)
                {
                    rank1Index = i;
                    scorArr.RemoveAt(i);
                }
            }

            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank1Index])
            {
                rank = winOrLossState.rankOne;
            }
            else
            {
                maxScore = scorArr.Max();

                for (int i = 0; i < scoreDice.Length; i++)
                {
                    if (maxScore == scoreDice[i].score)
                    {
                        rank2Index = i;
                        scorArr.RemoveAt(i);
                    }
                }

                if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank2Index])
                {
                    rank = winOrLossState.rankTwo;
                }

                else
                {
                    maxScore = scorArr.Max();

                    for (int i = 0; i < scoreDice.Length; i++)
                    {
                        if (maxScore == scoreDice[i].score)
                        {
                            rank3Index = i;
                            scorArr.RemoveAt(i);
                        }
                    }

                    if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank2Index])
                    {
                        rank = winOrLossState.rankThree;
                    }

                    else
                    {
                        rank = winOrLossState.rankFour;
                    }
                }




            }


            checkWhichLobby();
        }

        private void checkWhichLobby()
        {
            if (checkIfItsOneWinnerLobby())
            {
                distributor.distributePrizeOneWinner();
            }
            else if (checkIfItsTwoWinnersLobby())
            {
                distributor.distributePrizeTwoWinners();
            }
            else
            {
                distributor.distributePrizeThreeWinners();
            }
        }


        bool checkIfItsOneWinnerLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneWinnerOne":
                    return true;
                case "oneWinnerFive":
                    return true;
                case "oneWinnerTen":
                    return true;
                case "oneWinnerTwentyFive":
                    return true;
                case "oneWinnerFifty":
                    return true;
                case "oneWinnerHundred":
                    return true;
                default:
                    return false;
            }
        }

        bool checkIfItsTwoWinnersLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "twoWinnersOne":
                    return true;
                case "twoWinnersFive":
                    return true;
                case "twoWinnersTen":
                    return true;
                case "twoWinnersTwentyFive":
                    return true;
                case "twoWinnersFifty":
                    return true;
                case "twoWinnersHundred":
                    return true;
                default:
                    return false;
            }
        }
    }


    public enum winOrLossState
    {
        rankOne,
        rankTwo,
        rankThree,
        rankFour
    }
}
