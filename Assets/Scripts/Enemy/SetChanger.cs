using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChanger : MonoBehaviour
{
    [SerializeField] private EnemySet[] _enemySets;
    [SerializeField] private CameraMover _cameraMover;

    private int _currentSet;

    public event Action FailLevel;
    public event Action WinLevel;

    private void Start()
    {
        foreach (var set in _enemySets)
        {
            set.FinishedSet += StartMove;
            set.FailSet += LoseLevel;
        }

        _cameraMover.StopMove += ChangeSet;
    }

    public void ChangeSet()
    {
        _enemySets[_currentSet].StartSet();
    }

    private void StartMove()
    {
        if (_currentSet == _enemySets.Length - 1)
        {
            WinLevel.Invoke();
            _cameraMover.RewriteMoving(true);
            return;
        }

        _currentSet++;

        StartCoroutine(_cameraMover.Move(_enemySets[_currentSet].CameraPoint));
    }

    private void LoseLevel() { FailLevel.Invoke(); _cameraMover.RewriteMoving(true); }
}
