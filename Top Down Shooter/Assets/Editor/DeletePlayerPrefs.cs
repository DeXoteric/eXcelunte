using UnityEditor;
using UnityEngine;

public class DeletePlayerPrefsScript : EditorWindow
{
    [MenuItem("PlayerPrefs/Delete PlayerPrefs (All)")]
    private static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("PlayerPrefs/Reset Free Coins and Timer")]
    private static void ResetFreeCoinsAndTimer()
    {
        PlayerPrefs.DeleteKey("freeCoins");
        PlayerPrefs.DeleteKey("freeCoinsTimer");
    }
}