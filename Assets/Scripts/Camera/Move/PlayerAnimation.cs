using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMover _cubeMover;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _cubeMover.Jumped += OnJumped;
        _cubeMover.Landed += OnLanded;
    }

    private void OnDisable()
    {
        _cubeMover.Jumped -= OnJumped;
        _cubeMover.Landed -= OnLanded;
    }

    private void OnJumped()
    {
        _animator.SetTrigger(AnimatorPlayerController.Actions.Jump);
    }

    private void OnLanded()
    {
        _animator.SetTrigger(AnimatorPlayerController.Actions.Jump);
    }
}
