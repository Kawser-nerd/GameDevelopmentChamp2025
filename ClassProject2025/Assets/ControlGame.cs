using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pauseMenu()
    {
        Time.timeScale = 0.0f;
    }
    public void resumeMenu()
    {
        Time.timeScale = 1.0f;
    }
    public void reloadMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
