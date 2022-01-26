using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLife : MonoBehaviour
{
    [SerializeField] private MonsterStateChanger _monsterState;
    [SerializeField] private Transform _lookPoint;
    [SerializeField] private Animator _animator;

    public Transform LookPoint => _lookPoint;
    public event Action Dead;
    public bool Alive => _alive;

    private bool _alive = false;

    private void Start()
    {
        _monsterState.Dead += Die;
    }

    private void Die()
    {
        _alive = false;
        Dead.Invoke();
    }

    public void StartLife()
    {
        _alive = true;
        _animator.SetTrigger("Walk");
    }
}
