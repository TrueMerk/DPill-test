using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private Player _player;
    public GameObject pauseMenuUI;
    
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        _player.Death += GameOver;
    }
    
    private void GameOver()
    {
        pauseMenuUI.SetActive(true);
        _button.gameObject.SetActive(true);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}