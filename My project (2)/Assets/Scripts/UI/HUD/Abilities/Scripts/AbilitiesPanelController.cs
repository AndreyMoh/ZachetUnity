using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class AbilitiesPanelController : MonoBehaviour
{
    public static AbilitiesPanelController Instance;

    public List<AbilityScript> Abilities = new List<AbilityScript>(5);
    public Dictionary<AbilityScript, GameObject> prefabs = new Dictionary<AbilityScript, GameObject>(5);
    public Transform PanelTransform;
    public GameObject AbilityItem;

    private Camera cam;

    private PlayerController playerController;

    public void Start()
    {
        Instance = this;

        cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();

        playerController = FindAnyObjectByType<PlayerController>();
    }
    public void Initialize()
    {
        prefabs.Clear();
        foreach (Transform item in PanelTransform)
        {
            Destroy(item.gameObject);
        }
        foreach (var ability in Abilities)
        {
            GameObject obj = Instantiate(AbilityItem, PanelTransform);
            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
            itemIcon.sprite = ability.icon;
            prefabs.Add(ability, obj);

            //info.Add(ability, obj);
            //obj.GetComponent<AbilityInfo>().Insta;
        }
    }
    public void Add(AbilityScript ability)
    {
        if (!Abilities.Contains(ability))
        {
            Abilities.Add(ability);
            Initialize();
        }
        else return;
    }
    public void Remove(AbilityScript ability)
    {
        Abilities.Remove(ability);
        Initialize();

    }
    private void Update()
    {

        IsCooldown();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseAbility(0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseAbility(1);
        }
        
    }
    public void UseAbility(int number)
    {
        Abilities[number].isCooldown = false;
        prefabs[Abilities[number]].transform.Find("Image").GetComponent<Image>().fillAmount = 0;

        GameObject spell = Instantiate(Abilities[number].pref, playerController.transform.position, Quaternion.identity);
        Vector2 mPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPosition = playerController.transform.position;
        Vector2 direction = mPosition - myPosition;
        spell.GetComponent<Rigidbody2D>().velocity = direction * Abilities[number].attackSpeed;

        Destroy(spell, 5);
    }
    public void IsCooldown()
    {
        foreach (var ability in Abilities)
        {
            if (prefabs[ability].transform.Find("Image").GetComponent<Image>().fillAmount == 1) 
            {
                ability.isCooldown = true;
            }
            if (!ability.isCooldown)
            {
                prefabs[ability].transform.Find("Image").GetComponent<Image>().fillAmount += 1 / ability.cooldown * Time.deltaTime;
            }
        }
    }
}
