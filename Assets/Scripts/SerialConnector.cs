/**
* シリアル接続の基本クラス
* 受信処理の実装は使用する機器ごとに違うので
* このクラスを拡張して実装する
**/
 
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using UnityEngine;
 
public class SerialConnector : MonoBehaviour {
 
    protected SerialPort _serialPort;
 
    // ボート名などはエディタから設定できる
    public string portName = "COM3";
    public int baudRate = 38400;
    public int threadSleepTime = 100;
 
    // シリアル設定用パラメータ
    protected Parity _parity;
    protected int _databits;
    protected StopBits _stopbits;
    protected int _readTimeout;
    protected int _writeTimeout;
 
    // スレッド
    protected Thread _thread;
    protected bool _isRunning;
 
 
    // 終了処理
    protected void OnDestroy()
    {
        close();
    }
 
 
    // シリアルポートを開いて接続
    protected bool open()
    {
        try
        {
            // ポート名, ボーレート, パリティチェック, データビット長, ストップビット長,
            // 読み取り時タイムアウト, 書き込み時タイムアウトを設定してポートを開く
            _serialPort = new SerialPort(portName, baudRate, _parity, _databits, _stopbits);
            _serialPort.ReadTimeout = _readTimeout;
            _serialPort.WriteTimeout = _writeTimeout;
            _serialPort.Open();
        }
        catch (System.Exception e) {
            Debug.LogWarning (e.Message);
        }
 
        return _serialPort.IsOpen;
    }
 
 
    // スレッドを停止してシリアルポートを閉じる
    protected void close()
    {
        _isRunning = false;
 
        if(_thread != null && _thread.IsAlive)
        {
            _thread.Abort();
        }
 
        if(_serialPort != null && _serialPort.IsOpen)
        {
            _serialPort.Close();
            _serialPort.Dispose();
        }
    }
 
 
    // スレッドラン
    protected void run()
    {
        while (_isRunning && _serialPort != null && _serialPort.IsOpen) {
 
            // 受信バッファをクリア
            try
            {
                _serialPort.DiscardInBuffer ();
            }
            catch (System.Exception e) {
                Debug.LogWarning (e.Message);
            }
 
            //
            Thread.Sleep (threadSleepTime);
 
            // 読み取り
            serialRead ();
        }
    }
 
 
    // シリアルポート読み取り処理（シリアル受信処理）
    public virtual void serialRead()
    {
        // 実装はサブクラスでオーバーライドする
    }
}