using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spot : MonoBehaviour
{
    [SerializeField] private GameObject spot;
    [SerializeField] private GameObject player;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.y += 15;
        Instantiate(spot, playerPos, Quaternion.identity);
    }
}
