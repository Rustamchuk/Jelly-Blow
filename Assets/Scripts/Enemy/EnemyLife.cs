using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _holeGap;
    [SerializeField] private GameObject _hall;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _fatherObj;

    private float _hitDuration = 0.7f;
    private bool _alive = false;
    private const string _walk = "Walk";
    private const string _hit = "Hit";
    private const string _end = "End";

    public bool Alive => _alive;
    public event Action Dead;


    public void StartLife()
    {
        _alive = true;

        if (_animator != null)
            _animator.SetTrigger(_walk);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_alive)
        {
            _health--;

            if (other.gameObject.TryGetComponent(out Arm arm))
            {
                if (!arm.Attacking)
                    return;

                arm.TouchedTrigger();

                if (_health % _holeGap == 0 && _health != 0)
                    MakeHall(arm);

                if (_health == 0)
                {
                    MakeHall(arm);

                    _alive = false;
                    _animator.SetTrigger(_end);
                    Dead.Invoke();
                }
            }

            if (_health > 0 && _health % _holeGap != 0)
            {
                _animator.SetTrigger(_hit);
                StartCoroutine(WaitHitAnim());
            }
        }
    }

    private void MakeHall(Arm arm)
    {
        var hall = Instantiate(_hall);
        hall.transform.position = arm.transform.position;
        hall.transform.parent = _fatherObj.transform;
    }

    private IEnumerator WaitHitAnim()
    {
        _alive = false;

        yield return new WaitForSeconds(_hitDuration);

        _alive = true;
    }
}
