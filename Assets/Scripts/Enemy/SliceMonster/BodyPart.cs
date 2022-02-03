using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private BodyPartName _bodyPartName;

    public event UnityAction<BodyPartName> Brokened;
    public event UnityAction<Vector3> Touched;
    public event Action Finished;
    public event Action TrapAttack;

    private bool _alive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!_alive)
            return;

        if (other.TryGetComponent(out Arm arm))
        {
            if (arm.Attacking == true)
            {
                if (other.TryGetComponent(out Bullet bullet))
                {
                    if (bullet.CanBrokeBodyPart == true)
                    {
                        Brokened?.Invoke(_bodyPartName);
                        bullet.ChangeBrokedState();
                    }
                }

                arm.TouchedTrigger();
                Touched.Invoke(arm.BoxGlove.transform.position);
            }
        }
        else if (other.TryGetComponent(out BoxArm boxArm))
        {
            if (boxArm.CanBrokeBodyPart)
            {
                Brokened?.Invoke(_bodyPartName);
                boxArm.ReturnStartPosition();
                Touched.Invoke(boxArm.transform.position);
            }
        }
        else if (other.TryGetComponent(out PlayerMover player))
        {
            Finished.Invoke();
        }
        
        if (other.TryGetComponent(out Trap trap))
        {
            if (trap.Attacking)
                TrapAttack.Invoke();
        }
    }

    public void DeadPart() { _alive = false; }
}

public enum BodyPartName
{
    Head,
    Breast,
    Belly,
    RightArm,
    LeftArm,
    RightLeg,
    LeftLeg
}
