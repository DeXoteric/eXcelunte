using UnityEditor;
using UnityEngine;

public class DeletePlayerPrefsScript : EditorWindow
{
    [MenuItem("PlayerPrefs/Delete PlayerPrefs (All)")]
    private static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}