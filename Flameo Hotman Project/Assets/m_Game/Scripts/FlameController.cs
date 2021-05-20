using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    public float speed;
    public float rotationOffset;

    
    public bool followingCursor;

    public GameObject flameEffect;

    private void Start()
    {
        Instantiate(flameEffect, transform.position, Quaternion.identity, this.transform);
    }

    void Update()
    {
        if (followingCursor == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            followingCursor = !followingCursor;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            followingCursor = !followingCursor;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            followingCursor = !followingCursor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dangerous")
        {
            this.gameObject.GetComponent<ExtinguishPlayer>().Extinguish();
        }
    }
}
