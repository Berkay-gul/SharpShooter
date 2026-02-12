using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    const string PLAYER_STRING = "Player";
    void Update()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWepon activeWepon = other.GetComponentInChildren<ActiveWepon>();
            OnPickup(activeWepon);
            Destroy(this.gameObject);
        }
        
    }
    protected abstract void OnPickup(ActiveWepon activeWepon);
    

}
