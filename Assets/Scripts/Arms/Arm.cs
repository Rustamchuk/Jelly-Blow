using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private GameObject _armObject;
    [SerializeField] private Animator _animator;

    private Vector3 _startSize;
    private bool _attacking = false;

    public Vector3 StartSize => _startSize;
    public Transform StartPos => _startPos;
    public bool Attacking => _attacking;
    public GameObject ArmObject => _armObject;
    public event Action Touched;

    private void Start()
    {
        _startSize = _armObject.transform.localScale;
    }

    public void RewriteAttacking(bool state)
    {
        _attacking = state;

        if (_attacking)
            _animator.SetTrigger("Hit");
    }

    public void TouchedTrigger()
    {
        Touched.Invoke();
        _animator.SetTrigger("Break");
    }
}
