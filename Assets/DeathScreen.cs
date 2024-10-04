using SceneManagemnet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneLoader.Die();
    }
}
