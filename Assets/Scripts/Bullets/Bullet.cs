using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Rigidbody rBody;
    public int bulletSpeed = 50;
    public SphereCollider bulletCollider;

    public int damage;


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
            Debug.Log("Daño realizado" + damage);
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
        // reproducir sonido?
        // Debug.Log("Bullet Sound! BAM");
        // instanciar efecto de bala??
        Debug.Log($"Object: {other.name}");
        Debug.Log($"Tag: {other.tag}");
        Debug.Log($"Layer: {LayerMask.LayerToName(other.gameObject.layer)}");
        Debug.Log($"Collider type: {other.GetType()}");
        Debug.Log($"Root object: {other.transform.root.name}");
        // Destroy this gameObject on trigger
        Destroy(gameObject);
    }
}
