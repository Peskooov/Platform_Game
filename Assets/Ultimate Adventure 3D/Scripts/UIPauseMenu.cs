using UnityEngine.SceneManagement;
using UnityEngine;

public class UIPauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        GameIsPaused = false;
    }
    public void LoadMainMenu(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        GameIsPaused = true;
    }
}
