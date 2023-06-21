using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UpgradesPanelController : MonoBehaviour
{

    public Transform UpgradesPanel;
    public GameObject UpgradeUIPref;
    public GameObject UpgradesPanelPrefab;

    private PlayerController PlayerController;
    private PlayerFeatures PlayerStats;

    void Start()
    {
        UpgradesPanelPrefab.SetActive(false);

        PlayerController = FindAnyObjectByType<PlayerController>();
        PlayerStats = PlayerController.playerFeatures;

        foreach (var upgrade in PlayerController.Upgrades)
        {
            GameObject obj = Instantiate(UpgradeUIPref, UpgradesPanel);
            obj.GetComponent<UpgradeUIController>().upgrade = upgrade;

            var Title = obj.transform.Find("Title").GetComponent<Text>();
            var CostText = obj.transform.Find("CostText").GetComponent<Text>();
            var TitleName = obj.transform.Find("NameTitle").GetComponent<Text>();
            var Icon = obj.GetComponent<Image>();

            Title.text = upgrade.value.ToString();
            TitleName.text = upgrade.name;
            CostText.text += upgrade.cost.ToString();
            Icon.sprite = upgrade.icon;
        }
    }

    private void Update()
    {
        var SoulsText = UpgradesPanelPrefab.transform.Find("SoulsText").GetComponent<Text>();
        SoulsText.text = "";
        SoulsText.text = "Souls: " + PlayerStats.Souls.ToString();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!UpgradesPanelPrefab.activeSelf)
            {
                UpgradesPanelPrefab.SetActive(true);
            }
            else
            {
                UpgradesPanelPrefab.SetActive(false);
            }
        }
    }
}
