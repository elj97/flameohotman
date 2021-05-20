using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all the sound effects in game
/// 
/// To make a sound put in the relevant script:
/// 
///     GameObject manager;
///     Destruction_SFX soundEffects;
///     
///     void Awake ()
///     {
///         manager = GameObject.Find("Manager");
///         soundEffects = manager.GetComponent<SFX>();
///     }
///     
///     "Where you want the sound to be activated"
///     {
///         soundEffects.PlaySoundName();
///     }
///
/// </summary>

public class SFX : MonoBehaviour
{
    //public AudioSource name;

    //public void PlaySoundName()
    //{
    //    name.Play();
    //}

    Audio audioVariables;
    [HideInInspector]
    public AudioSource currentSoundtrack;

    private void Start()
    {
        audioVariables = GameObject.FindGameObjectWithTag("AudioVariables").GetComponent<Audio>();
        PlaySoundtrackOne();
    }

    public void PlaySoundtrackOne()
    {
        audioVariables.soundtrack_One.Play();
    }
    public void PlayExplosion()
    {
        audioVariables.explosion.Play();
    }
}
