using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemScript : MonoBehaviour
{
    public ItemScript shopItem;

    public PlayerController playerController;
    public PlayerFeatures Stats;
    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
    }
    public void PaySome()
    {
        Stats.BitCoins -= shopItem.cost;

        InventoryController.Instance.Add(shopItem);

        Destroy(gameObject);
    }
}
