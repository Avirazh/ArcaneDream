using System.Collections;
using UnityEngine;

namespace AI
{
    public class SpawnManager : MonoBehaviour
    {
        [Header("Enemy Prefab")]
        [SerializeField] private GameObject enemyPref;

        [Header("Wave'll spawn in time between this two numbers")]
        [SerializeField] private int lowCap;
        [SerializeField] private int highCap;

        [Header("Number of enemies in wave")]
        [SerializeField] private int enemyNum;

        [Header("Enemy spawn coordinates mins and max")]
        [SerializeField] private float minSpawnX;
        [SerializeField] private float maxSpawnX;
        [SerializeField] private float minSpawnZ;
        [SerializeField] private float maxSpawnZ;

        private int waveCount;
        void Start()
        {
            StartCoroutine(WaveSpawnerRoutine());
        }

        void Update()
        {

        }
        private void InstantiateEnemy()
        {
            Instantiate(enemyPref, SpawnPositionRandomize(), enemyPref.transform.rotation);
        }
        //randomizes enemy spawn position
        private Vector3 SpawnPositionRandomize()
        {
            return new Vector3(Random.Range(minSpawnX, maxSpawnX), 1, Random.Range(minSpawnZ, maxSpawnZ));
        }
        //method that spawns enemies
        private void SpawnWave()
        {
            for (int i = 0; i < enemyNum; i++)
            {
                InstantiateEnemy();
            }
            waveCount++;
        }
        //countdown between waves
        private IEnumerator WaveSpawnerRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(RandomWaveTime());
                SpawnWave();
            }
        }
        //time between waves of enemies
        private int RandomWaveTime()
        {
            return Random.Range(lowCap, highCap);
        }
    }
}