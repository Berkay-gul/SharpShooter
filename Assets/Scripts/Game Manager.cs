using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLefText;
    [SerializeField] private GameObject youWinText;
    
    int enemiesLeft ;
    const string ENEMIES_LEFT_STRING = "Enemies Left: ";

    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLefText.text = ENEMIES_LEFT_STRING+enemiesLeft.ToString();
        if (enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
        }
    }


    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
