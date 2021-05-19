using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliding : MonoBehaviour
{
    Restart restart;
    GameObject gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        restart = gameController.GetComponent<Restart>();
    }

    private void OnMouseEnter()
    {
        restart.StartTheCoroutine();
    }
}
