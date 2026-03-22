using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startText;
    public GameObject gameOverText;
    public GameObject tryAgainButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameOverText != null) {
            gameOverText.gameObject.SetActive(false);
        }
        if (tryAgainButton != null) {
            tryAgainButton.gameObject.SetActive(false);
        }

        if (startText != null) {
            startText.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.M)) {
            startText.gameObject.SetActive(false);
        }
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        tryAgainButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TryAgain() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
