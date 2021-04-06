using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOver(GameObject player)
    {
        player.SetActive(false);
        //Show game over panel
    }

    public void StartGame()
    {
        
    }
    
    public void ExitGame()
    {
        
    }

    public void PauseGame()
    {
        
    }
}
