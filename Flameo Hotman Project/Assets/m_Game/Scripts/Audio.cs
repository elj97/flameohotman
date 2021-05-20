using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource soundtrack_One;
    public AudioSource explosion;

    private void Update()
    {
        if (StaticSettings.sfx == true)
        {
            explosion.volume = 1;
        }
        else
        {
            explosion.volume = 0;
        }

        if (StaticSettings.music == true)
        {
            soundtrack_One.volume = 1;
        }
        else
        {
            soundtrack_One.volume = 0;
        }

    }
}
