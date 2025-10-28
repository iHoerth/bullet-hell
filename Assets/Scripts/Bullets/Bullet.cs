using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Rigidbody rBody;
    public int bulletSpeed = 50;

    void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.useGravity = false;
        rBody.linearVelocity = transform.forward * bulletSpeed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
