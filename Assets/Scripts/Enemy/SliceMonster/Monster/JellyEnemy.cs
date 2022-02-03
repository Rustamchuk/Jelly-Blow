using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JellyEnemy : MonoBehaviour
{
    [SerializeField] private BodyPart[] _bodyParts;

    public BodyPart[] BodyParts => _bodyParts;
    public bool Alive { get; protected set; } = true;

    private void OnEnable()
    {
        foreach (var bodyPart in _bodyParts)
        {
            bodyPart.Brokened += OnBrokened;
        }
    }

    private void OnDisable()
    {
        foreach (var bodyPart in _bodyParts)
        {
            bodyPart.Brokened -= OnBrokened;
        }
    }

    protected abstract void OnBrokened(BodyPartName bodyPartName);

    public abstract void Explosion(float force, Vector3 explosionPoint, float radius, float upwardsModifier, bool fullMonsterDiedOfExplosion = false);
}
