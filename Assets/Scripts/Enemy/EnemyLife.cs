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

    private float _hitDuration = 0.7f;
    private bool _alive = false;
    private bool _coolDown = false;
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

    public void CollisionEnter(Collider other, GameObject father, Transform holePoint = null)
    {
        if (!_coolDown && _alive && other.gameObject.TryGetComponent(out Arm arm))
        {
            StartCoroutine(WaitCoolDown());

            if (!arm.Attacking)
                return;

            _health--;

            arm.TouchedTrigger();

            if (_health % _holeGap == 0 && _health != 0)
                MakeHall(arm, father, holePoint);

            if (_health == 0)
            {
                MakeHall(arm, father, holePoint);

                _alive = false;
                _animator.SetTrigger(_end);
                Dead.Invoke();
            }

            if (_health > 0 && _health % _holeGap != 0)
            {
                _animator.SetTrigger(_hit);
                //StartCoroutine(WaitHitAnim());
            }

            WaitCoolDown();
        }
    }

    private void MakeHall(Arm arm, GameObject father, Transform hallPoint = null)
    {
        var hall = Instantiate(_hall);
        //hall.transform.eulerAngles = new Vector3(90, 0, 0);
        hall.transform.position = arm.transform.position;
        hall.transform.parent = father.transform;

        if (hallPoint != null)
            hall.transform.position = new Vector3(hall.transform.position.x, hall.transform.position.y, hallPoint.position.z);
    }

    private IEnumerator WaitHitAnim()
    {
        _alive = false;

        yield return null;

        _alive = true;
    }

    private IEnumerator WaitCoolDown()
    {
        _coolDown = true;
        yield return null;
        _coolDown = false;
    }
}
