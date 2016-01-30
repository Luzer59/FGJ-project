using UnityEngine;
using UnityEditor;
using System.Collections;

public class CAM : MonoBehaviour
{

    void OnGUI()
    {
        EditorGUILayout.TextField("SceneViewCameraAngle", "" + SceneView.lastActiveSceneView.rotation);
    }
}