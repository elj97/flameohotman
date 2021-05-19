using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Restarting the scene
/// </summary>

public class Restart : MonoBehaviour
{
    private Scene loadedScene;
    [Tooltip("In Seconds")]
    public int timeTo;

    private IEnumerator Coroutine;

    private void Start()
    {
        Coroutine = RestartScene();
    }

    public void StartTheCoroutine()
    {
        StartCoroutine(Coroutine);
    }

    IEnumerator RestartScene()
    {
        //Animate Flame
        //Animate TNT
        //Transition
        //Wait
        yield return new WaitForSeconds(timeTo);
        //Change Scenes
        loadedScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedScene.name);
        yield return null;
    }
}
