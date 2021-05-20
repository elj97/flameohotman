using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject gateEffect;

    public Torches[] torches;

    [HideInInspector]
    public bool check;

    [HideInInspector]
    public bool on = true;

    private bool checkingOn;

    private ParticleSystem parSystem;

    private GameObject child;

    private void Start()
    {
        var obj = Instantiate(gateEffect, transform.position, Quaternion.identity);
        parSystem = obj.GetComponent<ParticleSystem>();
        child = this.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (check == true)
        {
            checkingOn = true;
            for (int i = 0; i < torches.Length; i++)
            {
                if (torches[i].on == false)
                {
                    checkingOn = false;
                }
            }
            if (checkingOn == true)
            {
                on = false;
            }
            check = false;
        }

        if (on == false)
        {
            parSystem.Stop();
            child.SetActive(false);
        }

    }

}
