using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text startText;
    public Text gameOverText;
    public GameObject tryAgainButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.M)) {
            startText.gameObject.SetActive(false);
        }
    }
}
