using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEditor.Experimental.U2D;

public class texture : MonoBehaviour
{
    public SpriteAtlas m_atlas;
    public Image m_img1;
    public Image m_img2;
    public Image m_img3;
    public Image m_img4;
    public Image m_img5;
    public Image m_img6;
    public Image m_img7;
    public Image m_img8;
    public Image m_img9;
    public Image m_img10;
    public Image m_img11;
    public Image m_img12;
    public Image m_img13;
    public Image m_img14;
    public Image m_img15;
    public Image m_img16;

    void Start()
    {
        m_img1.sprite = m_atlas.GetSprite("02");
        m_img2.sprite = m_atlas.GetSprite("4tree");
        m_img3.sprite = m_atlas.GetSprite("4tree 1");
        m_img4.sprite = m_atlas.GetSprite("4tree 2");
        m_img5.sprite = m_atlas.GetSprite("4tree 3");
        m_img6.sprite = m_atlas.GetSprite("bread-uv-color");
        m_img7.sprite = m_atlas.GetSprite("gingerbreadman");
        m_img8.sprite = m_atlas.GetSprite("cake 1");
        m_img9.sprite = m_atlas.GetSprite("hansel_uv_color");
        m_img10.sprite = m_atlas.GetSprite("Log_uv");
        m_img11.sprite = m_atlas.GetSprite("monnster red");
        m_img12.sprite = m_atlas.GetSprite("monster green 1");
        m_img13.sprite = m_atlas.GetSprite("monster yellow");
        m_img14.sprite = m_atlas.GetSprite("purple mushroom");
        m_img15.sprite = m_atlas.GetSprite("red mushroom");
        m_img16.sprite = m_atlas.GetSprite("track_uv_color");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
