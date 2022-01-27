using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private GameObject _armObject;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _boxGlove;

    private Vector3 _startSize;
    private bool _attacking = false;

    public GameObject BoxGlove => _boxGlove;
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
        {
            _animator.SetTrigger("Hit");
            StartCoroutine(ResetTrigger("Hit"));
        }
    }

    public void TouchedTrigger()
    {
        Touched.Invoke();
        _animator.SetTrigger("Break");

        StartCoroutine(ResetTrigger("Break"));
    }

    private IEnumerator ResetTrigger(string trigger)
    {
        yield return new WaitForSeconds(0.1f);
        _animator.ResetTrigger(trigger);
    }
}
