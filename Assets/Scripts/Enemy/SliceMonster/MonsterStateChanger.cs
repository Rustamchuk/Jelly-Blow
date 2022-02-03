using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MonsterStateChanger : MonoBehaviour
{
    [SerializeField] private CompleteEnemy _completeJellyMonster;
    [Space(10), Header("������ ��� ������")]
    [SerializeField] private SlicedEnemy _jellyMonsterWithoutHead;
    [Space(10), Header("������ ��� ������ ����")]
    [SerializeField] private SlicedEnemy _jellyMonsterWithoutRightArm;
    [Space(10), Header("������ ��� ����� ����")]
    [SerializeField] private SlicedEnemy _jellyMonsterWithoutLeftArm;
    [Space(10), Header("������ ��� ������ ����")]
    [SerializeField] private SlicedEnemy _jellyMonsterWithoutRightLeg;
    [Space(10), Header("������ ��� ����� ����")]
    [SerializeField] private SlicedEnemy _jellyMonsterWithoutLeftLeg;
    [Space(10), Header("������ ��� ������ ����� ����")]
    [SerializeField] private SlicedEnemy _jellyMonsterWithoutBottomBody;
    [Space(10), Header("������ ��� ������� ����� ����")]
    [SerializeField] private SlicedEnemy _jellyMonsterWithoutTopBody;
    [Space(20), SerializeField] private List<SlicedEnemy> _slicedEnemies;

    public event UnityAction Dead;
    public event UnityAction Stoped;
    public event UnityAction<float> WaitToGo;
    public event UnityAction Exploding;

    private List<BodyPart> _bodyParts = new List<BodyPart>();

    public List<BodyPart> ReturnParts()
    {
        AddParts(_completeJellyMonster.BodyParts);
        AddParts(_jellyMonsterWithoutHead.BodyParts);
        AddParts(_jellyMonsterWithoutRightArm.BodyParts);
        AddParts(_jellyMonsterWithoutLeftArm.BodyParts);
        AddParts(_jellyMonsterWithoutRightLeg.BodyParts);
        AddParts(_jellyMonsterWithoutLeftLeg.BodyParts);
        AddParts(_jellyMonsterWithoutBottomBody.BodyParts);
        AddParts(_jellyMonsterWithoutTopBody.BodyParts);

        return _bodyParts;
    }

    private List<BodyPart> AddParts(BodyPart[] parts)
    {
        foreach (var part in parts)
        {
            _bodyParts.Add(part);
        }

        return _bodyParts;
    }

    private void OnEnable()
    {
        _completeJellyMonster.LostHead += OnLostHead;
        _completeJellyMonster.LostRightArm += OnLostRightArm;
        _completeJellyMonster.LostLeftArm += OnLostLeftArm;
        _completeJellyMonster.LostRightLeg += OnLostRightLeg;
        _completeJellyMonster.LostLeftLeg += OnLostLeftLeg;
        _completeJellyMonster.LostBelly += OnLostBelly;
        _completeJellyMonster.LostBreast += OnLostBreast;
        _completeJellyMonster.Exploded += OnExploded;
        _jellyMonsterWithoutHead.Killed += OnKilled;
        _jellyMonsterWithoutRightArm.Killed += OnKilled;
        _jellyMonsterWithoutLeftArm.Killed += OnKilled;
        _jellyMonsterWithoutRightLeg.Killed += OnKilled;
        _jellyMonsterWithoutLeftLeg.Killed += OnKilled;
        _jellyMonsterWithoutBottomBody.Killed += OnKilled;
        _jellyMonsterWithoutTopBody.Killed += OnKilled;
        _jellyMonsterWithoutHead.Blowded += OnBlowded;
        _jellyMonsterWithoutRightArm.Blowded += OnBlowded;
        _jellyMonsterWithoutLeftArm.Blowded += OnBlowded;
        _jellyMonsterWithoutRightLeg.Blowded += OnBlowded;
        _jellyMonsterWithoutLeftLeg.Blowded += OnBlowded;
        _jellyMonsterWithoutBottomBody.Blowded += OnBlowded;
        _jellyMonsterWithoutTopBody.Blowded += OnBlowded;
    }

    private void OnDisable()
    {
        _completeJellyMonster.LostHead -= OnLostHead;
        _completeJellyMonster.LostRightArm -= OnLostRightArm;
        _completeJellyMonster.LostLeftArm -= OnLostLeftArm;
        _completeJellyMonster.LostRightLeg -= OnLostRightLeg;
        _completeJellyMonster.LostLeftLeg -= OnLostLeftLeg;
        _completeJellyMonster.LostBelly -= OnLostBelly;
        _completeJellyMonster.LostBreast -= OnLostBreast;
        _completeJellyMonster.Exploded -= OnExploded;
        _jellyMonsterWithoutHead.Killed -= OnKilled;
        _jellyMonsterWithoutRightArm.Killed -= OnKilled;
        _jellyMonsterWithoutLeftArm.Killed -= OnKilled;
        _jellyMonsterWithoutRightLeg.Killed -= OnKilled;
        _jellyMonsterWithoutLeftLeg.Killed -= OnKilled;
        _jellyMonsterWithoutBottomBody.Killed -= OnKilled;
        _jellyMonsterWithoutTopBody.Killed -= OnKilled;
        _jellyMonsterWithoutHead.Blowded -= OnBlowded;
        _jellyMonsterWithoutRightArm.Blowded -= OnBlowded;
        _jellyMonsterWithoutLeftArm.Blowded -= OnBlowded;
        _jellyMonsterWithoutRightLeg.Blowded -= OnBlowded;
        _jellyMonsterWithoutLeftLeg.Blowded -= OnBlowded;
        _jellyMonsterWithoutBottomBody.Blowded -= OnBlowded;
        _jellyMonsterWithoutTopBody.Blowded -= OnBlowded;
    }

    private void OnLostHead()
    {
        IncludeSlicedMonster(_jellyMonsterWithoutHead);
        //WaitToGo.Invoke(3.2f);
        Stoped?.Invoke();
    }

    private void OnLostRightArm()
    {
        IncludeSlicedMonster(_jellyMonsterWithoutRightArm);
    }

    private void OnLostLeftArm()
    {
        IncludeSlicedMonster(_jellyMonsterWithoutLeftArm);
    }

    private void OnLostRightLeg()
    {
        IncludeSlicedMonster(_jellyMonsterWithoutRightLeg);
    }

    private void OnLostLeftLeg()
    {
        IncludeSlicedMonster(_jellyMonsterWithoutLeftLeg);
    }
    
    private void OnLostBelly()
    {
        IncludeSlicedMonster(_jellyMonsterWithoutBottomBody);
    }
    
    private void OnLostBreast()
    {
        IncludeSlicedMonster(_jellyMonsterWithoutTopBody);
    }

    private void OnExploded(float force, Vector3 explosionPoint, float radius, float upwardsModifier)
    {
        int randomIndex = Random.RandomRange(0, _slicedEnemies.Count);

        IncludeSlicedMonster(_slicedEnemies[randomIndex]);
        _slicedEnemies[randomIndex].Explosion(force, explosionPoint, radius, upwardsModifier, true);
        Exploding?.Invoke();
    }

    private void OnBlowded()
    {
        Exploding?.Invoke();
    }

    private void OnKilled()
    {
        Dead.Invoke();

        foreach (var part in _bodyParts)
        {
            part.DeadPart();
        }
    }

    private void IncludeSlicedMonster(SlicedEnemy slicedMonster)
    {
        _completeJellyMonster.gameObject.SetActive(false);
        slicedMonster.gameObject.SetActive(true);
        slicedMonster.Init();
    }
}