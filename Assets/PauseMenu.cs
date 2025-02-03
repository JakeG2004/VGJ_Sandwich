using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameManager _gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gm = FindFirstObjectByType<GameManager>();
    }

    public void SwitchScene(string sceneName)
    {
        _gm.LoadScene(sceneName);
    }

    public void Quit()
    {
        _gm.QuitGame();
    }

    public void Resume()
    {
        _gm.TogglePause();
    }
}
