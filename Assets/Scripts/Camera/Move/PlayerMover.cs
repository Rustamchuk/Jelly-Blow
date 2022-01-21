using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerRotate _playerRotate;
    [SerializeField] private PathPoint[] _pathPoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _decelerationJumpSpeed;
    [SerializeField] private float _delayBeforeMovement;

    private int _index = 0;
    private bool _canMove = false;
    private bool _coroutineIsActive = false;
    private IEnumerator _coroutine;

    public bool CanMove => _canMove;
    public event UnityAction Jumped;
    public event UnityAction Landed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _canMove = true;

        if (_canMove == true)
            MoveToPoint();
    }

    private void MoveToPoint()
    {
        if(_pathPoints[_index].PointType == MovingPoints.Walk)
            ActivateMovementCoroutine(Move(_pathPoints[_index]));
        else if(_pathPoints[_index].PointType == MovingPoints.Jump)
            ActivateMovementCoroutine(Jump(_pathPoints[_index]));
    }

    private void ActivateMovementCoroutine(IEnumerator coroutine)
    {
        _playerRotate.StartRotate(_pathPoints[_index].LookDirection);

        if (_coroutineIsActive == true)
            StopCoroutine(_coroutine);

        _coroutine = coroutine;
        StartCoroutine(_coroutine);
    }

    private IEnumerator Move(PathPoint point)
    {
        _canMove = false;
        _index++;
        yield return new WaitForSeconds(_delayBeforeMovement);

        while (transform.position != point.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.transform.position, Time.deltaTime * _moveSpeed);

            yield return null;
        }

        if (point.LastPoint == false)
            _canMove = true;
    }

    private IEnumerator Jump(PathPoint point)
    {
        _canMove = false;
        _index++;
        Jumped?.Invoke();
        yield return new WaitForSeconds(_delayBeforeMovement);
        float delta = 0;

        while (delta < 1)
        {
            delta += Time.deltaTime / _decelerationJumpSpeed;
            transform.position = GetPoint(point, delta);

            yield return null;
        }

        Landed?.Invoke();

        if(point.BattlePoint == true)
        {
            _canMove = false;
            point.PlatformCleared += OnPlatformCleared;
        }
        else if (point.LastPoint == false)
        {
            _canMove = true;
        }
    }

    private Vector3 GetPoint(PathPoint point, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * oneMinusT * point.StartPoint.position + 3f * oneMinusT * oneMinusT * t * point.GuidePoint1.position + 3f * oneMinusT * t * t * point.GuidePoint2.position + t * t * t * point.EndPoint.position;
    }

    private void OnPlatformCleared(PathPoint pathPoint)
    {
        pathPoint.PlatformCleared -= OnPlatformCleared;
        _canMove = true;
    }

    public void ChangeMovingState(bool state)
    {
        //_moving = state;
    }
}
