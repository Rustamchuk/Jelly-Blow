using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlicedEnemy : JellyEnemy
{
    [Space(15), SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _remainingBodyMainRigidbody;
    [SerializeField] private SkinnedMeshRenderer _remainingBodyMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer _cuttedObjectMeshRenderer;
    [SerializeField] private Rigidbody _cuttedObjectRigidbody;
    [SerializeField] private Material _deadMaterial;

    public event UnityAction Killed;

    private void Start()
    {
        BodyPartOff(_cuttedObjectMeshRenderer, _cuttedObjectRigidbody);
    }

    public override void OnBrokened(BodyPartName bodyPartName)
    {
        _animator.enabled = false;
        BodyPartOff(_remainingBodyMeshRenderer, _remainingBodyMainRigidbody);
        Killed?.Invoke();
    }

    private void BodyPartOff(SkinnedMeshRenderer meshRenderer, Rigidbody cutedRigidbody)
    {
        meshRenderer.material = _deadMaterial;
        cutedRigidbody.velocity = new Vector3(Random.RandomRange(-1, 1), Random.RandomRange(0.5f, 1f), Random.RandomRange(2, 4));       //убрать магические числа
    }
}
