using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInfo : MonoBehaviour
{
    public static AbilityInfo Instance;
    AbilityScript ability;
    public void Awake()
    {
        Instance = this;
    }
}
