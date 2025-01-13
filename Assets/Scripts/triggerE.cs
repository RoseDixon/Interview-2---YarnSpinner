using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerE : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(uiObject);
            Destroy(gameObject);
        }
    }
}
