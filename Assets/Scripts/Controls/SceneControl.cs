using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static void Push(string scene)
    {
        validateScene(scene);
        Common.scene = scene;
        SceneManager.LoadSceneAsync(scene);

    }
    public async static void Push(string scene, int delay)
    {
        validateScene(scene);
        Common.scene = scene;
        SceneManager.LoadSceneAsync(scene);
        await Task.Delay(delay);

    }
    public static void validateScene(string scene){
        if (string.IsNullOrEmpty(scene))
        {
            throw new System.Exception("Erro ao entrar.");
        }
    }
}