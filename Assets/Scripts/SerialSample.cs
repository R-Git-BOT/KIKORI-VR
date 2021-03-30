using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialSample : MonoBehaviour
{
    private SerialPortWrapper _serialPort;

    void Awake()
    {
        _serialPort = new SerialPortWrapper("COM16", 9600);
    }

    private void OnDisable()
    {
        _serialPort.KillThread();
    }

    void OnGUI()
    {
        if (GUILayout.Button("1", GUILayout.Width(200f), GUILayout.Height(60f)))
        {
            // 文字列nを送信
            _serialPort.Write("1");
        }

        if (GUILayout.Button("f", GUILayout.Width(200f), GUILayout.Height(60f)))
        {
            // 文字列fを送信
            _serialPort.Write("f");
        }
    }
}