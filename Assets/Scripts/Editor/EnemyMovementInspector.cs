using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(BezierCurve))]
public class EnemyMovementInspector : Editor
{
    private void OnSceneViewGUI(SceneView sv)
    {
        BezierCurve em = target as BezierCurve;
        EditorGUI.BeginChangeCheck();
        Handles.DrawBezier(em.startPoint, em.endPoint, em.startTangent, em.endTangent, Color.red, null, 2f);
        if (EditorGUI.EndChangeCheck())
        {

            Undo.RecordObject(target, "Changed Enemy Path");
            em.startPoint = Handles.PositionHandle(em.startPoint, Quaternion.identity);
            em.endPoint = Handles.PositionHandle(em.endPoint, Quaternion.identity);
            em.startTangent = Handles.PositionHandle(em.startTangent, Quaternion.identity);
            em.endTangent = Handles.PositionHandle(em.endTangent, Quaternion.identity);
   
        }


    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
        SceneView.onSceneGUIDelegate += OnSceneViewGUI;
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneView.onSceneGUIDelegate -= OnSceneViewGUI;
    }
}
