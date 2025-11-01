using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Rigidbody rBody;
    public float bulletSpeed = 50f;
    public SphereCollider bulletCollider;

    public float damage;


    void Awake()
    {
        bulletCollider = GetComponent<SphereCollider>();
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
            enemy.TakeDamage(damage);
        }

        BulletImpact(other);
    }

    void OnBecameInvisible()
    {
        // destroy bullets as soon as they leave the camera vision for eficiency
        Destroy(gameObject);
    }

    void BulletImpact(Collider other)
    {
        Destroy(gameObject);
    }
}
