using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Reach Dynamite and Change Scenes
/// 
/// </summary>

public class ReachDynamite : MonoBehaviour
{
    public string newSceneName;
    [Tooltip("Keep this 0 in the level select scene!!!")]
    public int levelNumber;
    [Tooltip("In Seconds")]
    public float timeTo;
    public int secondaryExplosionAmount;

    public GameObject explosionEffect;
    public GameObject secondaryExplosionEffect;

    [HideInInspector]
    public bool isLevel = true;

    IEnumerator Coroutine;

    SFX soundEffects;

    private void Start()
    {
        Coroutine = ChangeScenes();
        soundEffects = GameObject.FindGameObjectWithTag("GameController").GetComponent<SFX>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isLevel == true)
            {
                StartCoroutine(Coroutine);
            }
        }
    }
/*
    private void Update()
    {
        print("Levels Completed: " + StaticSettings.levelsCompleted);
    }
*/

    IEnumerator ChangeScenes()
    {
        //CompleteLevel
        if (StaticSettings.levelsCompleted < levelNumber + 1)
        {
            StaticSettings.levelsCompleted = levelNumber + 1;
        }
        //Play Sound
        soundEffects.PlayExplosion();
        //Animate TNT
        Destroy(this.transform.GetChild(0).gameObject);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        //Transition
        while (secondaryExplosionAmount > 0)
        {
            Instantiate(secondaryExplosionEffect, transform.position, Quaternion.identity);
            secondaryExplosionAmount--;
        }
        //Wait
        yield return new WaitForSeconds(timeTo);
        //Change Scenes
        SceneManager.LoadScene(newSceneName);
        yield return null;
    }
}
