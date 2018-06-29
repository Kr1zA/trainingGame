using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static bool _gameIsPaused;
    private static bool _inGameMenu;
    public GameObject PauseMenuUI;
    public GameObject GameMenuUI;

    private void Start()
    {
        _gameIsPaused = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GM.Instance.CanPause)
        {
            if (_gameIsPaused)
            {
                if (_inGameMenu)
                {
                    Back();
                }
                else
                {
                    Resume();
                }
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        //Debug.Log("quit game");
    }

    public void ChangeGame()
    {
        _inGameMenu = true;
        PauseMenuUI.SetActive(false);
        GameMenuUI.SetActive(true);
    }

    public void Back()
    {
        _inGameMenu = false;
        GameMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void NinjaKeyboard()
    {
        Back();
        Resume();
        GM.Instance.BeginNinjaKeyboard();
    }

    public void TrainingGame()
    {
        Back();
        Resume();
        GM.Instance.BeginTrainingGame();
    }

    public void Calibrate()
    {
        GM.Instance.BeginBinding();
        Resume();
    }
}