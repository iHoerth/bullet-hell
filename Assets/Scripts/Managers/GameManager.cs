using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   
    public float globalTimer = 5f;
    public PlayerController player;


    void Update()
    {
        if(globalTimer > 0)
            globalTimer -= Time.deltaTime;
        else
            Victory();

        if(player.health <= 0)
        {
            Defeat();
        }
        
    }

    public void Victory()
    {
        SceneManager.LoadScene("WinScene");
    }
    
    public void Defeat()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
