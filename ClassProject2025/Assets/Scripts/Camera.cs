using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // catch the main character or the target character of the game
    private GameObject mainBall;
    void Start()
    {
        mainBall = GameObject.Find("Ball");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainBall.transform);
    }
}
