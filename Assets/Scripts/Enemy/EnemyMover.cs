using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private EnemyLife _life;

    public event Action Finished;

    private void Update()
    {
        if (_life.Alive)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(_target.position.x, transform.position.y, _target.position.z), Time.deltaTime * _speed);
        }

        if (new Vector3(_target.position.x, transform.position.y, _target.position.z) == transform.position)
            Finished.Invoke();
    }
}
