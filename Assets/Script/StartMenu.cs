using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuUI;

    private void Start()
    {
        // فقط در صحنه‌ی منو بازی رو متوقف کن
        if (SceneManager.GetActiveScene().name == "MainMenugame")
        {
            Time.timeScale = 0f;
            if (startMenuUI != null)
                startMenuUI.SetActive(true);
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // از حالت pause دربیاد
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit(); // برای ساخت نهایی روی سیستم کاربر
    }
}



