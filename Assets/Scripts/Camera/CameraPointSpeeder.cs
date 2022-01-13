using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointSpeeder : MonoBehaviour
{
    [SerializeField] private float _speedBeforePoint = 5;

    public float Speed => _speedBeforePoint;
}
