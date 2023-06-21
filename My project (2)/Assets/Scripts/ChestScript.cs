using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    Animator animator;
    bool isOpen = false;
    public GameObject[] stufs;

    public PlayerController playerController;
    public PlayerFeatures Stats;

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Stats = playerController.playerFeatures;
        
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Stats.Keys > 0 && !isOpen)
        {
            //animator.SetLayerWeight(1, 0);
            isOpen = true;
            animator.SetBool("IsOpen", true);
            if (gameObject.tag == "BossChest" && Stats.Keys >= 3)
                Stats.Keys-= 3;
            else
                Stats.Keys--;
            new WaitForSeconds(2);
            StartCoroutine(CreateLoot());
            //CreateLoot();
        }
    }
    IEnumerator Delay(int delay)
    {
        yield return new WaitForSeconds(delay);
    }
    IEnumerator CreateLoot()
    {
        yield return new WaitForSeconds(1);
        if (isOpen)
        {
            if (gameObject.tag == "BossChest")
            {
                int numb = Random.Range(10, 20);
                for (int i = 0; i < numb; i++)
                {
                    int j = Random.Range(0, stufs.Length);
                    GameObject stuf = stufs[j];
                    Vector3 point = (Random.insideUnitSphere * 6) + gameObject.transform.position;
                    point.z = 0;
                    Instantiate(stuf, point, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                }
            }
            else
            {
                int numb = Random.Range(0, 6);
                for (int i = 0; i < numb; i++)
                {
                    int j = Random.Range(0, stufs.Length);
                    GameObject stuf = stufs[j];
                    Vector3 point = (Random.insideUnitSphere * 5) + gameObject.transform.position;
                    point.z = 0;
                    Instantiate(stuf, point, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                }
            }
        }
    }
}
