using UnityEngine;

public class WeponPickup : Pickup
{
    [SerializeField] WeponSO weponSO;

   
   

    protected override void OnPickup(ActiveWepon activeWepon)
    {
        activeWepon.SwitchWepon(weponSO);
    }
}
