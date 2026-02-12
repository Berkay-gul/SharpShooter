using Cinemachine;
using UnityEngine.UI;
using UnityEngine;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] int startingHealth =5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weponCamera;
    [SerializeField] GameObject gameOverContainer;
    [SerializeField] Image[] shieldBars;
    int currentHealt ;
    int deathVirtualCameraprioritiy = 20;
    void Awake()
    {
        currentHealt = startingHealth;
        AdjustShields();
    }

    public void TakeDamage(int amaunt)
    {
        currentHealt -= amaunt;
        AdjustShields();

        if (currentHealt <= 0)
        {
            PlayerDie();
        }


    }

    void PlayerDie()
    {
        weponCamera.parent = null;
        deathVirtualCamera.Priority = deathVirtualCameraprioritiy;
        gameOverContainer.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(this.gameObject);
    }

    void AdjustShields()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealt)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
