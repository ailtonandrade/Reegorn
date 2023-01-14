using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static void Push(string scene)
    {
        if (!string.IsNullOrEmpty(scene))
        {
            Common.scene = scene;
            SceneManager.LoadSceneAsync(scene);
        }

        else
        {
            throw new System.Exception("Scene Manager could not find scene named " + scene);
        }
    }
}