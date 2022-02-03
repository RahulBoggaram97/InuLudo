using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSys : MonoBehaviour
{
    public ParticleSystem Win;
    

    public void Click()
    {
        if(Win.isPlaying)
        {
            Win.Stop();
        }
        else
        {
            Win.Play();
        }

        
    }
}
