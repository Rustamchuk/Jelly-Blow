using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterLife : MonoBehaviour
{
    [SerializeField] private MonsterStateChanger _monsterState;
    [SerializeField] private Transform _lookPoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _boomEffect;

    public Transform LookPoint => _lookPoint;
    public event Action Dead;
    public event Action Finished;
    public event UnityAction<float> Wait;
    public bool Alive => _alive;

    private bool _alive = false;

    private void Start()
    {
        _monsterState.Dead += Die;
        _monsterState.WaitToGo += StopGo;

        foreach (var part in _monsterState.ReturnParts())
        {
            part.Touched += ActivateParticle;
            part.Finished += FinishAttack;
        }
    }

    private void ActivateParticle(Vector3 position)
    {
        _boomEffect.transform.position = new Vector3(position.x, position.y, _boomEffect.transform.position.z);
        _boomEffect.Play();
    }

    private void FinishAttack() 
    { 
        Finished.Invoke();
        _alive = false;
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

    private void StopGo(float time) { Wait.Invoke(time); }
}
