using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInstantiate : MonoBehaviour
{
    public GameObject Template;
    public int Count;
    private GameObject[] _spownPoints;

    private void Start()
    {
        var SpawnEnemyJob = StartCoroutine(SpawnEnemy());

    }

    private IEnumerator SpawnEnemy()
    {
        _spownPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");

        for (int i = 0; i < Count; i++)
        {
            var spawnPoint = Random.Range(0, _spownPoints.Length);
            GameObject gameObject = Instantiate(Template, _spownPoints[spawnPoint].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
    }
}
