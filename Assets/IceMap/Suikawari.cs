using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suikawari : MonoBehaviour
{
    private bool counter_flag;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spaceキーで計測開始、停止を切り替え
        if (Input.GetKey(KeyCode.Space))
        {        
            counter_flag = !counter_flag;
        }
 
        if (counter_flag == true)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log("計測中： " + (elapsedTime).ToString());
        }
    }
}
