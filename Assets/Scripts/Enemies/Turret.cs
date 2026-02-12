using System.Collections;
using System.Runtime.ExceptionServices;
using StarterAssets;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turret;
    [SerializeField] Transform target;
    [SerializeField] GameObject projectlePrefab;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float FireRate =2f;
    [SerializeField] int damage =2;
    PlayerHealth player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireRoutine());
    }
    void Update()
    {
        turret.LookAt(target);
    }
    IEnumerator FireRoutine()
    {
        while (player)
        {
            yield return new WaitForSeconds(FireRate);
            Projectile newProjectile=  Instantiate(projectlePrefab,projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            newProjectile.transform.LookAt(target);
            newProjectile.Init(damage);
            
        }
    }
}
