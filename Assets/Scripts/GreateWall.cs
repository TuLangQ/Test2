using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreateWall : MonoBehaviour
{
    private static GreateWall _Ins;
    public static GreateWall Instance
    {
        get
        {
            return _Ins;
        }
    }

    public Text text1;
    public Text text2;

    public Transform player1;
    public Transform player2;

    private int sorce1;
    private int sorce2;

    private BoxCollider2D upCollider2D;
    private BoxCollider2D downCollider2D;
    private BoxCollider2D rightCollider2D;
    private BoxCollider2D leftCollider2D;

    void Awake()
    {
        _Ins = this;
        upCollider2D = transform.GetChild(0).GetComponent<BoxCollider2D>();
        downCollider2D = transform.GetChild(1).GetComponent<BoxCollider2D>();
        rightCollider2D = transform.GetChild(2).GetComponent<BoxCollider2D>();
        leftCollider2D = transform.GetChild(3).GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetWall();
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ResetWall()
    {
        Vector3 vector = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        upCollider2D.transform.position = new Vector3(0, vector.y+ 0.25f, 0);
        downCollider2D.transform.position = new Vector3(0, -vector.y- 0.25f, 0);
        rightCollider2D.transform.position = new Vector3(-vector.x- 0.25f, 0, 0);
        leftCollider2D.transform.position = new Vector3(vector.x+ 0.25f, 0, 0);

        //float width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x * 2;
        //float height = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y * 2;

        upCollider2D.size = new Vector2(vector.x * 2, 0.5f);
        downCollider2D.size = new Vector2(vector.x * 2, 0.5f);
        rightCollider2D.size = new Vector2(0.5f, vector.y * 2);
        leftCollider2D.size = new Vector2(0.5f, vector.y * 2);
    }

    private void ResetPlayer()
    {
        Vector3 vector = Camera.main.ScreenToWorldPoint(new Vector2(100, Screen.height / 2));
        vector.z = 0;
        player1.position = vector;

        Vector3 vector1 = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 100, Screen.height / 2));
        vector1.z = 0;
        player2.position = vector1;

    }

    public void ChangeSorce(string name)
    {
        if(name=="rightWall")
        {
            sorce1++;
            text1.text = sorce1.ToString();
        }
        else if(name =="leftWall")
        {
            sorce2++;
            text2.text = sorce2.ToString();
        }
    }

    public void Reset()
    {
        sorce1 = 0;
        sorce2 = 0;
        text1.text = sorce1.ToString();
        text2.text = sorce2.ToString();
        GameObject.Find("Ball").SendMessage("Reset");
    }
}
