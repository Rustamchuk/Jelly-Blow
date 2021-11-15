using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _destroy;
    [SerializeField] private BoomMaker _boomBody;

    //[SerializeField] private GameObject _hall;
    //[SerializeField] private int _holeGap;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Arm arm))
        {
            arm.TouchedTrigger();
            //StartCoroutine(WaitCoolDown());

            if (_alive)
            {

                if (!arm.Attacking)
                    return;

                _health--;

                //if (_health % _holeGap == 0 && _health != 0)
                //MakeHall(arm, father);

                if (_health == 0)
                {
                    //MakeHall(arm, father);

                    _destroy.transform.position = new Vector3(transform.position.x, _destroy.transform.position.y, transform.position.z);
                    _destroy.Play();

                    _alive = false;
                    _animator.SetTrigger(_end);
                    Dead.Invoke();

                    StartCoroutine(WaitDestroy());
                }

                if (_health > 0)
                {
                    _animator.SetTrigger(_hit);
                    StartCoroutine(WaitHitAnim());
                }
            }
        }
    }

    /*private void MakeHall(Arm arm, GameObject father)
    {
        var hall = Instantiate(_hall);
        hall.transform.position = arm.transform.position;
        hall.transform.parent = father.transform;
        hall.transform.eulerAngles = new Vector3(90, 0, 0);
    }*/

    private IEnumerator WaitHitAnim()
    {
        _alive = false;

        yield return new WaitForSeconds(_hitDuration);

        _alive = true;
    }

    private IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(0);

        var boom = Instantiate(_boomBody);
        boom.Boom(transform.position);
        Destroy(gameObject);
    }
}
