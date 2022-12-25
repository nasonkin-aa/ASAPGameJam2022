using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyMonke;

    [SerializeField]
    private GameObject _wolfEnemy;
    [SerializeField]
    private GameObject _pechka;

    [SerializeField]
    private Vector2 _spawnArea;
    [SerializeField]
    private float _spawnTimer;
    [SerializeField]
    private GameObject _playerPos;
    float timer;
    float pec = 30f;
    float timprc = 30f;
    

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
        
        if (Timer.timerMinut < 1)
        {
            CreateEnemy(_enemy);
        }
        if (Timer.timerMinut >= 1 && Timer.timerMinut < 2)
        {
            _spawnTimer = 1.5f;
            CreateEnemy(_enemyMonke);
        }
        if (Timer.timerMinut >= 2 && Timer.timerMinut < 3)
        {
            CreateEnemy(_enemy);
            CreateEnemy(_enemyMonke);
        }
        if (Timer.timerMinut >= 3 && Timer.timerMinut < 4)
        {
            _spawnTimer = 1.2f;
            CreateEnemy(_enemyMonke);
            CreateEnemy(_wolfEnemy);
        }
        if (Timer.timerMinut >= 4 && Timer.timerMinut < 5)
        {
            _spawnTimer = 1f;
            CreateEnemy(_enemyMonke);
            CreateEnemy(_enemy);
            CreateEnemy(_wolfEnemy);
        }
        if (Timer.timerMinut > 5)
        {
            _spawnTimer = 1f;
            CreateEnemy(_enemy);
            CreateEnemy(_enemy);

            timprc -= Time.deltaTime;
            if (timprc < 0)
            {
                CreateEnemy(_pechka);
                timprc = pec;
            }
        }

        IEnumerator peckra()
        {
            yield return new WaitForSeconds(70f);
            CreateEnemy(_enemy);
        }
        void CreateEnemy(GameObject enemy)
        {
            Vector3 position = GenerateRandomPosition();

            position += _playerPos.transform.position;
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = position;
        }
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
