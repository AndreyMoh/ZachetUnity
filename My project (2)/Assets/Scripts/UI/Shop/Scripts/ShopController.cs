using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public static ShopController instance;
    
    public Transform ShopPanelTransform;
    public GameObject ShopItemPrefab;
    public GameObject ShopPanel;

    public List<ItemScript> items = new List<ItemScript>();
    void Start()
    {
        instance = this;
        Initialize();

        ShopPanel.SetActive(false);
    }
    public void Initialize()
    {
        foreach (var item in items)
        {
            GameObject obj = Instantiate(ShopItemPrefab, ShopPanelTransform);
            obj.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;
            obj.transform.Find("Title").GetComponent<Text>().text = item.name;
            obj.transform.Find("Cost").GetComponent<Text>().text = item.cost.ToString();
            obj.GetComponent<ShopItemScript>().shopItem = item;
        }
    }
    public void ClearShop()
    {
        foreach (Transform item in ShopPanelTransform)
        {
            Destroy(item.gameObject);
        }
    }
}
