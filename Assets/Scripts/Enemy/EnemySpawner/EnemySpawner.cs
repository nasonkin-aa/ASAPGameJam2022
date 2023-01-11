using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyBread;
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

    private enum _waves
    {
        wave_1, wave_2, wave_3, wave_4, wave_5, wave_6, wave_7
    }
    _waves waves;

    private void FixedUpdate()
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

    private void WaveControl()
    {
        switch (waves)
        {
            case _waves.wave_1:

                break;
            case _waves.wave_2:
                break;
            case _waves.wave_3:
                break;
            case _waves.wave_4:
                break;
            case _waves.wave_5:
                break;
        }
    }
    private void SpawnEnemy()
    {
        
        if (Timer.timerMinut < 1)
        {
            CreateEnemy(_enemyBread);
            CreateEnemy(_enemyBread);
        }
        if (Timer.timerMinut >= 1 && Timer.timerMinut < 2)
        {
            _spawnTimer = 1.5f;
            CreateEnemy(_enemyMonke);
        }
        if (Timer.timerMinut >= 2 && Timer.timerMinut < 3)
        {
            CreateEnemy(_enemyBread);
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
            CreateEnemy(_enemyBread);
            CreateEnemy(_wolfEnemy);
        }
        if (Timer.timerMinut > 5)
        {
            _spawnTimer = 1f;
            CreateEnemy(_enemyBread);
            CreateEnemy(_enemyBread);

            timprc -= Time.deltaTime;
            if (timprc < 0)
            {
                CreateEnemy(_pechka);
                timprc = pec;
            }
        }
        

        void CreateEnemy(GameObject enemy)
        {
            Debug.Log("spawn");
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
