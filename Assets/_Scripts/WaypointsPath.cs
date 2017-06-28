using UnityEngine;
using System.Collections;

public class WaypointsPath : MonoBehaviour
{
    public static WaypointsPath instance;
    public Vector3[] points=new Vector3[3];

    void Awake()
    {
        instance = this;
    }
}
