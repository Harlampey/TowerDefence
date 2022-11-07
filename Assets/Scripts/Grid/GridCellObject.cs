using UnityEngine;

[CreateAssetMenu(fileName = "GridCell", menuName = "Scriptable/GridCell")]
public class GridCellObject : ScriptableObject
{
    public enum CellType { Path, Ground }

    public CellType Type;
    public GameObject CellPrefab;
    public int yRotation;
}
