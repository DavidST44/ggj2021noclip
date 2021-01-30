using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class EditorExtensions
{
    [MenuItem("NoClip/Fit Anchors")]
    private static void FitAnchors()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (var go in gos)
        {
            RectTransform rt = go.GetComponent<RectTransform>();
            if (rt && rt.gameObject.activeInHierarchy)
            {
                Vector2 initPos = rt.localPosition;

                Rect parentRect = rt.parent.GetComponent<RectTransform>().GetScreenRect();
                Rect objectRect = rt.GetScreenRect();

                float left = (objectRect.xMin - parentRect.xMin) / parentRect.width;
                float right = 1 - (parentRect.xMax - objectRect.xMax) / parentRect.width;
                float bottom = (objectRect.yMin - parentRect.yMin) / parentRect.height;
                float top = 1 - (parentRect.yMax - objectRect.yMax) / parentRect.height;

                Undo.RecordObject(rt, "Set Anchors");
                rt.anchorMin = new Vector2(left, bottom);
                rt.anchorMax = new Vector2(right, top);
                rt.sizeDelta = rt.anchoredPosition = new Vector2(0, 0);
                //rt.localPosition = initPos;
            }
        }
    }

    private static Rect GetScreenRect(this RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        for (int i = 0; i < corners.Length; i++)
        {
            corners[i] = Camera.main.WorldToScreenPoint(corners[i]);
        }
        Vector2 bottomLeft = corners[0];
        Vector2 topRight = corners[2];
        return new Rect(bottomLeft, topRight - bottomLeft);
    }

    public static string GetSelectionPath()
    {
        string path = "Assets";
        foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
            }
            break;
        }
        return path;
    }
}