using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private TrapType _trapType;
    [SerializeField] private Animator _animator;

    public bool Attacking { get; private set; } = false;

    private enum TrapType { Knife, Bomb, BaloonBox}

    private Rigidbody _rig;

    private void Start()
    {
        if (_trapType == TrapType.BaloonBox)
        {
            _rig = transform.GetComponent<Rigidbody>();
        }
    }

    public void ActivateAttack()
    {
        if (_trapType == 0)
            _animator.SetTrigger("Attack");
        else if (_trapType == TrapType.BaloonBox)
            BaloonBox();

        Attacking = true;
        StartCoroutine(WaitAttacking());
    }

    private void BaloonBox()
    {
        _rig.useGravity = true;
    }

    private IEnumerator WaitAttacking()
    {
        yield return new WaitForSeconds(0.8f);
        Attacking = false;
    }
}
