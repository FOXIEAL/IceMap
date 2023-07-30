using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OnClicks : MonoBehaviour
{
    [SerializeField] private GameObject contribution;
    
    public void Title()
    {
        SceneManager.LoadScene("GPSTest");
    }

    public void Contribution()
    {
        contribution.SetActive(true);
    }
    
    public void ContributionBtn()
    {
        contribution.SetActive(false);
    }

    public void AllClear()
    {
        contribution.SetActive(false);
    }
}
