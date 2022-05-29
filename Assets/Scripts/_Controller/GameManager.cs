
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource coinFX;
    public Animator playerAnimator;
    public GameObject particlePrefab;
    [HideInInspector] public bool gameHasEnded = false;
    [HideInInspector] public bool gameStarted = false;

    public GameObject completeDemoUI;

    public float restartDelay = 2f;

    private void Awake()
    {
        gameStarted = false;
        gameHasEnded = false;
        instance = this;
        Invoke("StartGame", 1f);
    }
    public void StartGame()
    {
        gameStarted = true;
        playerAnimator.SetBool("Started", true);
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
           Invoke("Restart",restartDelay);
        }
    }
    void Restart()
    {
        CollectableControl.coinCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CompleteDemo(){
        completeDemoUI.SetActive(true);
    }
}
