using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionExplosions : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Destroy(gameObject, 5);
    }
}
