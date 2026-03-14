using UnityEngine;

public class StartGame : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    void Start()
    {
        _sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        _sceneLoader.SceneLoading("MenuStartScene");

    }

}
