using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform pointShoot;
    private Rigidbody2D rgBullet;
    [SerializeField] private Transform pointDirection;
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    private Vector3 dir;

    private void Awake()
    {
        rgBullet = GetComponent<Rigidbody2D>();
        
    }

    private void OnEnable()
    {
        dir = pointDirection.position - pointShoot.position;
    }
   
    private void Update()
    {
        Bulletmoving();
    }
    private void Bulletmoving()
    {
        rgBullet.velocity = dir*speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
  
    }
}
