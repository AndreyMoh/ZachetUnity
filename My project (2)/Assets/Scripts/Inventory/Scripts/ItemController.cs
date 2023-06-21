using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public ItemScript item;

    public PlayerController playerController;
    public PlayerFeatures Stats;

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
    }

    public  void RemoveItem()
    {
        InventoryController.Instance.Remove(item);
        CreateAgent();
        Destroy(gameObject);
    }
    public void AddItem(ItemScript Newitem)
    {
        item = Newitem;
    }
    public void UseItem()
    {
        switch (item.type)
        {
            case ItemScript.ItemType.Potion:
                switch (item.itemName)
                {
                    case "heal":
                        playerController.getHeal(item.value);
                        UsingItem();
                        break;
                    case "MannaPotion":
                        playerController.GetManna(item.value);
                        UsingItem();
                        break;
                    case "jackpot":
                        Stats.BitCoins += item.value;
                        UsingItem();
                        break;
                }
                break;
            case ItemScript.ItemType.Weapon:
                Stats.Damage = item.value;
                UsingItem();
                break;
        }
    }
    public void UsingItem()
    {
        InventoryController.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void CreateAgent()
    {
        Vector3 point = (Random.insideUnitSphere * 7) + PlayerStats.plStats.transform.position;
        point.z = 0;
        Instantiate(item.obj, point, Quaternion.identity);
    }
}
