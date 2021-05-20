using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtinguishPlayer : MonoBehaviour
{
    private Scene loadedScene;
    public GameObject smokeEffect;
    public GameObject fader;
    public float timeTo;

    public bool extinguish;

    private ScreenShakeController screenShake;

    IEnumerator Coroutine;

    private void Start()
    {
        Coroutine = AnimateAndDie();
        screenShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShakeController>();
    }

    public void Extinguish()
    {
        StartCoroutine(Coroutine);
    }

    IEnumerator AnimateAndDie()
    {
        //Animate Flame
        ParticleSystem childParticle = this.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        childParticle.Stop();
        Instantiate(smokeEffect, transform.position, Quaternion.identity);
        screenShake.StartShake(.1f, .1f);
        //Wait
        yield return new WaitForSeconds(timeTo);
        //Change Scenes
        Instantiate(fader, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.2f);
        loadedScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedScene.name);
        yield return null;
    }

}
