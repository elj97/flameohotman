using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocationInitiate : MonoBehaviour
{

    private FlameController flameController;

    private void Start()
    {
        flameController = GameObject.FindWithTag("Player").GetComponent<FlameController>();
    }

    private void OnMouseEnter()
    {
        flameController.followingCursor = true;
        Destroy(this.transform.GetChild(0).gameObject);
    }
}
