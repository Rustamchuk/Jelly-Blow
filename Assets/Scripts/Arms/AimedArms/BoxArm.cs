using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BoxArm : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private float _speed;
	[SerializeField] private ParticleSystem _trailEffect;

	private SphereCollider _collider;
	private Vector3 _startPosition;
	private IEnumerator _coroutine;
	private bool _coroutineIsActive = false;
	private bool _inAction = false;
	private float _hitDistance = 0.02f;

	public bool CanBrokeBodyPart { get; private set; } = false;
	public bool InAction => _inAction;


	private void Awake()
    {
		_collider = GetComponent<SphereCollider>();
		_collider.enabled = false;
		_startPosition = transform.localPosition;

	}

	public void Hit(Vector3 target)
    {
		_collider.enabled = true;
		_coroutine = StartArmMovement(target);
		StartCoroutine(_coroutine);
		_trailEffect.Play();
		_animator.SetTrigger(AnimatorBoxArmController.States.Hit);
	}

	private IEnumerator StartArmMovement(Vector3 target, bool simpleHit = true)
    {
		CanBrokeBodyPart = true;
		_inAction = true;
		_coroutineIsActive = true;

		while (simpleHit == true ? (Vector3.Distance(transform.position, target) > _hitDistance) : transform.localPosition != target)
		{
			if (simpleHit == true)
				transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
			else
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, _speed * Time.deltaTime);

			yield return null;
		}

		CanBrokeBodyPart = false;

		if (simpleHit == true)
        {
			ReturnStartPosition();
		}
		else
        {
			_coroutineIsActive = false;
			_inAction = false;
		}
	}

	public void ReturnStartPosition()
    {
		_trailEffect.Stop();
		_collider.enabled = false;

		if (_coroutineIsActive == true)
			StopCoroutine(_coroutine);

		_coroutine = StartArmMovement(_startPosition, false);
		StartCoroutine(_coroutine);
	}
}
