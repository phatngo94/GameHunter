using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpeed : MonoBehaviour
{
    public float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float coolSpeed;
    private float timer;

    private void Update()
    {
        Speed();
    }
    private void Speed()
    {
        timer += Time.deltaTime * coolSpeed;
        if (timer >= 1)
        {
            speed += 0.5f;
            timer = 0;
        }
        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
