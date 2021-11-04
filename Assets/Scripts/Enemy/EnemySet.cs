using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySet : MonoBehaviour
{
    [SerializeField] private EnemyLife[] _enemies;
    [SerializeField] private Transform _cameraPoint;

    public event Action FinishedSet;
    public Transform CameraPoint => _cameraPoint;

    private int _currentEnemyCount;

    private void Start()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Dead += RemoveEnemy;
        }
    }

    public void StartSet()
    {
        foreach (var enemy in _enemies)
        {
            enemy.StartLife();
        }
    }

    private void RemoveEnemy()
    {
        _currentEnemyCount++;

        if (_currentEnemyCount == _enemies.Length)
            FinishedSet.Invoke();
    }
}
