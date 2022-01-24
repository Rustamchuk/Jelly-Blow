using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingBodyParts : MonoBehaviour
{
    [SerializeField] private GameObject _monster;
    [Space(10), Header("Голова и остальное тело")]
    [SerializeField] private GameObject _bodyAndHead;
    [SerializeField] private GameObject _head;
    [SerializeField] private Rigidbody _headRigidbody;
    [SerializeField] private ResetRotation resetRotation;
    [Space(10), Header("Правая рука и остальное тело")]
    [SerializeField] private GameObject _bodyAndRightArm;
    [SerializeField] private GameObject _rightArm;
    [SerializeField] private Rigidbody _rightArmRigidbody;
    [Space(10), Header("Левая рука и остальное тело")]
    [SerializeField] private GameObject _bodyAndLeftArm;
    [SerializeField] private GameObject _leftArm;
    [SerializeField] private Rigidbody _leftArmRigidbody;
    [Space(10), Header("Левая нога и остальное тело")]
    [SerializeField] private GameObject _bodyAndLeftLeg;
    [SerializeField] private GameObject _leftLeg;
    [SerializeField] private Rigidbody _leftLegRigidbody;
    [Space(10), Header("Правая нога и остальное тело")]
    [SerializeField] private GameObject _bodyAndRightLeg;
    [SerializeField] private GameObject _rightLeg;
    [SerializeField] private Rigidbody _rightLegRigidbody;
    [Space(10), Header("Верхняя часть тела и нижняя, остается верхняя")]
    [SerializeField] private GameObject _topBodyAndBottom;
    [SerializeField] private GameObject _bottomBody;
    [SerializeField] private Rigidbody _bottomBodyRigidbody;

    [Space(10), SerializeField] private Button _headOFFButton;
    [SerializeField] private Button _rightArmOFFButton;
    [SerializeField] private Button _leftArmOFFButton;
    [SerializeField] private Button _rightLegOFFButton;
    [SerializeField] private Button _leftLegOFFButton;
    [SerializeField] private Button _BottomBodyOFFButton;
    [SerializeField] private Button _resetMonsterButton;

    private void OnEnable()
    {
        _headOFFButton.onClick.AddListener(HeadOFF);
        _rightArmOFFButton.onClick.AddListener(RightArmOff);
        _leftArmOFFButton.onClick.AddListener(LeftArmOff);
        _rightLegOFFButton.onClick.AddListener(RightLegOff);
        _leftLegOFFButton.onClick.AddListener(LeftLegOff);
        _BottomBodyOFFButton.onClick.AddListener(BottomBodyOff);
        _resetMonsterButton.onClick.AddListener(ResetMonster);
    }

    private void OnDisable()
    {
        _headOFFButton.onClick.RemoveListener(HeadOFF);
        _rightArmOFFButton.onClick.RemoveListener(RightArmOff);
        _leftArmOFFButton.onClick.RemoveListener(LeftArmOff);
        _rightLegOFFButton.onClick.RemoveListener(RightLegOff);
        _leftLegOFFButton.onClick.RemoveListener(LeftLegOff);
        _BottomBodyOFFButton.onClick.RemoveListener(BottomBodyOff);
        _resetMonsterButton.onClick.RemoveListener(ResetMonster);
    }

    private void HeadOFF()
    {
        BodyPartOff(_monster, _bodyAndHead, _headRigidbody);
    }

    private void RightArmOff()
    {
        BodyPartOff(_monster, _bodyAndRightArm, _rightArmRigidbody);
    }

    private void LeftArmOff()
    {
        BodyPartOff(_monster, _bodyAndLeftArm, _leftArmRigidbody);
    }

    private void RightLegOff()
    {
        BodyPartOff(_monster, _bodyAndRightLeg, _rightLegRigidbody);
    }

    private void LeftLegOff()
    {
        BodyPartOff(_monster, _bodyAndLeftLeg, _leftLegRigidbody);
    }

    private void BottomBodyOff()
    {
        BodyPartOff(_monster, _topBodyAndBottom, _bottomBodyRigidbody);
    }

    private void BodyPartOff(GameObject mainBodyPart, GameObject slicedMonster, Rigidbody detachablePart)
    {
        mainBodyPart.SetActive(false);
        slicedMonster.SetActive(true);
        detachablePart.isKinematic = false;
        detachablePart.velocity = new Vector3(Random.RandomRange(-1, 1), Random.RandomRange(0.5f, 1f), Random.RandomRange(2, 4));
    }

    private void ResetMonster()
    {
        _bodyAndHead.SetActive(false);
        ResetCutBodyPart(_head, _headRigidbody);

        _bodyAndLeftArm.SetActive(false);
        ResetCutBodyPart(_leftArm, _leftArmRigidbody);

        _bodyAndRightArm.SetActive(false);
        ResetCutBodyPart(_rightArm, _rightArmRigidbody);

        _bodyAndLeftLeg.SetActive(false);
        ResetCutBodyPart(_leftLeg, _leftLegRigidbody);

        _bodyAndRightLeg.SetActive(false);
        ResetCutBodyPart(_rightLeg, _rightLegRigidbody);

        _topBodyAndBottom.SetActive(false);
        ResetCutBodyPart(_bottomBody, _bottomBodyRigidbody);

        resetRotation.ResetHeadRotation();
        _monster.SetActive(true);
    }

    private void ResetCutBodyPart(GameObject cutPart, Rigidbody cutRigidbody)
    {
        cutRigidbody.isKinematic = true;
        cutPart.transform.localPosition = Vector3.zero;
        cutPart.transform.localRotation = Quaternion.identity;
    }
}
