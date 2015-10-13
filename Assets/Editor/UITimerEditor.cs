using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UITimer))]
public class UITimerEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		UITimer myTarget = (UITimer)target;
		
		DrawDefaultInspector();
		EditorGUILayout.LabelField("Current State", myTarget.state.ToString());
	}
}