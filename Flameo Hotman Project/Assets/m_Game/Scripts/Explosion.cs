using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject[] circleParents;
    public GameObject TransitionCircle;

    private bool exploding;

    private IEnumerator Coroutine;

    public bool transitionTime;

    private void Start()
    {
        Coroutine = ExplodingCircles();
        StartCoroutine(Coroutine);
        exploding = true;
    }

    public void Explode()
    {
        StartCoroutine(Coroutine);
        exploding = true;
    }

    private IEnumerator ExplodingCircles()
    {
        var ranWait = Random.Range(0.001f, 0.05f);
        yield return new WaitForSeconds(ranWait);
        var ranCircle = Random.Range(0, circleParents.Length);
        var currentCircle = circleParents[ranCircle];
        if (currentCircle != null)
        {
            if (currentCircle.activeInHierarchy == false)
            {
                //Activate current Circle
                currentCircle.SetActive(true);

                //Activate Coroutine for deactivated once animation is over
                StartCoroutine(DeactivateCircle(currentCircle));

                //Randomise Position
                currentCircle.transform.position = new Vector3(Random.Range(-0.75f, 0.75f), Random.Range(-0.75f, 0.75f), 0);

                //Randomise Size
                var ranSize = Random.Range(0.75f, 1.4f);
                currentCircle.transform.localScale = new Vector3(ranSize, ranSize, 1);

                //Randomise Colour
                if (Random.Range(0f, 1f) < 0.8f)
                {
                    var sprite = currentCircle.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
                    sprite.color = new Color(1, Random.Range(0f, 1f), 0, 1);
                }
                else
                {
                    var sprite = currentCircle.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
                    sprite.color = new Color(1, 1, 1, 1);
                }
            }
        }
        if (transitionTime == true)
        {
            TransitionCircle.SetActive(true);
        }
        StartCoroutine(ExplodingCircles());
    }

    private IEnumerator DeactivateCircle(GameObject circle)
    {
        yield return new WaitForSeconds(0.6f);
        circle.SetActive(false);
        yield return null;
    }
    
}
