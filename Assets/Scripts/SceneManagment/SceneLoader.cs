using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagemnet
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneObject _startObject;
        private static SceneObject _startScene;


        private void Start()
        {
            _startScene = _startObject;
            UnloadScenes();
            LoadScene(_startScene);
        }

        private static void LoadScene(SceneObject scene)
        {
            SceneManager.LoadScene(scene.SceneName,LoadSceneMode.Additive);
            foreach(string child in scene.children)
            {
                SceneManager.LoadScene(child,LoadSceneMode.Additive);
            }

        }

        private static void UnloadScenes()
        {
            for(int i=1;i<SceneManager.sceneCount;i++)
            {
                SceneManager.UnloadScene(i);
            }
        }

        public static void ChangeScene(SceneObject scene)
        {
            UnloadScenes();
            LoadScene(scene);
        }

    }
}
