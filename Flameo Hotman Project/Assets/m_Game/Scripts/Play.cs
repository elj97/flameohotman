using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    public string sceneToGo;
    public GameObject fader;

    IEnumerator Coroutine;

    private void Start()
    {
        Coroutine = MoveScenes();
    }

    public void LevelSelect()
    {
        StartCoroutine(Coroutine);
    }

    IEnumerator MoveScenes()
    {
        Instantiate(fader, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(sceneToGo);
        yield return null;
    }

}
