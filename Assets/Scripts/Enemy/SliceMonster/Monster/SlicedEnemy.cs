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
    [Header("Параметры силы отлетания частей")]
    [SerializeField] private float _horizontalSpread;
    [SerializeField] private float _verticalForce;
    [SerializeField] private float _pushForce;

    private int _punchesCount = 0;
    private bool _exploded = false;

    public event UnityAction<bool> Killed;
    public event UnityAction Blowded;

    protected override void OnBrokened(BodyPartName bodyPartName)
    {
        _punchesCount++;

        if (_punchesCount == _punchesToKill)
        {
            _animator.enabled = false;
            Killed?.Invoke(_exploded);
            Alive = false;
            BodyPartOff(_remainingBodyMeshRenderer, _remainingBodyMainRigidbody);
        }
    }

    private void BodyPartOff(SkinnedMeshRenderer meshRenderer, Rigidbody cutedRigidbody)
    {
        meshRenderer.material = _deadMaterial;
        cutedRigidbody.velocity = new Vector3(Random.RandomRange(-_horizontalSpread, _horizontalSpread), _verticalForce, _pushForce);
    }

    public void Init()
    {
        BodyPartOff(_cuttedObjectMeshRenderer, _cuttedObjectRigidbody);
    }

    public override void Explosion(float force, Vector3 explosionPoint, float radius, float upwardsModifier, bool fullMonsterDiedOfExplosion = false)
    {
        _animator.enabled = false;
        _exploded = true;
        Killed?.Invoke(_exploded);
        Alive = false;

        if (fullMonsterDiedOfExplosion == false)
        {
            _remainingBodyMeshRenderer.material = _deadMaterial;
            _remainingBodyMainRigidbody.AddExplosionForce(force, explosionPoint, radius, upwardsModifier, ForceMode.VelocityChange);
        }
        else
        {
            _remainingBodyMeshRenderer.material = _deadMaterial;
            _remainingBodyMainRigidbody.AddExplosionForce(force, explosionPoint, radius, upwardsModifier, ForceMode.VelocityChange);
            _cuttedObjectMeshRenderer.material = _deadMaterial;
            _cuttedObjectRigidbody.AddExplosionForce(force, explosionPoint, radius, upwardsModifier, ForceMode.VelocityChange);
        }

        Blowded?.Invoke();
    }
}
