using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChanger : MonoBehaviour
{
    [SerializeField] private EnemySet[] _enemySets;
    [SerializeField] private CameraMover _cameraMover;

    private int _currentSet;

    private void Start()
    {
        foreach (var set in _enemySets)
        {
            set.FinishedSet += StartMove;
        }

        _enemySets[_currentSet].StartSet();

        _cameraMover.StopMove += ChangeSet;
    }

    private void ChangeSet()
    {
        _enemySets[_currentSet].StartSet();
    }

    private void StartMove()
    {
        if (_currentSet == _enemySets.Length - 1)
            return;

        _currentSet++;

        StartCoroutine(_cameraMover.Move(_enemySets[_currentSet].CameraPoint));
    }
}
