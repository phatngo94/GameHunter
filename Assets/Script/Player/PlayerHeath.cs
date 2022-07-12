using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] private GameObject btnQuitGame;
    [SerializeField] private GameObject btnNewGame;
    public static float heathPlayer;
    public float totalHeath;
    private void Awake()
    {
        PlayerHeath.heathPlayer = totalHeath;
    }
    private void Update()
    {
        if (PlayerHeath.heathPlayer <=0 )
        {
            transform.parent.gameObject.SetActive(false);
            Time.timeScale = 0f;
            SoundManage.instance.PauseSound();
            btnNewGame.SetActive(true);
            btnQuitGame.SetActive(true);
        }
    }


    

   
}
