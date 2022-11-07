using UnityEngine;

public class CursorCircle : MonoBehaviour
{
    [Range(0, 50)]
    public int _segments = 50;

    private LineRenderer _line;

    void Start()
    {
        _line = gameObject.GetComponent<LineRenderer>();

        _line.positionCount = _segments + 1;
        _line.useWorldSpace = false;
    }

    public void CreatePoints(float radius)
    {
        float x;
        float z;

        float angle = 20f;

        for (int i = 0; i < (_segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            _line.SetPosition(i, new Vector3(x, 0.4f, z));

            angle += 360f / _segments;
        }
    }

    public void Show()
    {
        _line.enabled = true;
    }

    public void Hide()
    {
        _line.enabled = false;
    }
}
