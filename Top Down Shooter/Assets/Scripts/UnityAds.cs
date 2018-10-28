using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            //Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
            sceneLoader.LoadGame(); //TODO remove for final build
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                sceneLoader.LoadGame();
                Debug.Log("Ad finished!");
                break;

            case ShowResult.Skipped:
                //TODO add something for Skipped Ad
                Debug.Log("Ad skipped!");
                break;

            case ShowResult.Failed:
                //TODO add something for Failed Ad
                Debug.Log("Ad failed!");
                break;
        }
    }
}