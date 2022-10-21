using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    
    private float _waitSeconds = 2;

    private void Awake()
    {
        if (_spawnPoints == null)
            Debug.LogError($"{gameObject.name} No spawn points!");
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var waitSeconds = new WaitForSeconds(_waitSeconds);
        
        while (true)
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
            SpawnEnemyIn(_spawnPoints[spawnPointIndex]);
            yield return waitSeconds;
        }
    }

    private void SpawnEnemyIn(Transform spawnPoint)
    {
        Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
