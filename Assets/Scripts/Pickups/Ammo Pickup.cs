using UnityEngine;

public class AmmoPickup : Pickup
{

    [SerializeField] int addAmmo = 100;
    protected override void OnPickup(ActiveWepon activeWepon)
    {
        activeWepon.AdjustAmmo(addAmmo);
    }


}
