using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace com.impactionalGames.LudoPrime
{
    public class phoneNumEnter : MonoBehaviour
    {
        [Header("Firebase")]
        FirebaseAuth auth;
        PhoneAuthProvider provider;

        [Header("variables")]
        private uint phoneAuthTimeOutMs = 60000;
        private string verificationId;


        public Text debugText;
 

        private void Start()
        {

            
            auth = FirebaseAuth.DefaultInstance;

            debugText.text = "start method got called";

            if (auth.CurrentUser != null)
            {
                authManager.instance.updateLoginState(loginState.loggedIn);

                debugText.text = "start method got called" + " this is a user rn";
            }
            else
            {
                authManager.instance.debugText.text = "auto login is not working";
            }


        }

        public void authenticate()
        {
            tester();
        }

        void tester()
        {
            debugText.text = "tester got called";
            try
            {
                provider = PhoneAuthProvider.GetInstance(auth);
                debugText.text = "tester got called" + " provider:" + provider;

                debugText.text = "tester got called" + " provider:" + provider + authManager.instance.phoneNoField.text;
                provider.VerifyPhoneNumber(authManager.instance.countyCodeField.text +  authManager.instance.phoneNoField.text, phoneAuthTimeOutMs, null,
                                                                                  verificationCompleted: (credential) =>
                                                                                  {
                                                                                      //Auto - sms - retrieval or instant validation has succeeded(Android only).
                                                                                      //    There is no need to input the verification code.
                                                                                      //         `credential` can be used instead of calling GetCredential().
                                                                                      authManager.instance.debugText.text = "verificationCompleted";
                                                                                  },
                                                                                  verificationFailed: (error) =>
                                                                                  {
                                                                                      //The verification code was not sent.
                                                                                      //         `error` contains a human readable explanation of the problem.
                                                                                      authManager.instance.debugText.text = error.ToString();
                                                                                  },
                                                                                  codeSent: (id, token) =>
                                                                                  {

                                                                                      verificationId = id;
                                                                                      authManager.instance.debugText.text = "code sent and the id is :" + id + " token is :" + token;
                                                                                      authManager.instance.updateLoginState(loginState.enterOtpNum);
                                                                                      //Verification code was successfully sent via SMS.
                                                                                      //         `id` contains the verification id that will need to passed in with
                                                                                      //         the code from the user when calling GetCredential().
                                                                                      //         `token` can be used if the user requests the code be sent again, to
                                                                                      //         tie the two requests together.
                                                                                          },
                                                                                  codeAutoRetrievalTimeOut: (id) =>
                                                                                  {
                                                                                      //Called when the auto-sms - retrieval has timed out, based on the given
                                                                                      //  timeout parameter.
                                                                                      //         `id` contains the verification id of the request that timed out.
                                                                                          });
            }
            catch (System.Exception e)
            {
                authManager.instance.debugText.text = e.ToString() + " didnt enter the the authentication";
            }

        }

        public void signIn()
        {

            Credential credential = provider.GetCredential(verificationId, authManager.instance.OTPField.text);


            auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    authManager.instance.debugText.text = ("SignInWithCredentialAsync encountered an error: " + task.Exception);

                    return;
                }

                FirebaseUser newUser = task.Result;
                authManager.instance.debugText.text = ("User signed in successfully" + "" +

                "Phone number: " + newUser.PhoneNumber + "" +

                "Phone provider ID: " + newUser.ProviderId);

                playerPermData.setPhoneNumber(newUser.PhoneNumber);

                authManager.instance.updateLoginState(loginState.authenticated);

                debugText.text = authManager.instance.state.ToString();

            });
        }






    }
}
