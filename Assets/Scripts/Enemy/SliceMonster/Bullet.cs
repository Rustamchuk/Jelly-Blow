using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool CanBrokeBodyPart { get; private set; } = true;

    public void ChangeBrokedState()
    {
        CanBrokeBodyPart = false;
    }
}
