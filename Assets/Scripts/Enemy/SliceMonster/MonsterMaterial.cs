using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMaterial : MonoBehaviour
{
    [Header("�������� ��� ����")]
    [SerializeField] private Material _monsterBodyMaterial;
    [SerializeField] private SkinnedMeshRenderer[] _bodyMeshRenderers;
    [Space(15), Header("�������� ��� ����")]
    [SerializeField] private Material _monsterEyeMaterial;
    [SerializeField] private SkinnedMeshRenderer[] _eyeMeshRenderers;

    private void Awake()
    {
        foreach (var material in _bodyMeshRenderers)
        {
            material.material = _monsterBodyMaterial;
        }

        foreach (var material in _eyeMeshRenderers)
        {
            material.material = _monsterEyeMaterial;
        }
    }
}
