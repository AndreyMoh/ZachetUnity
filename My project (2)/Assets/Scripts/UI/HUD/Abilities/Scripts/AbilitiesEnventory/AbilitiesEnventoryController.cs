using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class AbilitiesEnventoryController : MonoBehaviour
{
    public static AbilitiesEnventoryController Instance;

    public List<AbilityScript> Abilities = new List<AbilityScript>();
    public GameObject AbilityItem;
    public Transform AbilitiesTransform;
    public Transform AbilitiesPanelTransform;
    public AbilityController[] abilityControllers;

    public GameObject Inventory;
    void Start()
    {
        Inventory.SetActive(false);
    }
    private void Awake()
    {
        Instance = this;
    }
    public void Add(AbilityScript ability)
    {
        foreach (var obj in Abilities)
        {
            if (obj == ability) return;
        }
        Abilities.Add(ability);
    }
    public void Remove(AbilityScript ability)
    {
        Abilities.Remove(ability);
    }
    public void Initialize()
    {
        foreach (var ability in Abilities)
        {
            GameObject obj = Instantiate(AbilityItem, AbilitiesTransform);
            obj.GetComponent<Image>().sprite = ability.icon;
        }
        SetAbilities();
    }

    public void SetAbilities()
    {
        abilityControllers = AbilitiesTransform.GetComponentsInChildren<AbilityController>();
        for (int i = 0; i < Abilities.Count; i++)
        {
            abilityControllers[i].AddNewAbility(Abilities[i]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!Inventory.activeSelf)
            {
                Inventory.SetActive(true);
                Initialize();
            }
            else
            {
                Inventory.SetActive(false);
                Initialize();
                foreach (Transform ability in AbilitiesTransform)
                {
                    Destroy(ability.gameObject);
                }
            }
        }
    }
}
