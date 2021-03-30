using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AxController : MonoBehaviour
{
    bool flag = true;
    string[] TREES = { "BOTD0", "BOTD1", "BOTD2", "BOTD3", "BOTD4", "BOTD5"};
    string[] TREES_TAGS = { "botd0", "botd1", "botd2", "botd3", "botd4", "botd5"};
    //現在の木のobjectが何番か判断するためのカウント
    int j = 0;
    //傷の高さを調整するときに木をShakeしないようにするカウント
    int k = 0;
    //最初にスイング音ならすのをやめるためのカウント
    int l = 0;
    public ParticleSystem systemBullet;
    public ParticleSystem systemOgakuzu;
    public ParticleSystem systemOchiba;

    //public GameObject axe;
    public GameObject axeTip;

    public GameObject score_object_body = null; // Textオブジェクト
    public GameObject score_object_title = null; // Textオブジェクト
    public GameObject score_object_speed = null; // Textオブジェクト

    public GameObject botd0_object = null;
    public GameObject botd1_object = null;
    public GameObject botd2_object = null;
    public GameObject botd3_object = null;
    public GameObject botd4_object = null;
    public GameObject botd5_object = null;
    public GameObject parent2 = null;

    public GameObject finishMessage = null;

    public float swingSpeed = 5.0f;


    GameObject[] botd_objects;

    private Vector3 hitpos;
    private Vector3 hitpos_axetip;

    private Vector3 enterpos;
    ParticleSystem.EmitParams emitParams;

    GameObject unitychan; //Unityちゃんそのものが入る変数

    ShakeCamera script; //UnityChanScriptが入る変数

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private AudioSource audioSource;

    Vector3 latestPos;

    Text score_text_speed;




    // Start is called before the first frame update
    void Start()
    {
        //配列の初期化
        botd_objects = new GameObject[] { botd0_object, botd1_object, botd2_object, botd3_object, botd4_object, botd5_object };

        //  パーティクルを制御できるインスタンス
        emitParams = new ParticleSystem.EmitParams();
        //this.transform.Rotate(0.0f,90.0f,0.0f);
        Debug.Log("loaded!");

        score_text_speed = score_object_speed.GetComponent<Text>();



    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey("up"))
        {
            Debug.Log("up");
            transform.position += new Vector3(0, 0.1f, 0);
        }
        if (Input.GetKey("down"))
        {
            Debug.Log("down");
            transform.position += new Vector3(0, -0.1f, 0);
        }
        if (Input.GetKey("right"))
        {
            Debug.Log("right");
            transform.position += new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            Debug.Log("left");
            transform.position += new Vector3(-0.1f, 0, 0);
        }


        // もし速度がswingSpeed以上だったらスイング音を鳴らす
        score_text_speed.text = "speedは" + (((this.transform.position - latestPos) / Time.deltaTime).magnitude);
        if (((this.transform.position - latestPos) / Time.deltaTime).magnitude > swingSpeed)
        {
            if(l >0){
            //audioSource = gameObject.GetComponent<AudioSource>();
            //audioSource.clip = audioClip1;
            //audioSource.Play();
            }
            l++;
        }
        latestPos = this.transform.position;


    }


    void DoEmit()
    {
        //hitposaxetipsに変更
        //パーティクル発生角度を初期化
        systemBullet.transform.rotation = Quaternion.identity;
        systemOgakuzu.transform.rotation = Quaternion.identity;

        //現在の木オブジェクトのXとZの位置を入力
        Vector3 treepos = new Vector3(-0.8f, hitpos.y, 0);

        //木の中心と斧の位置から角度を求める
        float axeAngle = Vector3.Angle(hitpos, treepos);

        //パーティクル発生位置を木の中心に設定 -> 斧の先端に変更
        systemBullet.transform.position = hitpos_axetip;
        systemOgakuzu.transform.position = hitpos_axetip;

        Debug.Log("TreePos" + treepos);
        Debug.Log("Angle" + axeAngle);

        //パーティクル発生方向をY軸から中心の角度で指定
        //systemBullet.transform.rotation = Quaternion.AngleAxis(axeAngle, Vector3.up);
        //systemOgakuzu.transform.rotation = Quaternion.AngleAxis(axeAngle, Vector3.up);

        systemOgakuzu.transform.eulerAngles = axeTip.transform.eulerAngles;
        systemBullet.transform.eulerAngles = axeTip.transform.eulerAngles;

        //パーティクル発生
        systemBullet.Play();
        systemOgakuzu.Play();
        systemOchiba.Play();
        Debug.Log("パーティクルをぶっ放しました");
    }






    void OnTriggerExit(Collider other)
    {
        Debug.Log("hittedobject:" + other);
    }

    // 当たった時に呼ばれる関数
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("なにかが斧に触れました");
        Debug.Log("触れたオブジェクトのタグは" + other.gameObject.tag);

        // オブジェクトからTextコンポーネントを取得
        Text score_text_body = score_object_body.GetComponent<Text>();
        Text score_text_title = score_object_title.GetComponent<Text>();

        // テキストの表示を替える
        score_text_body.text = "タグは" + other.gameObject.tag;
        score_text_title.text = j + "回目の木";

        if (other.gameObject.tag == "flag" && flag == false)
        {
            flag = true;
        }

        if (other.gameObject.tag == "Tree")
        {

            //斧が木に触れたときに呼び出される
            //play sound effect
            GetComponent<AudioSource>().Play();  // 効果音を
                                                 //.....処理
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip2;
            audioSource.Play();
            //Debug.Log("木に触れたよ!!");
            //hitpos = other.ClosestPointOnBounds(this.transform.position);
            //hitpos = axe.transform.position;
            hitpos = this.transform.position;
            
            emitParams.position = hitpos;
            Debug.Log("hitPos" + hitpos);

            //ここでパーティクルを発生させる
            Invoke("DoEmit", 0f);


            //一回目のヒット時に当たった場所に傷の位置をもってくる
            if(k==0)
            {
                float positionDamage;
                hitpos_axetip = axeTip.transform.position;
                positionDamage = hitpos_axetip.y;
                Debug.Log("斧の先端の位置は" + hitpos_axetip.y);
                parent2.gameObject.transform.Translate(0, positionDamage - 0.737f - 0.30f, 0);
                k++;
            }

        }

        if (other.gameObject.tag == "Damage" && flag == true)
        {

            if (j < 5)
            {
                Debug.Log("------------------ダメージに"+(j+1)+"ヒット目-------------------");

                unitychan = parent2; //Unityちゃんをオブジェクトの名前から取得して変数に格納する

                Debug.Log(other + "に当たりました");

                script = unitychan.GetComponent<ShakeCamera>(); //unitychanの中にあるUnityChanScriptを取

                if(k!=0) script.Shake(); //UnityChanScriptにある関数Attackを実行する



                //斧が木に触れたときに呼び出される
                //play sound effect
                //GetComponent<AudioSource>().Play();  // 効果音を
                audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip2;
                audioSource.Play();
                
                                                     //.....処理
                //Debug.Log("木に触れたよ!!");
                //hitpos = other.ClosestPointOnBounds(this.transform.position);
                
                //hitpos = this.transform.position;
                hitpos = this.transform.position;
                emitParams.position = hitpos;
                Debug.Log("hitPos" + hitpos);

                //ここでパーティクルを発生させる
                Invoke("DoEmit", 0f);

                //次の木のobjectを有効にする
                botd_objects[j + 1].gameObject.SetActive(true);
                //今の木のobjectを無効にする
                botd_objects[j].gameObject.SetActive(false);

                //最後の木なら終了のメッセージを出す
                if (TREES_TAGS.Length-2 == j)
                {
                    finishMessage.gameObject.SetActive(true);

                }


                flag = false;

                j++;

            }
            else
            {
                Debug.Log("over!");
            }

        }

    }

}
