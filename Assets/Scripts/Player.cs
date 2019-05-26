using UnityEngine;

public class Player : MonoBehaviour
{
    public int screenWidth;
    public int screenHeight;
    public Vector3 position1 = new Vector3(-2, 0, 0);
    public Vector3 position2 = new Vector3(0, 0, 0);
    public Vector3 position3 = new Vector3(2, 0, 0);

    private void Awake()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void Start()
    {
        Debug.Log(screenWidth);
        Debug.Log(screenHeight);
        Debug.Log(this.transform.position);
        this.transform.position = position2;
    }

    public void OnClickButton1()
    {
        this.transform.position = position1;
    }

    public void OnClickButton2()
    {
        this.transform.position = position2;
    }

    public void OnClickButton3()
    {
        this.transform.position = position3;
    }
}