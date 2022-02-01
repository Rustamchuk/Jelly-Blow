using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BoxArm : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private float _speed;
	
	private SphereCollider _collider;
	private Vector3 _startPosition;
	private IEnumerator _coroutine;
	private bool _coroutineIsActive = false;
	private bool _inAction = false;

	public bool CanBrokeBodyPart { get; private set; } = false;
	public bool InAction => _inAction;


	private void Awake()
    {
		_collider = GetComponent<SphereCollider>();
		_startPosition = transform.localPosition;

	}

	public void Hit(Vector3 target)
    {
		_coroutine = StartArmMovement(target);
		StartCoroutine(_coroutine);
		_animator.SetTrigger("Hit");
	}

	private IEnumerator StartArmMovement(Vector3 target, bool simpleHit = true, bool needOnCollider = false)
    {
		CanBrokeBodyPart = true;
		_inAction = true;
		_coroutineIsActive = true;

		while (transform.localPosition != target)
        {
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, _speed * Time.deltaTime);
			yield return null;
        }

		Debug.Log("Doleteli");
		CanBrokeBodyPart = false;

		if (needOnCollider == true)
			_collider.enabled = true;

		if (simpleHit == true)
        {
			ReturnStartPosition();
			Debug.Log("Vozvrat");
		}
		else
        {
			_coroutineIsActive = false;
			_inAction = false;
		}
	}

	public void ReturnStartPosition()
    {
		_collider.enabled = false;

		if (_coroutineIsActive == true)
			StopCoroutine(_coroutine);

		_coroutine = StartArmMovement(_startPosition, false, true);
		StartCoroutine(_coroutine);
	}
}
