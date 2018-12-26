using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Window)),CanEditMultipleObjects]
public class WindowEditor : Editor {

	public override void OnInspectorGUI()
	{
		base.DrawDefaultInspector();

		Window myScript = (Window)target;
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
