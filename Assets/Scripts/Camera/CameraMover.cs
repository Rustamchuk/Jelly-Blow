using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;

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

            yield return null;

            if (transform.position == point.position)
                _moving = false;
        }

        StopMove.Invoke();
    }
}
