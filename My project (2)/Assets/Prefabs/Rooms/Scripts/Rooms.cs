//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public static Rooms Instance;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public GameObject bossPrefab;

    public GameObject[] Enemies;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Invoke("SpawnBoss", 3);
    }

    public void SpawnBoss() 
    {
        rooms[Random.Range(4, rooms.Count)].GetComponent<Room>().SpawnBoss();
    }
}
