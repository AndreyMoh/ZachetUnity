using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerScript : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerFeatures Stats;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
        Instantiate(Stats.PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
