using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyCode _menu = KeyCode.Escape;

    private GameObject _pauseMenu = null;
    private bool _isPaused = false;

    void Start()
    {
        _pauseMenu = GameObject.FindWithTag("PauseMenu");
        _pauseMenu.SetActive(false);  // Make sure the pause menu is hidden at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_menu))
        {
            TogglePause();
        }        
    }

    public void TogglePause()
    {
        // Toggle the pause state
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0.0f;  // Stop time when paused
            _pauseMenu.SetActive(true);  // Show the pause menu
        }
        else
        {
            Time.timeScale = 1.0f;  // Resume time when unpaused
            _pauseMenu.SetActive(false);  // Hide the pause menu
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
