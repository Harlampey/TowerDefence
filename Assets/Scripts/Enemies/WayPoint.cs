using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private void Start()
    {
        Path.AddWaypointToList(transform.position);
    }
}
