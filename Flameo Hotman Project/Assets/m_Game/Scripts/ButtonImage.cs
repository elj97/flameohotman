using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImage : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button but;

    [HideInInspector]
    public bool on;

    public void ChangeImage()
    {
        if (but.image.sprite == OnSprite)
        {
            but.image.sprite = OffSprite;
            on = false;
        }
        else
        {
            but.image.sprite = OnSprite;
            on = true;
        }
    }
}
