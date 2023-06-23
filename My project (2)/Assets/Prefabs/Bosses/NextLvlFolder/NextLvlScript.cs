using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvlScript : MonoBehaviour
{
    public bool IsEnabled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsEnabled)
        {
            SceneManager.LoadScene("level 2");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsEnabled = true;
    }
}
