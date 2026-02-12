using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] GameObject projectileHitVFX;
    int damage;
    Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    void Update()
    {
        rb.linearVelocity = transform.forward*speed;
    }
    public void Init(int damage)
    {
        this.damage=damage;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);
        Instantiate(projectileHitVFX,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }

}

