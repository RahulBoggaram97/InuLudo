using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

namespace com.impactionalGames.LudoInu
{
    

    public class flutterManager : MonoBehaviour, IEventSystemHandler
    {
        public createNewUser createUser;


        public void passPhoneNumberToUnity(String phoneNum)
        {
            playerPermData.setPhoneNumber(phoneNum);
            createUser.createUser();
        }  
    }
}
