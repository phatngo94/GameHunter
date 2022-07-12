using UnityEngine;
using UnityEngine.UI;

public class PlayerKill : MonoBehaviour
{
    [SerializeField] private Text kill;


    private void Update()
    {
        kill.text = "KILL : " + Health.monsterDeath;
    }
   
}
