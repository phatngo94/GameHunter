using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class HolderBullet : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private float totalBullet;
    [SerializeField] private float timeLoadBullet; 
    
    [Header("Bulle Text")]
    [SerializeField] private Text textBullet;

    [Header("Sound")]
    [SerializeField] private AudioClip soundShoot;
    [SerializeField] private AudioClip soundLoadBullet;

    private float currentBullet;

    private void Start()
    {
        currentBullet = totalBullet;
        
    }

    private void Update()
    {
        if (currentBullet <= 0)
        {
            StartCoroutine(LoadBullet());
        }
        else
        {
            StopAllCoroutines();
        }
        Shooting();
        textBullet.text = ": " + currentBullet;
        
    }
    private void Shooting()
    {
        if (currentBullet > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!bullet[FindBullet()].activeInHierarchy)
                {
                    bullet[FindBullet()].transform.position = pointShoot.position;
                    bullet[FindBullet()].SetActive(true);
                    SoundManage.instance.PlaySound(soundShoot);
                }
                currentBullet--;
            }
        }
         
        
    }
    private int FindBullet()
    {
        for(int i = 0; i < bullet.Length; i++)
        {
            if (!bullet[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private IEnumerator LoadBullet()
    {
        
        yield return new WaitForSeconds(timeLoadBullet);
        SoundManage.instance.PlaySound(soundLoadBullet);
        currentBullet = totalBullet;

    }
  
}
