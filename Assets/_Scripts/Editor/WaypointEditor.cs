using UnityEditor;
using UnityEngine;
using System.Collections;
[InitializeOnLoad]
[CustomEditor(typeof(WaypointsPath))]
public class WaypointEditor : Editor {
    void OnSceneGUI()
    {
        WaypointsPath path = target as WaypointsPath;
        for (int i = 0; i < path.points.Length; i++)
        {
            Handles.BeginGUI();
            Vector3 pos = path.points[i];
            Handles.Label(pos,"point "+i);
            Handles.EndGUI();
            Vector3 vec = Handles.PositionHandle(pos, Quaternion.identity);
            path.points[i]=new Vector3(vec.x,path.transform.position.y,vec.z);

            if (i != 0)
            {
                Handles.DrawLine(path.points[i],path.points[i-1]);
            }
        }
    }
	
}
