using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotate : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(-2.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler (Time.deltaTime*speed, 0, 0);
    }
}
