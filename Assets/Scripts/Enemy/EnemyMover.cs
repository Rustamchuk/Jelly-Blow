using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private MonsterLife _life;

    public event Action Finished;

    private bool _wait;

    private void Start()
    {
        _life.Wait += Wait;
    }

    private void Update()
    {
        if (!_wait)
        {
            if (_life.Alive)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(_target.position.x, transform.position.y, _target.position.z), Time.deltaTime * _speed);

                Vector3 direction = _target.position - transform.position;
                direction.y = 0;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _speed);
            }

            if (new Vector3(_target.position.x, transform.position.y, _target.position.z) == transform.position)
                Finished.Invoke();
        }
    }

    private void Wait(float time) 
    {
        _wait = true;
        StartCoroutine(WaitToGo(time));
    }

    private IEnumerator WaitToGo(float time)
    {
        yield return new WaitForSeconds(time);
        _wait = false;
    }
}
