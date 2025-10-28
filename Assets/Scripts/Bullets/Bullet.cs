using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Rigidbody rBody;
    public int bulletSpeed = 50;
    public SphereCollider collider;

    void Awake()
    {
        collider = GetComponent<SphereCollider>();
        rBody = GetComponent<Rigidbody>();

        rBody.useGravity = false;
        rBody.linearVelocity = transform.forward * bulletSpeed;
    }

    // This is called on collision (IsTrigger == true) 
    void OnTriggerEnter(Collider other)
    {
        // reproducir sonido?
        Debug.Log("Bullet Sound! BAM");
        // instanciar efecto de bala??
        Debug.Log("Bullet Effect");
        // Destroy this gameObject on trigger
        Destroy(gameObject);
    }
}
