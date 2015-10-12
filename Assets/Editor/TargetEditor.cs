using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Target))]
public class TargetEditor : Editor {

	public override void OnInspectorGUI()
	{
		Target myTarget = (Target)target;

		DrawDefaultInspector();
		EditorGUILayout.LabelField("Current State", myTarget.state.ToString());
		EditorGUILayout.LabelField("Current Hunger", myTarget.CurrentHunger.ToString());
	}
}