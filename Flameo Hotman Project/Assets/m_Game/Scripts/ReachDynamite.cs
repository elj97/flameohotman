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
    [Tooltip("In Seconds")]
    public int timeTo;

    IEnumerator Coroutine;

    private void Start()
    {
        Coroutine = ChangeScenes();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            StartCoroutine(Coroutine);
        }
    }

    IEnumerator ChangeScenes()
    {
        //Animate Flame
        //Animate TNT
        //Transition
        //Wait
        yield return new WaitForSeconds(timeTo);
        //Change Scenes
        SceneManager.LoadScene(newSceneName);
        yield return null;
    }
}
