using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    public Sprite[] imgMainBGSounds = new Sprite[2];
    public Sprite[] imgMainFXSounds = new Sprite[2];
    public Sprite[] imgPauseBGSounds = new Sprite[2];
    public Sprite[] imgPauseFXSounds = new Sprite[2];
    private SystemManager inst_SystemManager;

    private Image curImage;

    private void Start()
    {
        curImage = GetComponent<Image>();
    }

    public void OnClickMainBGSoundButton()
    {
        if (SystemManager.mainMusic.volume == 0)
        {
            SystemManager.mainMusic.volume = 1;
            curImage.sprite = imgMainBGSounds[1];
        }
        else
        {
            SystemManager.mainMusic.volume = 0;
            curImage.sprite = imgMainBGSounds[0];
        }
    }

    public void OnClickMainFXSoundButton()
    {
        if (SystemManager.mainMusic.volume == 0)
        {
            SystemManager.mainMusic.volume = 1;
            curImage.sprite = imgMainFXSounds[1];
        }
        else
        {
            SystemManager.mainMusic.volume = 0;
            curImage.sprite = imgMainFXSounds[0];
        }
    }

    public void OnClickPauseBGSoundButton()
    {
        if (SystemManager.mainMusic.volume == 0)
        {
            SystemManager.mainMusic.volume = 1;
            curImage.sprite = imgPauseBGSounds[1];
        }
        else
        {
            SystemManager.mainMusic.volume = 0;
            curImage.sprite = imgPauseBGSounds[0];
        }
    }

    public void OnClickPauseFXSoundButton()
    {
        if (SystemManager.mainMusic.volume == 0)
        {
            SystemManager.mainMusic.volume = 1;
            curImage.sprite = imgPauseFXSounds[1];
        }
        else
        {
            SystemManager.mainMusic.volume = 0;
            curImage.sprite = imgPauseFXSounds[0];
        }
    }
}