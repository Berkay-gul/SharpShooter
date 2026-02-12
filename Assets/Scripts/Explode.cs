using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] float radius =1.5f;
    [SerializeField] int damageAmount = 3;

    void Start()
    {
        Destruct();
    }

    void OnDrawGizmos()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Destruct()
    {
        Collider[] hitColiders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hitCollider in hitColiders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();
            if(!playerHealth) continue;

            playerHealth.TakeDamage(damageAmount);

            break;
        }

    }

}
