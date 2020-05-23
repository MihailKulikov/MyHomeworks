using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Represents manager for end of the game menu. Provides methods to quit the game and restart the game.
/// </summary>
public class EndOfGameMenuManager : MonoBehaviour
{
    /// <summary>
    /// Name of scene with which the game begins.
    /// </summary>
    public string MainSceneName;
    
    /// <summary>
    /// Quit the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Restart the game.
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainSceneName);
    }
}
