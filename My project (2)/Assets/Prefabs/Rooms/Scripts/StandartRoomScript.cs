using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartRoomScript : MonoBehaviour
{
    public GameObject PlayerPrefab;

    private void Awake()
    {
        GameObject player = Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
