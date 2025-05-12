using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int killTarget = 4;
    public float timeLimit = 60f;

    public DialogWindow dialogWindow;

    private int currentKills = 0;
    private float timer;
    private bool gameEnded = false;

    private void Start()
    {
        timer = timeLimit;
        Time.timeScale = 1f;

        if (dialogWindow != null)
            dialogWindow.SetVisible(false);
    }

    private void Update()
    {
        if (gameEnded) return;

        timer -= Time.deltaTime;

        if (timer <= 0 && currentKills < killTarget)
        {
            ShowLoseDialog();
        }
    }

    public void RegisterKill()
    {
        if (gameEnded) return;

        currentKills++;

        if (currentKills >= killTarget)
        {
            ShowWinDialog();
        }
    }

    private void ShowWinDialog()
    {
        gameEnded = true;
        Time.timeScale = 0f;

        dialogWindow.Init(
            "YOU WIN",
            "QUIT",
            "RESTART",
            QuitGame,
            RestartScene
        );

        dialogWindow.SetVisible(true);
    }

    private void ShowLoseDialog()
    {
        gameEnded = true;
        Time.timeScale = 0f;

        dialogWindow.Init(
            "YOU LOSE",
            "QUIT",
            "RESTART",
            QuitGame,
            RestartScene
        );

        dialogWindow.SetVisible(true);
    }

    private void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
