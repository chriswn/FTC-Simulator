using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Onplay()
    {
        SceneManager.LoadScene("MainMenu");
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
