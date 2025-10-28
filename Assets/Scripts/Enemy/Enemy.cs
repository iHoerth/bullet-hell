using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float speed = 5f;
    public GameObject player;
    
    void Start()
    {   
        // Since the enemy is a prefab, the player has to be searched in runtime as follows
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        // caminar hacia el jugador
        gameObject.transform.LookAt(player.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;        
    }
}
