/**
* SerialConnector クラスを拡張したサブクラス
* このクラスで機器に適合した設定や受信処理を実装
*（今回は大信機器製のRFIDリーダーライター HF-06）
**/
 
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using UnityEngine;
 
public class RFIDHandler : SerialConnector {
 
    // delegate で　EventDispatcher を作成
    public delegate void Dispatcher(string msg);
    private Dispatcher _dispatcher; // Dispatcher をインスタンス化
     
    // Dispatcher のコールバック関数
    public void addEventListener(Dispatcher dispatcher) {
        _dispatcher += dispatcher;
    }
 
    public string message = "0";
    protected bool _isMessageReaded;
 
    void Start(){
 
        // シリアルポート設定
        _parity = Parity.None;
        _databits = 8;
        _stopbits = StopBits.One;
        _readTimeout = 500;
        _writeTimeout = 1000;
 
        // オープンしたら読み取りスレッドを開始
        if (open ()) {
            //
            _isRunning = true;
            _thread = new Thread(run);
            _thread.Start();
 
            //　かきこみ
            Debug.Log("かきこみました");
            _serialPort.Write("XAG\r");
            //_serialPort.Write("XAG\r");
        }
    }

    private void OnDisable()
    {
        _serialPort.Write("XAS\r");
    }


    void Update () {
 
        if (_isMessageReaded)
        {
            //_serialPort.Write("2XS\r");
            _isMessageReaded = false;
        }
 
    }
 
 
    // Read（RFIDリーダー HF-06 のシリアル受信処理）
    public override void serialRead()
    {
        message = "0";
        try
        {
            string data = _serialPort.ReadTo("\r");
 
            // タグを認識したら19文字のデータが来て待ち受け終了するので
            // 機器に次の待ち受け開始コマンド送信する
            if (data.Length == 19)
            {
                _isMessageReaded = true;
            }
 
            _dispatcher (data);
 
        }
        catch (System.Exception e)
        {
            //Debug.LogWarning(e.Message);
        }
    }
}