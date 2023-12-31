using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadMainMenu () {
        StartCoroutine(WaitAndLoad("MainMenu", sceneLoadDelay));
    }

    public void LoadGame() {
        scoreKeeper.ResetScore();
        StartCoroutine(WaitAndLoad("Game", sceneLoadDelay));
    }

    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame() {
        Debug.Log("Exit!");
        Application.Quit();
    }

    public IEnumerator WaitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
