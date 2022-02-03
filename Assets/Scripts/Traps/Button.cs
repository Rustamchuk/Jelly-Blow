using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Trap _trap;

    private bool _clicked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BoxArm arm) && !_clicked)
        {
            if (arm.CanBrokeBodyPart)
            {
                _trap.ActivateAttack();
                _clicked = true;
            }
        }
    }
}
