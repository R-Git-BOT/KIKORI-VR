using UnityEngine;
using System.Collections;
using UnityEngine.UI;//この宣言が必要
public class MessageTestC : MonoBehaviour
{
    Text myText;
    // Use this for initialization
    void Start()
    {
        myText = GetComponentInChildren<Text>();//UIのテキストの取得の仕方
        myText.text = "木をこれ！！";//テキストの変更
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
    }
}
