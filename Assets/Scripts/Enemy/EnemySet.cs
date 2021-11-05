using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySet : MonoBehaviour
{
    [SerializeField] private EnemyLife[] _enemiesLife;
    [SerializeField] private EnemyMover[] _enemiesMover;
    [SerializeField] private Transform _cameraPoint;

    public event Action FinishedSet;
    public event Action FailSet;
    public Transform CameraPoint => _cameraPoint;

    private int _currentEnemyCount;

    private void Start()
    {
        foreach (var enemy in _enemiesLife)
        {
            enemy.Dead += RemoveEnemy;
        }

        foreach (var enemy in _enemiesMover)
        {
            enemy.Finished += Lose;
        }
    }

    public void StartSet()
    {
        foreach (var enemy in _enemiesLife)
        {
            enemy.StartLife();
        }
    }

    private void RemoveEnemy()
    {
        _currentEnemyCount++;

        if (_currentEnemyCount == _enemiesLife.Length)
            FinishedSet.Invoke();
    }

    private void Lose() { FailSet.Invoke(); }
}
