using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagemnet
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Scene Object", menuName = "Scene Object")]
    public class SceneObject : ScriptableObject
    {
        public string SceneName;
        public List<string> children = new List<string>();
    }

}