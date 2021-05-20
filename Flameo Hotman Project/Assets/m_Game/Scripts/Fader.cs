using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Destroy(gameObject, 2.5f);
    }
}
