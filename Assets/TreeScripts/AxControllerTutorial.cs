using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AxControllerTutorial : MonoBehaviour
{


    //public GameObject axe;
    public GameObject axeTip;

    public GameObject text_object_body = null; // Textオブジェクト



    public GameObject parent = null;

    private Vector3 hitpos;
    private Vector3 hitpos_axetip;

    private Vector3 enterpos;

    Text bodytext;






    // Start is called before the first frame update
    void Start()
    {

        bodytext = text_object_body.GetComponent<Text>();


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




    }


    void DoEmit()
    {

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
        if (other.gameObject.tag == "meshtree")
        {
            bodytext.text = "Great!!";
            GetComponent<AudioSource>().Play();  // 効果音を

        }

    }
}
