using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnBuildRobot()
    {
        SceneManager.LoadScene("RobotCustomization");
    }

    public void OnProgramRobot()
    {
        SceneManager.LoadScene("Programming");
    }

    public void OnTestRobot()
    {
        SceneManager.LoadScene("TestingField");
    }

    public void OnSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
