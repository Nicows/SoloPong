using System.Collections;
using System.Collections.Generic;
using NicolasKohler.Utilities;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _upWall;
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _rightWall;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private float _startSpawnTime = 1f;
    [SerializeField] private float _nextSpawn = 5f;
    [SerializeField] private float _destroyTime = 5f;
    [SerializeField] private RectTransform[] _limitPoints = new RectTransform[2];

    private float _LIMIT_MIN_X = -3f;
    private float _LIMIT_MAX_X = 3f;
    private float _LIMIT_MIN_Y = 2f;
    private float _LIMIT_MAX_Y = 7f;


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
    private void Start()
    {
        SetUpWalls();
        SetUpLimitsOfSpawnWall();
    }

    private void StartSpawn()
    {
        InvokeRepeating("Spawn", _startSpawnTime, _nextSpawn);
    }

    private void SetUpWalls()
    {
        var widthOfScreen = Helpers.Camera.orthographicSize * 2.0f * Screen.width / Screen.height;
        var topPoint = Helpers.Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _upWall.transform.localScale = new Vector3(widthOfScreen, _upWall.transform.localScale.y, _upWall.transform.localScale.z);
        _upWall.transform.position = new Vector3(_upWall.transform.position.x, topPoint.y, _upWall.transform.position.z);

        var midPoint = Helpers.Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0));
        _leftWall.transform.position = new Vector3(-midPoint.x, midPoint.y, 0);
        _rightWall.transform.position = new Vector3(midPoint.x, midPoint.y, 0);
    }

    private void SetUpLimitsOfSpawnWall()
    {
        var pointLimit1 = _limitPoints[0].transform.position;
        var point2Limit2 = _limitPoints[1].transform.position;
        _LIMIT_MAX_X = pointLimit1.x;
        _LIMIT_MAX_Y = pointLimit1.y;
        _LIMIT_MIN_X = point2Limit2.x;
        _LIMIT_MIN_Y = point2Limit2.y;
    }

    void Spawn()
    {
        var randomX = Random.Range(_LIMIT_MIN_X, _LIMIT_MAX_X);
        var randomY = Random.Range(_LIMIT_MIN_Y, _LIMIT_MAX_Y);
        var spawnPosition = new Vector3(randomX, randomY, 0);
        var randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        GameObject go = Instantiate(_wallPrefab, spawnPosition, randomRotation);
        var wallTouch = go.GetComponentInChildren<WallTouch>();
        StartCoroutine(wallTouch.WaitBeforeDestroy(_destroyTime));
    }

    private void StopSpawn()
    {
        CancelInvoke("Spawn");
    }


}
