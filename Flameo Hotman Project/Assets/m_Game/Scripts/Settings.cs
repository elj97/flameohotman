using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public ButtonImage buttonSFX;
    public ButtonImage buttonMusic;

    private Image sfxImage;
    private Image musicImage;

    private void Start()
    {
        sfxImage = buttonSFX.gameObject.GetComponent<Image>();
        musicImage = buttonMusic.gameObject.GetComponent<Image>();

        if (StaticSettings.sfx == true)
        {
            buttonSFX.on = true;
            sfxImage.sprite = buttonSFX.OnSprite;
        }
        else
        {
            buttonSFX.on = false;
            sfxImage.sprite = buttonSFX.OffSprite;
        }

        if (StaticSettings.music == true)
        {
            buttonMusic.on = true;
            musicImage.sprite = buttonMusic.OnSprite;
        }
        else
        {
            buttonMusic.on = false;
            musicImage.sprite = buttonMusic.OffSprite;
        }
    }

    private void Update()
    {
        if (buttonSFX.on == true)
        {
            StaticSettings.sfx = true;
        }
        else
        {
            StaticSettings.sfx = false;
        }
        if (buttonMusic.on == true)
        {
            StaticSettings.music = true;
        }
        else
        {
            StaticSettings.music = false;
        }
    }

}
