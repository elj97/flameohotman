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

    IEnumerator Coroutine;

    private void Start()
    {
        Coroutine = AnimateAndDie();
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
