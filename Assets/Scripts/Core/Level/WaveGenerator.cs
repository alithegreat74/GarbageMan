using System.Collections;
using System.Collections.Generic;
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


        [Header("Level Info")]
        [SerializeField] private float xMin;
        [SerializeField] private float xMax;
        [SerializeField] private float zMax;
        [SerializeField] private float zMin;
        [SerializeField] private float enemyY;

        private List<int> _enemyCounts=new List<int>();
        private int _sumOfRates;


        #endregion

        private void Start()
        {
            foreach(EnemySpawn enemySpawn in enemySpawnList)
            {
                _enemyCounts.Add(0);
            }
            _sumOfRates = 0;
            foreach (EnemySpawn spawn in enemySpawnList)
            {
                _sumOfRates += spawn.spawnRate;
            }

            _currentCount = intialSpawnNumber;
            GenerateWave();

        }

        private void GenerateWave()
        {
            int i = 0;
            foreach(EnemySpawn spawn in enemySpawnList)
            {
                _enemyCounts[i] = spawn.spawnRate * _currentCount / _sumOfRates;
                i++;
            }

            StartCoroutine(SpawnEnemies(_enemyCounts));
        }

        private IEnumerator SpawnEnemies(List<int> _counts)
        {
            for(int i=0;i< _currentCount;i++)
            {
                int rand = UnityEngine.Random.Range(0, _counts.Count);
                Vector3 spawnPosition = SpawnLocation.SpawnPosition(xMax, zMax, xMin, zMin, enemyY);
                Instantiate(enemySpawnList[rand].prefab, spawnPosition, Quaternion.identity, null);
                yield return new WaitForSeconds(spawnRate);
            }
        }

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
