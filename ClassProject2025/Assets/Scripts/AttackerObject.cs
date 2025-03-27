using UnityEngine;

public class AttackerObject : MonoBehaviour
{
    // initialize the game object

    public GameObject prefab;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(prefab, new Vector2(Random.Range(1, 5), Random.Range(1, 5)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
