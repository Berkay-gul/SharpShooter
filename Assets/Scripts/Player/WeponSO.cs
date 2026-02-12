using UnityEngine;

[CreateAssetMenu(fileName = "WeponSO", menuName = "Scriptable Objects/WeponSO")]
public class WeponSO : ScriptableObject
{
    public int MagazinSize = 12 ;
    public GameObject WeponPrefab;
    public GameObject HitVfxPrefab;
    public bool CanZoom = false;
    public bool IsAutomatic = false;
    public int Damage = 1;
    public float FireRate = 0.5f;
    public float ZoomAmaunt=10.0f;
    public float ZoomRotation= .3f;
    
}
