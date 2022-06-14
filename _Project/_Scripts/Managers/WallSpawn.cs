using System.Collections;
using System.Collections.Generic;
using nicolaskohler;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private float _startSpawnTime = 1f;
    [SerializeField] private float _nextSpawn = 5f;
    [SerializeField] private float _destroyTime = 5f;

    private const float _LIMIT_MIN_X = -3f;
    private const float _LIMIT_MAX_X = 3f;
    private const float _LIMIT_MIN_Y = 2f;
    private const float _LIMIT_MAX_Y = 7f;


    private void OnEnable()
    {
        CanvasManager.OnStartGame += StartSpawn;
        GameOver.OnGameOver += StopSpawn;
    }
    private void OnDisable()
    {
        CanvasManager.OnStartGame -= StartSpawn;
        GameOver.OnGameOver -= StopSpawn;
    }

    private void StartSpawn()
    {
        InvokeRepeating("Spawn", _startSpawnTime, _nextSpawn);
    }


    void Spawn()
    {
        var spawnPosition = new Vector3(Random.Range(_LIMIT_MIN_X, _LIMIT_MAX_X), Random.Range(_LIMIT_MIN_Y, _LIMIT_MAX_Y), 0);
        var randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        GameObject gm = Instantiate(wall, spawnPosition, randomRotation);
        Destroy(gm, _destroyTime);
    }

    private void StopSpawn()
    {
        CancelInvoke("Spawn");
    }


}
