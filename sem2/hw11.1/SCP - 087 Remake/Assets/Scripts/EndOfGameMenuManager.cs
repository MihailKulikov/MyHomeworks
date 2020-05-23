using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameMenuManager : MonoBehaviour
{
    public string MainSceneName;
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainSceneName);
    }
}
