using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCleaner : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private float destroyTime;

    private float _timer;
    private void OnEnable()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer+= Time.deltaTime;
        if(_timer>=destroyTime)
            Destroy(gameObject);
    }
}
