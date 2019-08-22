using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player GetInstance()
    {
        return instance;
    }

    public float posX1 = -2;
    public float posX2 = 0;
    public float posX3 = 2;
    public float speed = 0.5f;

    private AudioSource footStepSound;

    private Rigidbody myRigidbody;
    private CapsuleCollider myCollider;

    public bool isShield { get; set; }
    public bool shieldDone { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            DestroyImmediate(this);
        }
    }

    private void Start()
    {
        footStepSound = GetComponent<AudioSource>();
        footStepSound.Play();
        footStepSound.loop = true;
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        isShield = false;
        shieldDone = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchIgnoreCollisions();
        }
    }

    public void OnClickTrackButton1()
    {
        this.transform.DOMoveX(posX1, speed);
    }

    public void OnClickTrackButton2()
    {
        this.transform.DOMoveX(posX2, speed);
    }

    public void OnClickTrackButton3()
    {
        this.transform.DOMoveX(posX3, speed);
    }

    public void SwitchIgnoreCollisions()
    {
        myRigidbody.isKinematic = !myRigidbody.isKinematic;
        myCollider.isTrigger = !myCollider.isTrigger;
    }

    public void IgnoreCollisionsOn()
    {
        myRigidbody.isKinematic = true;
        myCollider.isTrigger = true;
    }

    public void IgnoreCollisionsOff()
    {
        //myRigidbody.isKinematic = false;
        //myCollider.isTrigger = false;
    }
}