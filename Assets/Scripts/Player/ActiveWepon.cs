using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;
using Cinemachine;
using TMPro;


public class ActiveWepon : MonoBehaviour
{
    [SerializeField] WeponSO startingWepon;
    [SerializeField] CinemachineVirtualCamera playerFallowCamera;
    [SerializeField] Camera weponCamera;
    [SerializeField] GameObject zoomVignatte;
    [SerializeField] TMP_Text ammoText;
    WeponSO currentWeponSO;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Wepon currentWepon;
    float timeSinceLastShot =0f;
    float defaultFow;
    float defaultRotationSpeed;
    int currentAmmo;
    const string SHOOT_STRING = "Shoot";
    

    void Awake() 
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFow= playerFallowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }
    void Start()
    {
        SwitchWepon(startingWepon);
        AdjustAmmo(currentWeponSO.MagazinSize);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }
    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;
        if(currentAmmo > currentWeponSO.MagazinSize)
        {
            currentAmmo= currentWeponSO.MagazinSize;
        }

        ammoText.text = currentAmmo.ToString("D2");

    }
    public void SwitchWepon(WeponSO weponSO)
    {
        if (currentWepon)
        {
            Destroy(currentWepon.gameObject);
        }

        Wepon  newWepon = Instantiate(weponSO.WeponPrefab,transform).GetComponent<Wepon>();
        currentWepon = newWepon;
        this.currentWeponSO = weponSO;
        AdjustAmmo(currentWeponSO.MagazinSize);
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;
        if (!starterAssetsInputs.shoot) return;

        if(timeSinceLastShot >= currentWeponSO.FireRate && currentAmmo > 0 )
        {
            currentWepon.Shoot(currentWeponSO);
            animator.Play(SHOOT_STRING ,0,0f);
            timeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        if (!currentWeponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
            
        }
    }

    void HandleZoom()
    {
        if(!currentWeponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            playerFallowCamera.m_Lens.FieldOfView = currentWeponSO.ZoomAmaunt;
            weponCamera.fieldOfView = currentWeponSO.ZoomAmaunt;
            zoomVignatte.SetActive(true);
            firstPersonController.ChangeRotationSpeed(currentWeponSO.ZoomRotation);
        }
        else
        {
            playerFallowCamera.m_Lens.FieldOfView = defaultFow;
            weponCamera.fieldOfView = defaultFow;
            zoomVignatte.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
            
        }
    }
}
