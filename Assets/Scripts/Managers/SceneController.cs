using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{   
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

        public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
