using UnityEngine;
using System.IO.Ports;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private string _portName = "COM3";
    [SerializeField] private int _baurate = 9600;
    [SerializeField] private float maxTiltAngle = 45f;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private bool debugMode = true;
    [SerializeField] private bool invertX = false; // X軸の反転
    [SerializeField] private bool invertY = false; // Y軸の反転
    [SerializeField] private bool invertZ = false; // Z軸の反転
    [SerializeField] private float sensitivityMultiplier = 2.0f; // 感度調整用の乗数

    private SerialPort serialPort;
    private Vector3 targetRotation;
    private Vector3 initialRotation;

    void Start()
    {
        try 
        {
            serialPort = new SerialPort(_portName, _baurate);
            serialPort.Open();
            Debug.Log("シリアルポートを開きました");
            
            // 初期回転を保存
            initialRotation = transform.rotation.eulerAngles;
        }
        catch (Exception ex)
        {
            Debug.LogError($"シリアルポートのオープンに失敗: {ex.Message}");
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try 
            {
                string data = serialPort.ReadLine();
                if (debugMode)
                {
                    Debug.Log($"受信データ: {data}");
                }

                string[] values = data.Split(',');
                
                if (values.Length == 3)
                {
                    // キャリブレーション済みの値を角度に変換
                    float x = float.Parse(values[0]) * sensitivityMultiplier;
                    float y = float.Parse(values[1]) * sensitivityMultiplier;
                    float z = float.Parse(values[2]) * sensitivityMultiplier;
                    
                    // 値の範囲を制限
                    x = Mathf.Clamp(x, -maxTiltAngle, maxTiltAngle);
                    y = Mathf.Clamp(y, -maxTiltAngle, maxTiltAngle);
                    z = Mathf.Clamp(z, -maxTiltAngle, maxTiltAngle);
                    
                    // 必要に応じて軸を反転
                    x *= invertX ? -1 : 1;
                    y *= invertY ? -1 : 1;
                    z *= invertZ ? -1 : 1;
                    
                    targetRotation = initialRotation + new Vector3(x, y, z);
                    
                    if (debugMode)
                    {
                        Debug.Log($"ステージの角度: X={x:F2}, Y={y:F2}, Z={z:F2}");
                    }

                    // より滑らかな回転の適用
                    Quaternion targetQuaternion = Quaternion.Euler(targetRotation);
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        targetQuaternion,
                        smoothSpeed
                    );
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"データ読み取りエラー: {ex.Message}");
            }
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("シリアルポートを閉じました");
        }
    }
}