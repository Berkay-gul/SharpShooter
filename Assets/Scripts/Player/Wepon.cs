using Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;

    CinemachineImpulseSource impulseSource;


    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }


    public void Shoot(WeponSO weponSO)
    {

        muzzleFlash.Play();
        impulseSource.GenerateImpulse();

        RaycastHit hit;
        // bir raycast gonderip eger ifade null degilse mantiga devam ediyor.
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers , QueryTriggerInteraction.Ignore))
        {

            // carpismanin gerceklestigi noktada hit vsf i olusturuyor.
            Instantiate(weponSO.HitVfxPrefab,hit.point,quaternion.identity);
            
            //carptigi elemanin enemyhealt scriptini alip degiskene veriyor , eger yoksa devam ediyor "?" ile olup olmadigi kontrol ediliyor.
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            enemyHealth?.TakeDamage(weponSO.Damage);

        }

    
    }
}

  


// silah atest ettigi kisiyi kontrool edip eger bu dusmansa o dusmanin scriptine veri gondersin dusmanin scriptinde ise bu  veri belirlenen sayiya kadar arttilip belirlenen sayidaysa yok edilsin .
