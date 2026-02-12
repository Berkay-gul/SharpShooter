using System;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] GameObject deathExplosionVFX;
    [SerializeField] int startingHealth =3;
    int currentHealt ;
    GameManager gameManager;
    void Awake()
    {
        currentHealt = startingHealth;
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

  

    public void TakeDamage(int amaunt)
    {

        currentHealt-=amaunt;
        if (currentHealt <= 0)
        {
            gameManager.AdjustEnemiesLeft(-1);
            SelfDestruct();
        }
            
        
    }

    public void SelfDestruct()
    {
        Instantiate(deathExplosionVFX, transform.position,quaternion.identity);
        Destroy(this.gameObject);
        
    }





}

