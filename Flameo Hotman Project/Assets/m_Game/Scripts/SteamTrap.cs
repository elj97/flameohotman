using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTrap : MonoBehaviour
{
    public GameObject steamEffect;
    public float gapTimeOn;
    public float gapTimeOff;

    public float hesitateTime;
    private bool hesitated;

    private GameObject ingameSteam;
    private GameObject child;

    private ParticleSystem steamParticle;

    private void Start()
    {
        var obj = Instantiate(steamEffect, transform.position, Quaternion.identity);
        ingameSteam = obj;
        child = this.transform.GetChild(0).gameObject;
        steamParticle = ingameSteam.GetComponent<ParticleSystem>();
        StartCoroutine(OnOff());
    }

    IEnumerator OnOff()
    {
        if (hesitated == false)
        {
            yield return new WaitForSeconds(hesitateTime);
            hesitated = true;
        }
        //Off
        steamParticle.Stop();
        child.SetActive(false);

        yield return new WaitForSeconds(gapTimeOff);

        //On
        steamParticle.Play();
        child.SetActive(true);

        yield return new WaitForSeconds(gapTimeOn);

        print("got through it all");

        StartCoroutine(OnOff());
        yield return null;
    }
}
