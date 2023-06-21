using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopScript : MonoBehaviour
{
   
    void Start()
    {
        ShopController.instance.ShopPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            //ShopController.instance.isActive = true;
            ShopController.instance.ShopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMove playerMove = collision.GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            //ShopController.instance.isActive = false;
            ShopController.instance.ShopPanel.SetActive(false);
        }
    }
}
