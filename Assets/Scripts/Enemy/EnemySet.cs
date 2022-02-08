using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySet : MonoBehaviour
{
    [SerializeField] private MonsterLife[] _enemiesLife;
    [SerializeField] private EnemyMover[] _enemiesMover;
    [SerializeField] private CameraPointSpeeder[] _cameraPoint;

    public event Action FinishedSet;
    public event Action FailSet;
    public event UnityAction<Transform> NextTargetChoosed;
    public CameraPointSpeeder[] CameraPoint => _cameraPoint;

    public Transform NearestEnemy { get; private set; }
    public bool Empty { get; private set; } = false;

    private int _currentEnemyCount;

    private void Start()
    {
        if (_enemiesLife[0] == null)
        {
            Empty = true;
            return;
        }

        NearestEnemy = _enemiesLife[0].LookPoint.transform;

        foreach (var enemy in _enemiesLife)
        {
            enemy.Dead += RemoveEnemy;
            enemy.Finished += Lose;
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
        bool continuing = true;
        _currentEnemyCount++;

        if (_currentEnemyCount != _enemiesLife.Length)
        {
            if (_enemiesLife[_currentEnemyCount - 1].Alive == true)
            {
                _currentEnemyCount--;
            }
            else if (_enemiesLife[_currentEnemyCount].Alive == false)
            {
                RemoveEnemy();
                continuing = false;
            }
        }

        if (continuing)
        {
            if (_currentEnemyCount == _enemiesLife.Length)
            {
                float wait = 0;
                foreach (var enemy in _enemiesLife)
                {
                    if (enemy.Exploded)
                        wait = 0.5f;

                }

                StartCoroutine(WaitToMove(wait));
            }
            else
            {
                SetNextTargetEnemy(_enemiesLife[_currentEnemyCount].LookPoint);
            }
        }
    }
    
    private IEnumerator WaitToMove(float wait)
    {
        yield return new WaitForSeconds(wait);
        FinishedSet.Invoke();
    }

    private void SetNextTargetEnemy(Transform target)
    {
        NextTargetChoosed?.Invoke(target);
    }

    private void Lose() { FailSet.Invoke(); }
}
