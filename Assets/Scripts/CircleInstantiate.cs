using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemySpawnPoints;
    [SerializeField]private int Count;
    private Transform[] _spownPoints;
    private float _delay = 2f;

    private void Start()
    {
        var SpawnEnemyJob = StartCoroutine(SpawnEnemy());

    }

    private IEnumerator SpawnEnemy()
    {
        _spownPoints = _enemySpawnPoints.GetComponentsInChildren<Transform>();

        for (int i = 0; i < Count; i++)
        {
            var spawnPoint = Random.Range(0, _spownPoints.Length);
            GameObject enemy = Instantiate(_enemy, _spownPoints[spawnPoint].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(_delay);
        }
    }
}
