using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(BezierEnemy))]
public class EnemyMovementInspector : Editor
{
    private void OnSceneViewGUI(SceneView sv)
    {
        BezierEnemy em = target as BezierEnemy;
        


        em.StartPoint = Handles.PositionHandle(em.StartPoint, Quaternion.identity);
        em.endPoint = Handles.PositionHandle(em.endPoint, Quaternion.identity);
        em.startTangent = Handles.PositionHandle(em.startTangent, Quaternion.identity);
        em.endTangent = Handles.PositionHandle(em.endTangent, Quaternion.identity);

        Handles.DrawBezier(em.StartPoint, em.endPoint, em.startTangent, em.endTangent, Color.red, null, 2f);

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        //EditorUtility.SetDirty(em);

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
