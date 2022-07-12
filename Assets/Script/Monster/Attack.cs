using System.Collections;
using UnityEngine;


public class Attack : MonoBehaviour
{
    private Animator anim;
    public bool canAttack;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip soundMonsterAttack;

    private void Awake()
    {
        anim = GetComponent<Animator>();  
        
    }

    private void Update()
    {
     
       MonsterAttack();
       
    }

    private void MonsterAttack()
    {
        if (canAttack)
        {
            anim.SetBool("attack", true);
            
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            canAttack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            canAttack = false;
        }
    }

    private void damage()
    {
        StartCoroutine(Blood());
        PlayerHeath.heathPlayer -=1.0f;
        SoundManage.instance.PlaySound(soundMonsterAttack);
    }
    private IEnumerator Blood()
    {
        player.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
