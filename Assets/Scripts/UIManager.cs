using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image imgMainBGSound;
    public Image imgMainFXSound;
    public Image imgPauseBGSound;
    public Image imgPauseFXSound;
    private Music inst_Music;

    private void Start()
    {
        inst_Music = GetComponent<Music>();
    }

    public void OnClickBGSoundButton()
    {
        inst_Music.BGSoundMute();
        imgMainBGSound.sprite = inst_Music.imgMainBGSound;
        imgPauseBGSound.sprite = inst_Music.imgPauseBGSound;
    }

    public void OnClickFXSoundButton()
    {
        //inst_Music.BGSoundMute();
        //imgMainFXSound.sprite = inst_Music.imgMainFXSound;
        //imgPauseFXSound.sprite = inst_Music.imgPauseFXSound;
    }
}