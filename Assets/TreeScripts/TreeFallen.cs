using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeFallen : MonoBehaviour
{
    public AudioClip audioClip1;
    private AudioSource audioSource;

    GameObject unitychan; //Unityちゃんそのものが入る変数

    ShakeCamera script; //UnityChanScriptが入る変数

    public GameObject daiti;

    int i = 0;
    int j = 0;
    int k = 0;

    float rotation_speed = 0; // 回転速度




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (k > 0) j++;
        //if (j >= 500) SceneManager.LoadScene("TitleScene");
        // 回転速度分回す
        transform.Rotate(0, -this.rotation_speed, 0);
    }


    // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            k++;
            //GetComponent<AudioSource>().Play();  // 効果音を
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip1;

            //unitychan = daiti; //Unityちゃんをオブジェクトの名前から取得して変数に格納する

            this.rotation_speed = 15.0f;

            //script = unitychan.GetComponent<ShakeCamera>(); //unitychanの中にあるUnityChanScriptを取る

            if (i == 0)
            {
                audioSource.Play();
                //script.Shake(); //UnityChanScriptにある関数Attackを実行する
            }

            i++;
        }
    }



}
