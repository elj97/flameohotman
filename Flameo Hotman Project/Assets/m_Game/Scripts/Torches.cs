using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torches : MonoBehaviour
{

    public GameObject fireEffect;

    public Gate gateObj;

    [HideInInspector]
    public bool on;

    private bool hasSpawnedEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (hasSpawnedEffect == false)
            {
                Instantiate(fireEffect, transform.position, Quaternion.identity);
                hasSpawnedEffect = true;
            }
            gateObj.check = true;
            on = true;
        }
    }

}
