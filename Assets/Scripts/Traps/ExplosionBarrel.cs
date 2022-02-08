using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBarrel : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private ParticleSystem _explosionEffect;

    private Collider[] _colliders;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BoxArm boxArm))
        {
            if (boxArm.CanBrokeBodyPart)
            {
                boxArm.ReturnStartPosition();
                _colliders = Physics.OverlapSphere(transform.position, _radius);

                foreach (var collider in _colliders)
                {
                    if (collider.TryGetComponent(out JellyEnemy jellyEnemy) && jellyEnemy.Alive == true)
                    {
                        jellyEnemy.Explosion(_force, transform.position, _radius, _upwardsModifier);
                    }
                }

                _explosionEffect.Play();
                gameObject.SetActive(false);
            }
        }
    }
}
