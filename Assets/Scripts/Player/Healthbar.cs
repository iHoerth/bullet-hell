using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText;
    public PlayerController player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBarSlider.maxValue = player.maxHealth;
        healthBarSlider.value = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        healthBarValueText.text = player.health.ToString() + "/" + player.maxHealth.ToString();
        healthBarSlider.value = player.health;
        healthBarSlider.maxValue = player.maxHealth;
    }
}
