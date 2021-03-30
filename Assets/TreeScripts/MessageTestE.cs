using UnityEngine;
using System.Collections;
using UnityEngine.UI;//この宣言が必要

public class MessageTestE : MonoBehaviour
{
    Text myText;
    // Use this for initialization
    int i = 0;

    public GameObject Message0 = null;
    public GameObject Message1 = null;
    public GameObject Message2 = null;
    public GameObject Message3 = null;
    public GameObject Message4 = null;


    void Start()
    {
        myText = GetComponentInChildren<Text>();//UIのテキストの取得の仕方
        //myText.text = "木をこれ！！";//テキストの変更


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            myText.text = "代替テキストC２";
        }
        if (Input.GetKeyDown("space"))
        {
            myText.text = "代替テキストC３";
        }

        if (i == 300)
        {
            Destroy(this.gameObject);

        }

        if (i % 20 == 0)
        {
            myText.fontSize = 40;
        }

        if (i % 40 == 20)
        {
            myText.fontSize = 30;
        }


        if (i == 30)
        {
            Message1.gameObject.SetActive(true);

        }

        if (i == 60)
        {
            Message2.gameObject.SetActive(true);

        }

        if (i == 90)
        {
            Message0.gameObject.SetActive(true);

        }

        if (i == 120)
        {
            Message3.gameObject.SetActive(true);

        }

        if (i == 150)
        {
            Message4.gameObject.SetActive(true);

        }



        i++;


    }
}

