using System.Collections;
using UnityEngine;

public class DelayedGameStart : MonoBehaviour
{
    [SerializeField] private GameObject countdownPrefab;
    [SerializeField] private AnimationClip countdownAnimation;

    private float animationLength;

    private void Start()
    {
        StartCoroutine(DelayGameStart());
    }

    private IEnumerator DelayGameStart()
    {
        Time.timeScale = 0;

        animationLength = countdownAnimation.length;

        yield return new WaitForSecondsRealtime(animationLength);

        countdownPrefab.SetActive(false);

        Time.timeScale = 1;

        GameManager.instance.GameStarted = true;
    }
}