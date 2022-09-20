using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
