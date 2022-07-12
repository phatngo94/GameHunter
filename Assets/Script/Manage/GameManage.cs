using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManage : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private HolderBullet holderEnemy;

    [Header("BTN Game")]
    [SerializeField] private GameObject btnPlayGame;
    [SerializeField] private GameObject btnQuitGame;
    [SerializeField] private GameObject btnNewGame;
    [Header("BTN Icon Game")]
    [SerializeField] private GameObject btnPauseGame;
    [SerializeField] private GameObject btnResumeGame;
    

    private void Awake()
    {
        Time.timeScale = 0f;
        
        player.transform.parent.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }

    public void playGame()
    {
        Time.timeScale = 1f;
        player.transform.parent.gameObject.SetActive(true);
        btnPlayGame.SetActive(false);
        btnPauseGame.SetActive(true);
        btnResumeGame.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        btnPauseGame.SetActive(false);
        btnResumeGame.SetActive(true);
        btnNewGame.SetActive(true);
        btnQuitGame.SetActive(true);

        player.GetComponent<PlayerMovement>().enabled = false;
        holderEnemy.GetComponent<HolderBullet>().enabled = false;

    }
     public void ResumeGame()
    {
        Time.timeScale = 1f;
        btnPauseGame.SetActive(true);
        btnResumeGame.SetActive(false);
        btnNewGame.SetActive(false);
        btnQuitGame.SetActive(false);

        player.GetComponent<PlayerMovement>().enabled = true;
        holderEnemy.GetComponent<HolderBullet>().enabled = true;

    }

    public void QuitGame()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.LoadLevel(0);
    }
   
}

