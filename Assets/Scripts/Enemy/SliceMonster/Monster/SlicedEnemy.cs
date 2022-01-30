using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlicedEnemy : JellyEnemy
{
    [Space(15), SerializeField] private int _punchesToKill;
    [Space(20), SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _remainingBodyMainRigidbody;
    [SerializeField] private SkinnedMeshRenderer _remainingBodyMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer _cuttedObjectMeshRenderer;
    [SerializeField] private Rigidbody _cuttedObjectRigidbody;
    [SerializeField] private Material _deadMaterial;
    [Header("��������� ���� ��������� ������")]
    [SerializeField] private float _horizontalSpread;
    [SerializeField] private float _verticalForce;
    [SerializeField] private float _pushForce;

    private int _punchesCount = 0;

    public event UnityAction Killed;

    private void Start()
    {
        BodyPartOff(_cuttedObjectMeshRenderer, _cuttedObjectRigidbody);
    }

    public override void OnBrokened(BodyPartName bodyPartName)
    {
        _punchesCount++;

        if (_punchesCount == _punchesToKill)
        {
            _animator.enabled = false;
            Killed?.Invoke();
            BodyPartOff(_remainingBodyMeshRenderer, _remainingBodyMainRigidbody);
        }
    }

    private void BodyPartOff(SkinnedMeshRenderer meshRenderer, Rigidbody cutedRigidbody)
    {
        meshRenderer.material = _deadMaterial;
        cutedRigidbody.velocity = new Vector3(Random.RandomRange(-_horizontalSpread, _horizontalSpread), _verticalForce, _pushForce);
    }
}
