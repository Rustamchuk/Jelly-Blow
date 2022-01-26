using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeadBodyRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;

    protected void OnKilled()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
