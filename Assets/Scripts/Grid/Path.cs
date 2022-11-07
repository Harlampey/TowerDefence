using System.Collections.Generic;
using UnityEngine;

public class Path: MonoBehaviour
{
    public static Path Instance;
    private void Awake()
    {
        Instance = this;
    }
    private List<Vector3> _waypoints = new List<Vector3>();

    public static Vector3 GetWaypointPosition(int index)
    {
        return Instance._waypoints[index];
    }

    public static void AddWaypointToList(Vector3 pos)
    {
        Instance._waypoints.Add(pos);
    }
}
