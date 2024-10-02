using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace Level
{
    public class WaveGenerator : MonoBehaviour
    {
        #region Singleton
        public static WaveGenerator instance;
        private void Awake()
        {
            if(instance!=null)
                Destroy(instance.gameObject);
            else
                instance = this;
        }
        #endregion
        #region Varaiables

        [Header("Spawn values")]
        [SerializeField] private int intialSpawnNumber;
        [SerializeField] private int spawnIncrement;
        [SerializeField] private float waitTime;
        [SerializeField] private float spawnRate;
        private int _currentCount;
        private int _enemyDeathCounter;

        [Header("Enemies")]
        [SerializeField] private List<EnemySpawn> enemySpawnList=new List<EnemySpawn>();
        private List<int> _enemyCounts=new List<int>();

        #endregion

        private void OnEnemyDeath()
        {
            _enemyDeathCounter++;
            if(_enemyDeathCounter>=_currentCount)
            {
                Debug.Log("Wave Finished");
            }
        }

    }

    [System.Serializable]
    struct EnemySpawn
    {
        public GameObject prefab;
        public int spawnRate;
    }
}
