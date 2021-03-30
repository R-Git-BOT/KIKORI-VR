using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//この宣言が必要
using UnityEngine.SceneManagement;



public class MessageTutorial : MonoBehaviour
{
    Text myText;

    public GameObject tree = null;
    public GameObject axe = null;


    // Use this for initialization
    void Start()
    {
        myText = GetComponentInChildren<Text>();//UIのテキストの取得の仕方
        myText.text = "ようこそ、チュートリアルシーンです";//テキストの変更
    }


    float TimeCount = 0;
    float TimeCount2 = 0;
    bool flag = false;
    bool flag_finish = false;


    void Update()
    {

        TimeCount += Time.deltaTime;



        if (TimeCount >= 7&& TimeCount <= 10)
        {
            myText.text = "木こりをいきなり実践するのは危険なのでここで少し練習していきましょう";
        }

        if (TimeCount >= 12 && TimeCount <= 14)
        {
            myText.text = "そこに木と";
            tree.gameObject.SetActive(true);
        }

        if (TimeCount >= 16 && TimeCount <= 18)
        {
            myText.text = "下のほうに斧がありますね";
            axe.gameObject.SetActive(true);

        }

        if (TimeCount >= 20 && TimeCount <= 22)
        {
            myText.text = "(スカスカですけど...)";
        }

        if (TimeCount >= 24 && TimeCount <= 26)
        {
            myText.text = "試しにそこの木を";
        }
        if (TimeCount >= 28 && TimeCount <= 30)
        {
            myText.text = "斧で2回叩いてみましょう";
        }

        if (myText.text == "Great!!")
        {
            if (flag)
            {
                myText.text = "Perfect!!";
                flag = false;
                flag_finish = true;
            }

            TimeCount2 += Time.deltaTime;
            if(TimeCount2 >= 2 && TimeCount2 <= 10)
            {
                myText.text = "さらにもう一発!!";
                flag = true;
                TimeCount2 = 100f;
            }


        }

        if (flag_finish)
        {
            TimeCount2 += Time.deltaTime;
            if (TimeCount2 >= 105f && TimeCount2 <= 107f)
            {
                myText.text = "それでは本番どうぞ！！";

            }
            if (TimeCount2 >= 109f && TimeCount2 <= 111f)
            {
                myText.text = "現実そっくりな森が再現されてます。";
            }
            if (TimeCount2 >= 111f && TimeCount2 <= 120f)
            {
                myText.text = "周りの景色を楽しみながらゆっくり体験してください";
            }

            if (TimeCount2 >= 115f && TimeCount2 <= 120f)
            {
                myText.text = "木は頑丈なので強くたたいていいですよ。";
            }

            if (TimeCount2 >= 118f && TimeCount2 <= 128f)
            {
                myText.text = "少しロードが入ります";
            }
            if (TimeCount2 >= 119f && TimeCount2 <= 128f)
            {
                SceneManager.LoadScene("KikoriScene");
            }
        }
 

    }




}
