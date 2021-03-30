/**
* 動作確認用メインクラス
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class MainController : MonoBehaviour {
 
    protected RFIDHandler serial;
    string text = "";
    public float f;


    void Start () {
         
        // RFIDHandler がこのスクリプトと同じGameObjectにアタッチされているものとする
        serial = gameObject.GetComponent<RFIDHandler> ();
         
        // 受信イベントのリスナー
        serial.addEventListener (onMessage);

    }
     
    // 受信イベントハンドラ
    void onMessage(string msg)
    {
        //Debug.Log(msg);
        text = msg.Substring(2,5);

        f = float.Parse(text);
        //Debug.Log(f);



    }
}