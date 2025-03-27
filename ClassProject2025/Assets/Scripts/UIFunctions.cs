using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIFunctions : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private TextMeshProUGUI playerName;
    [SerializeField]
    private TMP_InputField inputField;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getPlayerName()
    {
        string name = inputField.text;
        playerName.text = name; // this will help us to view the name on the playername text
    }

    public void newGame()
    {
        SceneManager.LoadScene("FirstScene");
    }

}
