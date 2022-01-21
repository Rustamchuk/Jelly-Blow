using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathPoint))]
[CanEditMultipleObjects]
public class PathComponentEditor : Editor
{
    PathPoint _object;

	[SerializeField] private SerializedProperty _pointType;
	[SerializeField] private SerializedProperty _lookDirection;
	[SerializeField] private SerializedProperty _startPoint;
	[SerializeField] private SerializedProperty _guidePoint1;
	[SerializeField] private SerializedProperty _guidePoint2;
	[SerializeField] private SerializedProperty _endPoint;
	[SerializeField] private SerializedProperty _battlePoint;
	[SerializeField] private SerializedProperty _enemies;
	[SerializeField] private SerializedProperty _lastPoint;

	void OnEnable()
	{
		_object = target as PathPoint;

		_pointType = serializedObject.FindProperty("_pointType");
		_lookDirection = serializedObject.FindProperty("_lookDirection");
		_startPoint = serializedObject.FindProperty("_startPoint");
		_guidePoint1 = serializedObject.FindProperty("_guidePoint1");
		_guidePoint2 = serializedObject.FindProperty("_guidePoint2");
		_endPoint = serializedObject.FindProperty("_endPoint");
		_battlePoint = serializedObject.FindProperty("_battlePoint");
		_enemies = serializedObject.FindProperty("_enemies");
		_lastPoint = serializedObject.FindProperty("_lastPoint");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(_pointType);

		if(_object.PointType == MovingPoints.Walk)
        {
			EditorGUILayout.PropertyField(_lookDirection);
		}
		else if(_object.PointType == MovingPoints.Jump)
        {
			EditorGUILayout.PropertyField(_lookDirection);
			EditorGUILayout.PropertyField(_startPoint);
			EditorGUILayout.PropertyField(_guidePoint1);
			EditorGUILayout.PropertyField(_guidePoint2);
			EditorGUILayout.PropertyField(_endPoint);
		}

		EditorGUILayout.PropertyField(_battlePoint);

		if (_object.BattlePoint == true)
        {
			EditorGUILayout.PropertyField(_enemies);
		}

		EditorGUILayout.PropertyField(_lastPoint);

		serializedObject.ApplyModifiedProperties();
	}
}
