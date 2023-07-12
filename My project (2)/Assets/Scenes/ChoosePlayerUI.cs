using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePlayerUI : MonoBehaviour
{
    public GameObject player;
    public void choose()
    {
        ChoosingPlayer.Player = player;
        SceneManager.LoadScene("level 1");
    }
}
