using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ScreenGridGeneration))]
public class GridGenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();

        ScreenGridGeneration grid = (ScreenGridGeneration)target;

        if (GUILayout.Button("Generate Grid"))
        {
            grid.GenerateGrid();
        }

        if (GUILayout.Button("Destroy Grid"))
        {
            grid.DestroyGrid();
        }
    }
}
