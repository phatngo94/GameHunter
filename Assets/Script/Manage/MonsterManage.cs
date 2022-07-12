using System.Collections;
using UnityEngine;

public class MonsterManage : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private Transform[] cave;
    [SerializeField] private float spawnCoolDown;
    public static int totalMonster;
    private float CoolDownTimer = Mathf.Infinity;


    private void Start()
    {
        for (int i = 0; i < cave.Length; i++)
        {
            GameObject cloneMonster = Instantiate(monster, cave[i].position,Quaternion.identity);
            totalMonster++;
            cloneMonster.SetActive(true);
            StartCoroutine(Invunerability());
        }
        CoolDownTimer = 0;
    }

    private void Update()
    {
        if (CoolDownTimer >= spawnCoolDown)
        {
            CreateMonster();
            CoolDownTimer = 0;
            Debug.Log(totalMonster);
        }
        CoolDownTimer += Time.deltaTime;
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(6,7,false);
    }

    private void CreateMonster()
    {
        int randomCave = Random.Range(0,4);
        GameObject cloneMonster = Instantiate(monster, cave[randomCave].position, Quaternion.identity);
        totalMonster++;
        cloneMonster.SetActive(true);
        StartCoroutine(Invunerability());
    }
}
