using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject _infoMenu, _mainMenu, _loadingScreen;
    public Slider _slider;
    public Text _progressText;

    public void LoadGame()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        _loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            _slider.value = progress;
            _progressText.text = progress * 100f + "%";

            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToInfoMenu()
    {
        _infoMenu.SetActive(true);
        _mainMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GoToMainMenu()
    {
        _infoMenu.SetActive(false);
        _mainMenu.SetActive(true);
        Time.timeScale = 1f;
    }
}
