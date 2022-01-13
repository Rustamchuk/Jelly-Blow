using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySet : MonoBehaviour
{
    [SerializeField] private EnemyLife[] _enemiesLife;
    [SerializeField] private EnemyMover[] _enemiesMover;
    [SerializeField] private CameraPointSpeeder[] _cameraPoint;

    public event Action FinishedSet;
    public event Action FailSet;
    public event UnityAction<Transform> NextTargetChoosed;
    public CameraPointSpeeder[] CameraPoint => _cameraPoint;

    public Transform NearestEnemy { get; private set; }

    private int _currentEnemyCount;

    private void Start()
    {
        if (_enemiesLife[0] == null)
            return;

        NearestEnemy = _enemiesLife[0].LookPoint.transform;

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
        if (_enemiesLife[0] == null)
        {
            FinishedSet.Invoke();
            return;
        }

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
        else
            SetNextTargetEnemy(_enemiesLife[_currentEnemyCount].LookPoint);
    }

    private void SetNextTargetEnemy(Transform target)
    {
        NextTargetChoosed?.Invoke(target);
    }

    private void Lose() { FailSet.Invoke(); }
}
