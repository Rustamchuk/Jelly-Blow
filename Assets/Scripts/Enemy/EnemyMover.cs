using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private EnemyLife _life;

    private void Update()
    {
        if (_life.Alive)
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(_target.position.x, transform.position.y, _target.position.z), Time.deltaTime * _speed);
    }
}
