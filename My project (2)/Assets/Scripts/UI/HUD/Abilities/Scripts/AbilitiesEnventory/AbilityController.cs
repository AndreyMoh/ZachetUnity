using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AbilityController : MonoBehaviour
{
    public AbilityScript ability;
    void Start()
    {
        
    }
    public void AddNewAbility(AbilityScript NewAbility)
    {
        ability = NewAbility;
    }
    public void AddToPanel()
    {
        AbilitiesPanelController.Instance.Add(ability);        
    }     
    public void DeleteFromPanel()
    {
        AbilitiesPanelController.Instance.Remove(ability);
    }
}
