using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompleteEnemy : JellyEnemy
{
    public event UnityAction LostLeftLeg;
    public event UnityAction LostRightLeg;
    public event UnityAction LostLeftArm;
    public event UnityAction LostRightArm;
    public event UnityAction LostBelly;
    public event UnityAction LostBreast;
    public event UnityAction LostHead;

    public override void OnBrokened(BodyPartName bodyPartName)
    {
        switch (bodyPartName)
        {
            default:
            case BodyPartName.Head:
                LostHead?.Invoke();
                break;

            case BodyPartName.LeftArm:
                LostLeftArm?.Invoke();
                break;

            case BodyPartName.RightArm:
                LostRightArm?.Invoke();
                break;

            case BodyPartName.Belly:
                LostBelly?.Invoke();
                break;

            case BodyPartName.Breast:
                LostBreast?.Invoke();
                break;

            case BodyPartName.LeftLeg:
                LostLeftLeg?.Invoke();
                break;

            case BodyPartName.RightLeg:
                LostRightLeg?.Invoke();
                break;
        }
    }
}
