using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{   
    public float globalTimer = 180f;
    public float difficultyChange = 90f;

    public PlayerController player;
    public EnemySpawner spawner;
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
        
        if(globalTimer <= difficultyChange)
        {
            spawner.difficulty = 2;
            spawner.spawnTime = 1f;
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

    public void RaiseDifficulty()
    {

    }
}