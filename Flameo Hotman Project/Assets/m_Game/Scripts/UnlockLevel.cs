using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{

    public int levelNumber;
    private ReachDynamite reachDynamite;
    private SpriteRenderer sprite;

    private void Start()
    {
        reachDynamite = this.GetComponent<ReachDynamite>();
        sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (StaticSettings.levelsCompleted >= levelNumber)
        {
            reachDynamite.isLevel = true;
            sprite.color = new Color(1, 1, 1, 1);
        }
        else
        {
            reachDynamite.isLevel = false;
            sprite.color = new Color(0.4f, 0.4f, 0.4f, 1);
        }
    }

}
