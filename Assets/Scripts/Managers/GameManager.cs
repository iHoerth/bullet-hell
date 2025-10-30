using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{   
    public float globalTimer = 5f;
    public PlayerController player;

    public TMP_Text timerText;

    void Update()
    {
        if (timerText != null)
            timerText.text = Mathf.CeilToInt(globalTimer).ToString();

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