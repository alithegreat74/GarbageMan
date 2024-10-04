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
        public int currentCount;
        private int _enemyDeathCounter;

        [Header("Enemies")]
        [SerializeField] private List<EnemySpawn> enemySpawnList=new List<EnemySpawn>();


        [Header("Level Info")]
        [SerializeField] private float xMin;
        [SerializeField] private float xMax;
        [SerializeField] private float zMax;
        [SerializeField] private float zMin;
        [SerializeField] private float enemyY;

        [SerializeField] private GameObject winningUI;

        private List<int> _enemyCounts=new List<int>();
        private int _sumOfRates;

        [SerializeField] private int maxWaveNumber;
        private int _currentWave = 0;

        #endregion

        public delegate void NewWaveGenerated(int waveNumber);
        public event NewWaveGenerated onNewWaveGenerated;

        public delegate void EnemiesUpdated(int enemyNumber);
        public event EnemiesUpdated onEnemiesUpdated;
        private void Start()
        {
            foreach(EnemySpawn enemySpawn in enemySpawnList)
                _enemyCounts.Add(0);
            
            _sumOfRates = 0;

            foreach (EnemySpawn spawn in enemySpawnList)
                _sumOfRates += spawn.spawnRate;

            currentCount = intialSpawnNumber;
            GenerateWave();

        }

        private void GenerateWave()
        {
            _currentWave++;
            if (_currentWave > maxWaveNumber)
            {
                Time.timeScale = 0.0f;
                winningUI.SetActive(true);
            }

            int i = 0;
            foreach(EnemySpawn spawn in enemySpawnList)
            {
                _enemyCounts[i] = spawn.spawnRate * currentCount / _sumOfRates;
                i++;
            }

            onNewWaveGenerated?.Invoke(_currentWave);
            onEnemiesUpdated?.Invoke(currentCount);
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {

            List<int> countsCopy = new List<int>();
            countsCopy.AddRange(_enemyCounts);
            List<EnemySpawn> enemySpawnsCopy = new List<EnemySpawn>();
            enemySpawnsCopy.AddRange(enemySpawnList);
            for(int i=0;i< currentCount;i++)
            {
                int rand = UnityEngine.Random.Range(0, countsCopy.Count);
                Vector3 spawnPosition = SpawnLocation.SpawnPosition(xMax, zMax, xMin, zMin, enemyY);
                GameObject obj = Instantiate(enemySpawnsCopy[rand].prefab, spawnPosition, Quaternion.Euler(82,0,0), null);

                countsCopy[rand]--;
                if (countsCopy[rand] <= 0)
                {
                    enemySpawnsCopy.RemoveAt(rand); 
                    countsCopy.RemoveAt(rand);
                }

                obj.GetComponent<Entity>().onDeath += OnEnemyDeath;
                yield return new WaitForSeconds(spawnRate);
            }
        }

        private void OnEnemyDeath(Entity e)
        {
            _enemyDeathCounter++;
            onEnemiesUpdated?.Invoke(currentCount - _enemyDeathCounter);
            e.onDeath -= OnEnemyDeath;
            if(_enemyDeathCounter>=currentCount)
                StartCoroutine(ReSpawnWave());
            
        }
        private IEnumerator ReSpawnWave()
        {
            yield return new WaitForSeconds(waitTime);
            currentCount += spawnIncrement;
            _enemyDeathCounter= 0;
            GenerateWave();
        }

    }

    [System.Serializable]
    struct EnemySpawn
    {
        public GameObject prefab;
        public int spawnRate;
    }
}
