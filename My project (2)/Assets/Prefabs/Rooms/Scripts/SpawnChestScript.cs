using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChestScript : MonoBehaviour
{
    private GameObject ChestPoints;

    public GameObject ChestPref;

    private void Start()
    {
        ChestPoints = gameObject.transform.Find("ChestPoints").gameObject;
        int rand = Random.Range(0, ChestPoints.transform.childCount);
        for (int i = 0; i <= rand; i++)
        {
            Instantiate(ChestPref, ChestPoints.transform.GetChild(i).position, Quaternion.identity);
        }
    }
}
