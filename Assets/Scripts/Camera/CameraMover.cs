using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ArmStretcher _arms;

    private bool _moving = false;

    public bool Moving => _moving;
    public event Action StopMove;

    public IEnumerator Move(Transform point)
    {
        _moving = true;
        while (_moving)
        {
            transform.LookAt(point);
            transform.position = Vector3.MoveTowards(transform.position, point.position, Time.deltaTime * _speed);

            _arms.ReturnPos(_arms.ArmL);
            _arms.ReturnPos(_arms.ArmR);

            yield return null;

            if (transform.position == point.position)
                _moving = false;
        }

        StopMove.Invoke();
    }

    public void RewriteMoving(bool state) { _moving = state; }
}
