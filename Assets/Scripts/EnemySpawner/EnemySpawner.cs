using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private Vector2 _spawnArea;
    [SerializeField]
    private float _spawnTimer;
    [SerializeField]
    private GameObject _playerPos;
    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = _spawnTimer;
            
        }
    }
    private void Start()
    {
        timer = _spawnTimer;
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += _playerPos.transform.position;
        GameObject newEnemy = Instantiate(_enemy);
        newEnemy.transform.position = position;
    }
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-_spawnArea.x, _spawnArea.x);
            position.y = _spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-_spawnArea.y, _spawnArea.y);
            position.x = _spawnArea.x * f;

        }
        position.z = 0;
        return position;
    }
}
