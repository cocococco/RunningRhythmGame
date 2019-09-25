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
    private bool isIgenoreCollision = false;
    public GameObject shieldFx;

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
        shieldFx.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
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
        bool isKinematic = myRigidbody.isKinematic;
        bool isTrigger = myCollider.isTrigger;

        if (isKinematic == true && isTrigger == true) // 실드 상태일 때에도 치트 끄면 충돌 활성화됨. 중요한 게 아니니 보류.
        {
            myRigidbody.isKinematic = false;
            myCollider.isTrigger = false;
            isIgenoreCollision = false;
        }
        else if (isKinematic == false && isTrigger == false)
        {
            myRigidbody.isKinematic = true;
            myCollider.isTrigger = true;
            isIgenoreCollision = true;
        }
        else
        {
            Debug.LogError("ignore collision error");
        }
    }

    public void ShieldCollisionOn()
    {
        shieldFx.SetActive(true);

        if (isIgenoreCollision == true) return;

        myRigidbody.isKinematic = true;
        myCollider.isTrigger = true;
    }

    public void ShieldCollisionOff()
    {
        shieldFx.SetActive(false);

        if (isIgenoreCollision == true) return;

        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
    }
}