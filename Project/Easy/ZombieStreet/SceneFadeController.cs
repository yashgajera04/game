using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFdaeController : MonoBehaviour
{
    [SerializeField]
    private float fadeDuration;

    private SceneFade sceneFade;
    private void Awake()
    {
        sceneFade = GetComponentInChildren<SceneFade>();
    }
    private IEnumerator Start()
    {
        yield return sceneFade.FadInCoroutine(fadeDuration);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return sceneFade.FadOutCoroutine(fadeDuration);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
