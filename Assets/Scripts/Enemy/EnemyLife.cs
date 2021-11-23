using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int _health;
    //[SerializeField] private int _holeGap;
    [SerializeField] private List<int> _hitAnswer;
    [SerializeField] private GameObject _hall;
    [SerializeField] private Animator _animator;

    private int _curIndex;
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

    public void CollisionEnter(Collider other, GameObject father, Transform holePoint, bool xChange, bool yChange)
    {
        if (!_coolDown && _alive && other.gameObject.TryGetComponent(out Arm arm))
        {
            StartCoroutine(WaitCoolDown());

            if (!arm.Attacking)
                return;

            _health--;

            arm.TouchedTrigger();

            if (_health != 0 && _curIndex < _hitAnswer.Count)
            {
                if (_curIndex % 2 == 0)
                {
                    _animator.SetTrigger(_hit);
                }
                else
                {
                    MakeHall(arm, father, holePoint, xChange, yChange);
                }

                _hitAnswer[_curIndex] -= 1;

                if (_hitAnswer[_curIndex] == 0)
                    _curIndex++;
            }

            //if (_health % _holeGap == 0 && _health != 0)
                //MakeHall(arm, father, holePoint, xChange, yChange);

            if (_health == 0)
            {
                MakeHall(arm, father, holePoint, xChange, yChange);

                _alive = false;
                _animator.SetTrigger(_end);
                Dead.Invoke();
            }

            //if (_health > 0 && _health % _holeGap != 0)
            //{
            //    _animator.SetTrigger(_hit);
                //StartCoroutine(WaitHitAnim());
            //}

            WaitCoolDown();
        }
    }

    private void MakeHall(Arm arm, GameObject father, Transform hallPoint, bool xChange, bool yChange)
    {
        var hall = Instantiate(_hall);
        //hall.transform.LookAt(Vector3.up * 100);
        hall.transform.position = arm.transform.position;
        hall.transform.parent = father.transform;

        if (hallPoint != null)
        {
            hall.transform.position = new Vector3(hall.transform.position.x, hall.transform.position.y, hallPoint.position.z);

            if (xChange)
                hall.transform.position = new Vector3(hallPoint.position.x, hall.transform.position.y, hall.transform.position.z);

            if (yChange)
                hall.transform.position = new Vector3(hall.transform.position.x, hallPoint.position.y, hall.transform.position.z);
        }
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
