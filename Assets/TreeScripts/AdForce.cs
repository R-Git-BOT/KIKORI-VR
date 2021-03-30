using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdForce : MonoBehaviour
{

    public AudioClip pianoSound;
    private AudioSource audioSource;
    int i = 0;

    float rotation_speed = 0; // 回転速度
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 回転速度分回す
        transform.Rotate(this.rotation_speed, 0, 0);
    }


    // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag + "にあたってるよ");

        if (other.gameObject.tag == "fallentree" && i==0)
        {
            Debug.Log("発進！！");

            this.rotation_speed = 15.0f;

            audioSource.PlayOneShot(pianoSound);

            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            rb.useGravity = true;
            Vector3 force = new Vector3(-30.0f, 20.0f, -20.0f);  // 力を設定
            rb.AddForce(force, ForceMode.Impulse);          // 力を加える

            i++;
        }

        if (other.gameObject.tag == "Ground")
        {
            this.rotation_speed = 0.0f;
        }

    }



}
