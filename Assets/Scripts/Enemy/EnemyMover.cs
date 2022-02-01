using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterStateChanger))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private MonsterLife _life;
    [SerializeField] private float _stoppingTime;

    private MonsterStateChanger _monsterStateChanger;
    private float _lastSpeed = 0;
    private bool _wait;

    public event Action Finished;

    private void Awake()
    {
        _monsterStateChanger = GetComponent<MonsterStateChanger>();
        _lastSpeed = _speed;
    }

    private void OnEnable()
    {
        _monsterStateChanger.Stoped += OnStoped;
    }

    private void OnDisable()
    {
        _monsterStateChanger.Stoped -= OnStoped;
    }

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
                    new Vector3(_target.position.x, transform.position.y, _target.position.z), Time.deltaTime * _lastSpeed);

                Vector3 direction = _target.position - transform.position;
                direction.y = 0;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _lastSpeed);
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

    private void OnStoped()
    {
        StartCoroutine(SuspendMoving());
    }

    private IEnumerator SuspendMoving()
    {
        _lastSpeed = 0;

        yield return new WaitForSeconds(_stoppingTime);

        _lastSpeed = _speed;
    }
}
