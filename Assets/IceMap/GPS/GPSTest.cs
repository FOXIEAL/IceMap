using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GPSTest : MonoBehaviour
{
    public float latitude;
    public float longitude;
    public float altitude;

    [SerializeField] private TextMeshProUGUI ido;
    [SerializeField] private TextMeshProUGUI keido;
    [SerializeField] private TextMeshProUGUI koudo;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        // スマホの許可
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS not enabled");
            yield break;
        }

        // 位置取得スタート
        Input.location.Start();

        // ２０秒まつ
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // ２０秒立ったのでタイムアウト
        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // コネクト切れたので終わる
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        // 情報取得
        while (true)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            altitude = Input.location.lastData.altitude;
            ido.text = "緯度：" + latitude;
            keido.text = "経度：" + longitude;
            koudo.text = "高度：" + altitude;
            yield return new WaitForSeconds(10);
        }
    }
}
