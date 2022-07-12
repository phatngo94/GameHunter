using UnityEngine;
using UnityEngine.UI;

public class MonsterAlive : MonoBehaviour
{
    [SerializeField] private Text monsterAlive;

    private void Update()
    {
        monsterAlive.text = ":" + (MonsterManage.totalMonster - Health.monsterDeath) + "/" + MonsterManage.totalMonster;
    }
}
