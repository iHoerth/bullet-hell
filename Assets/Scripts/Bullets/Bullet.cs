using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Rigidbody rBody;
    public int bulletSpeed = 50;
    public SphereCollider collider;

    public int damage;


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
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Debug.Log("Daño realizado" + damage);
            enemy.TakeDamage(damage);
        }

        BulletImpact();
    }

    void OnBecameInvisible()
    {
        // destroy bullets as soon as they leave the camera vision for eficiency
        Destroy(gameObject);
    }

    void BulletImpact()
    {
        // reproducir sonido?
        // Debug.Log("Bullet Sound! BAM");
        // instanciar efecto de bala??
        Debug.Log("Bullet Effect");
        // Destroy this gameObject on trigger
        Destroy(gameObject);
    }
}
