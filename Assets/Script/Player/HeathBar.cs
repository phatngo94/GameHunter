using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private PlayerHeath playerHeath;
    [SerializeField] private Image totalHeathBar;
    [SerializeField] private Image currentHeathBar;
   
    private void Start()
    {
        
        totalHeathBar.fillAmount = playerHeath.GetComponent<PlayerHeath>().totalHeath/10;
    }

    private void Update()
    {
        currentHeathBar.fillAmount = PlayerHeath.heathPlayer / 10;
    }

}
