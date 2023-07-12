using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    void Start()
    {
        Instantiate(ChoosingPlayer.Player, transform.position, Quaternion.identity);
    }
}
