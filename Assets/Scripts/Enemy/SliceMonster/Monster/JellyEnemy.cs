using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JellyEnemy : MonoBehaviour
{
    [SerializeField] private BodyPart[] _bodyParts;

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

    public abstract void OnBrokened(BodyPartName bodyPartName);
}
