/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;

    public Transform heartsParent;
    public GameObject heartContainerPrefab;
    public float MaxTotalHealth = 30;
    public bool isBoss;
    float MaxHealth;
    float Health;

    void Start()
    {
        MaxHealth = BattleManager.maxHP[Game.level];
        if(isBoss) MaxHealth = Game.boss.GetComponentInChildren<Boss>().mHP;
        heartContainers = new GameObject[(int)MaxTotalHealth];
        heartFills = new Image[(int)MaxTotalHealth];
        InstantiateHeartContainers();
    }

    void Update()
    {
        Health = Game.HP;
        if(isBoss) Health = Game.boss.GetComponentInChildren<Boss>().HP;
        SetHeartContainers();
        SetFilledHearts();
    }

    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < MaxHealth)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }
    }

    void SetFilledHearts()
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            if (i < Health)
            {
                heartFills[i].fillAmount = 1;
            }
            else
            {
                heartFills[i].fillAmount = 0;
            }
        }

        if (Health % 1 != 0)
        {
            int lastPos = Mathf.FloorToInt(Health);
            heartFills[lastPos].fillAmount = Health % 1;
        }
    }

    void InstantiateHeartContainers()
    {
        for (int i = 0; i < MaxTotalHealth; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent, false);
            heartContainers[i] = temp;
            heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
        }
    }
}
