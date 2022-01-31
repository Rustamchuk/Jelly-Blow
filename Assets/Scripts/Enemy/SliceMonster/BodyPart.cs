using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private BodyPartName _bodyPartName;

    public event UnityAction<BodyPartName> Brokened;
    public event UnityAction<Vector3> Touched;

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
            Brokened?.Invoke(_bodyPartName);
            boxArm.ReturnStartPosition();
            Touched.Invoke(boxArm.transform.position);
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
