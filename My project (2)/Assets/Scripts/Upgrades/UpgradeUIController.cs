using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIController : MonoBehaviour
{
    public UpgradeScript upgrade;
    public GameObject pref;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();

        if (upgrade.isUsed)
            pref.GetComponent<Image>().color = Color.red;
    }

    public void UpgradeUp()
    {
        var type = upgrade.type;

        if (!upgrade.isUsed)
        {
            switch (type)
            {
                case UpgradeScript.UpgradeType.Damage:
                    playerController.DamageUp(upgrade.value);
                    UsedUpgrade();
                    break;
                case UpgradeScript.UpgradeType.Health:
                    playerController.HealthUp(upgrade.value);
                    UsedUpgrade();
                    break;
                case UpgradeScript.UpgradeType.Mana:
                    playerController.ManaFullUp(upgrade.value);
                    UsedUpgrade();
                    break;
                case UpgradeScript.UpgradeType.AttackSpeed:
                    playerController.AttackSpeedUp(upgrade.value);
                    UsedUpgrade();
                    break;
                case UpgradeScript.UpgradeType.MoveSpeed:
                    playerController.MoveSpeedUp(upgrade.value);
                    UsedUpgrade();
                    break; 
                case UpgradeScript.UpgradeType.ManaRegen:
                    playerController.ManaRegenUp(upgrade.value);
                    UsedUpgrade();
                    break;
                case UpgradeScript.UpgradeType.ManaCost:
                    playerController.ManaCostDown(upgrade.value);
                    UsedUpgrade();
                    break;
            }
        }
    }

    public void UsedUpgrade()
    {
        //var alpha = pref.GetComponent<Image>().color.a;
        //alpha = 125;
        upgrade.counter++;
        playerController.RemoveSouls(upgrade.cost);
        if (upgrade.counter == 5)
        {
            pref.GetComponent<Image>().color = Color.red;
            upgrade.isUsed = true;
        }
    }
}
