using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgPlayer;
    private Animator animPlayer;
    private Vector3 target;
    [SerializeField] private float speed;

    private void Awake()
    {
        rgPlayer = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();

    }
    private void Update()
    {
        RotateFollowMouse();
        PlayerMoving();
    }
    private void RotateFollowMouse()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = transform.position - target;
        dir.Normalize();

        float angle = Mathf.Atan2(dir.y,dir.x)* Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle-90);
       
    }

    private void PlayerMoving()
    {
        float posx = Input.GetAxis("Horizontal") * speed;
        float posy = Input.GetAxis("Vertical")* speed ;
        rgPlayer.velocity = new Vector2(posx,posy);

        if(posx!=0 || posy != 0)
        {
            animPlayer.SetBool("walk",true);
        }
        else
        {
            animPlayer.SetBool("walk", false);
        }
    }

   
}
