using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnNewProject()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnLoadProject()
    {
        SceneManager.LoadScene("LoadProject");
    }

    public void OnSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
