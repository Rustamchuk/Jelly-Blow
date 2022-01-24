using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour
{
    private Vector3 _standartRotaion;

    private void Awake()
    {
        _standartRotaion = transform.localEulerAngles;
    }

    public void ResetHeadRotation()
    {
        transform.localEulerAngles = _standartRotaion;
    }
}
