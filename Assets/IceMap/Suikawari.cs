using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Suikawari : MonoBehaviour
{
    private bool counter_flag;
    private float elapsedTime;
    private float randomTime;
    private float responseTime;
    private float responseEnemy = 0.5f;

    [SerializeField] private GameObject tapStartobj1;
    [SerializeField] private Button tapStartBtn1;
    [SerializeField] private GameObject tapStartobj2;
    [SerializeField] private Button tapStartBtn2;
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject miai;
    [SerializeField] private GameObject bikkuri;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    [SerializeField] private GameObject otetuki;
    
    void Start()
    {
        tapStartBtn1.onClick.AddListener(TapStart);
        tapStartBtn2.onClick.AddListener(TapStop);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter_flag)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log("計測中： " + (elapsedTime).ToString());
        }
    }


    void TapStart()
    {
        tapStartobj1.SetActive(false);
        startText.SetActive(false);
        miai.SetActive(true);
        Invoke("Miai", 3);
    }

    void TapStop()
    {
        bikkuri.SetActive(false);
        counter_flag = !counter_flag;
        tapStartobj2.SetActive(false);
        Debug.Log(elapsedTime);
        if (elapsedTime < randomTime)
        {
            otetuki.SetActive(true);
        }
        else
        { 
            responseTime = randomTime - elapsedTime;
            if(responseTime < responseEnemy) win.SetActive(true);
            else lose.SetActive(false);
        }

        elapsedTime = 0;
    }

    void Miai()
    {
        randomTime = Random.Range(3, 6);
        Invoke("ShowSetuna", randomTime);
        miai.SetActive(false);
        tapStartobj2.SetActive(true);
        counter_flag = !counter_flag;
    }

    void ShowSetuna()
    {
        bikkuri.SetActive(true);
        Invoke("DeleteSetune", 1);
    }

    void DeleteSetune()
    {
        bikkuri.SetActive(true);
    }
}
