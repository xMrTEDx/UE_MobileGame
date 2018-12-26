using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WindowComponent)),CanEditMultipleObjects]
public class WindowComponentEditor : Editor {

	public override void OnInspectorGUI()
	{
		base.DrawDefaultInspector();

		WindowComponent myScript = (WindowComponent)target;
        EditorGUILayout.BeginHorizontal();
		if(GUILayout.Button("Enable"))
        {
			if ( EditorApplication.isPlaying )
				myScript.EnableWindow();
			else
				Debug.LogWarning("You cannot enable window when game is not running");
            
        }
		if(GUILayout.Button("Disable"))
        {
			if ( EditorApplication.isPlaying )
            	myScript.DisableWindow();
			else
				Debug.LogWarning("You cannot disable window when game is not running");
        }
		EditorGUILayout.EndHorizontal();
	}
}
