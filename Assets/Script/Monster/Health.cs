using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float lifeMonster;
    [SerializeField] private AudioClip soundHurt;
    public static int monsterDeath;
    private bool isDamage;
    private bool die;
    


    private void Update()
    {
        LifeMonster();
        MosterDeath();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            SoundManage.instance.PlaySound(soundHurt);
            isDamage = true;
            lifeMonster -= 0.25f;
            if (lifeMonster <= 0)
            {
                die = true;
            }
        }
    }
    private void LifeMonster()
    {
        if (isDamage)
        {
            GetComponent<SpriteRenderer>().color = new Color(1,0,0,lifeMonster);
        }
    }

    private void MosterDeath()
    {
        if (die)
        {
            Destroy(transform.parent.gameObject);
            Health.monsterDeath++;
        }
    }
}
