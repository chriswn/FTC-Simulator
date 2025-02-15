using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnBuildRobot()
    {
        SceneManager.LoadScene("LoadProject");
    }

    public void OnProgramRobot()
    {
        SceneManager.LoadScene("NEW Project");
    }

    public void OnSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
