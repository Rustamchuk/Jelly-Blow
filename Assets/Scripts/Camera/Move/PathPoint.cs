using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathPoint : MonoBehaviour
{
    [SerializeField] private MovingPoints _pointType;
    [SerializeField] private Transform _lookDirection;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _guidePoint1;
    [SerializeField] private Transform _guidePoint2;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private bool _battlePoint;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private bool _lastPoint;

    private int _deadEnemiesCount = 0;

    public MovingPoints PointType => _pointType;
    public Transform LookDirection => _lookDirection;
    public Transform StartPoint => _startPoint;
    public Transform GuidePoint1 => _guidePoint1;
    public Transform GuidePoint2 => _guidePoint2;
    public Transform EndPoint => _endPoint;
    public bool BattlePoint => _battlePoint;
    public bool LastPoint => _lastPoint;
    public event UnityAction<PathPoint> PlatformCleared;

    private void Awake()
    {
        _deadEnemiesCount = 0;
    }

    private void OnEnable()
    {
        if(_enemies.Length > 0)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Dead += OnDead;
            }
        }
    }

    private void OnDisable()
    {
        if (_enemies.Length > 0)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Dead -= OnDead;
            }
        }
    }

    private void OnDead()
    {
        _deadEnemiesCount++;

        if(_deadEnemiesCount == _enemies.Length)
        {
            PlatformCleared?.Invoke(this);
        }
    }
}

public enum MovingPoints
{
    Jump,
    Walk
}
