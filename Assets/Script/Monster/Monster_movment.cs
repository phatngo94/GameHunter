using UnityEngine;
using Pathfinding;

public class Monster_movment : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private MonsterSpeed monsterSpeed;
    private float currentSpeed;
    private Attack monsterAttack;

    public AIPath aIPath;

    private void Awake()
    {
        monsterAttack = GetComponent<Attack>();
    }

    private void Update()
    {
        currentSpeed = monsterSpeed.GetComponent<MonsterSpeed>().speed;
        Moving();
        RotateFollowPlayer();
    }

    private void Moving()
    {
        if (monsterAttack.canAttack)
        {
            aIPath.maxSpeed = 0;
            
        }
        else
        {
            aIPath.maxSpeed = currentSpeed;
            
        }
    }

    private void RotateFollowPlayer()
    {
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

  
}
