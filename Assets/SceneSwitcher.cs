using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoScene2()
    {
        SceneManager.LoadScene("AR2");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("menu");
    }
}