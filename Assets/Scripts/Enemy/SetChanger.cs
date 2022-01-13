using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChanger : MonoBehaviour
{
    [SerializeField] private EnemySet[] _enemySets;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private SmoothCameraRotate _cameraRotate;

    private int _currentSet;

    public event Action FailLevel;
    public event Action WinLevel;

    private void OnEnable()
    {
        foreach (var enemy in _enemySets)
        {
            enemy.NextTargetChoosed += OnNextTargetChoosed;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemySets)
        {
            enemy.NextTargetChoosed -= OnNextTargetChoosed;
        }
    }

    private void Start()
    {
        foreach (var set in _enemySets)
        {
            set.FinishedSet += StartMove;
            set.FailSet += LoseLevel;
        }

        //_cameraMover.StopMove += ChangeSet;
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

        if (_cameraRotate.RotateCoroutineIsActive == true)
            _cameraRotate.StopRotate();
        
        _cameraRotate.StartRotate(_enemySets[_currentSet].NearestEnemy);
    }

    private void OnNextTargetChoosed(Transform target)
    {
        if (_cameraRotate.RotateCoroutineIsActive == true)
            _cameraRotate.StopRotate();

        _cameraRotate.StartRotate(target);
    }

    private void LoseLevel() { FailLevel.Invoke(); _cameraMover.RewriteMoving(true); }
}
