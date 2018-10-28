using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SplashScreen : MonoBehaviour {

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI progressText;

    private void Start()
    {
        StartCoroutine(LoadAynchronously());
    }

    IEnumerator LoadAynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main Menu");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
