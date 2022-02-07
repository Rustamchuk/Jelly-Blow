using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Button : MonoBehaviour
{
    [SerializeField] private Trap _trap;
    [SerializeField] private Animator _animator;

    private BoxCollider _collider;
    private bool _clicked = false;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BoxArm arm) && !_clicked)
        {
            if (arm.CanBrokeBodyPart)
            {
                _trap.ActivateAttack();
                _collider.enabled = false;
                _clicked = true;
                _animator.SetTrigger("Click");
                arm.ReturnStartPosition();
            }
        }
    }
}
