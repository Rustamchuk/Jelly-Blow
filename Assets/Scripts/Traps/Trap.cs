using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public bool Attacking { get; private set; } = false;
    
    private enum TrapType { Knife, Bomb}


    public void ActivateAttack()
    {
        _animator.SetTrigger("Attack");
        Attacking = true;
        StartCoroutine(WaitAttacking());
    }

    private IEnumerator WaitAttacking()
    {
        yield return new WaitForSeconds(3f);
        Attacking = false;
    }
}
