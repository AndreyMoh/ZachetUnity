using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public List<ItemScript> items = new List<ItemScript>();
    public Transform ItemContent;
    public GameObject InventoryItem;
    public ItemController[] inventoryItems;
    public GameObject inventoryPanel;

    public void Start()
    {
        inventoryPanel.SetActive(false);
    }
    private void Awake()
    {
        Instance = this;
    }
    public void Add(ItemScript item)
    {
        items.Add(item);
    }
    public void Remove(ItemScript item) 
    {
        items.Remove(item);
    }
    public void ListItems()
    {
        foreach (ItemScript item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("Text").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        SetInventoryItems();
    }
    public void SetInventoryItems()
    {
        inventoryItems = ItemContent.GetComponentsInChildren<ItemController>();
        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                ListItems();
            }
            else
            {
                inventoryPanel.SetActive(false);
                ListItems();
                foreach (Transform item in ItemContent)
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}
