using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CursorCircle))]
public class BuildCursor : MonoBehaviour
{
    #region Singlton
    public static BuildCursor Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("BuildCursor is Singlton!");
        }
    }
    #endregion
    public Cell SelectedCell;

    [SerializeField] private GameObject[] _meshes;
    private int _activeMeshId;
    

    private CursorCircle _cursorCircle;
    private bool _isEnabled;

    private void Start()
    {
        _cursorCircle = GetComponent<CursorCircle>();
    }

    public static void MoveCursor(Cell cell)
    {
        Instance.transform.DOKill();
        Instance.transform.DOMove(cell.transform.position, 0.1f);
        Instance.SelectedCell = cell;
    }

    public void Show(int meshId)
    {
        _meshes[_activeMeshId].SetActive(false);
        _activeMeshId = meshId;
        _meshes[_activeMeshId].SetActive(true);
        _cursorCircle.Show();
    }

    public void Hide()
    {
        _cursorCircle.Hide();
        _meshes[_activeMeshId].SetActive(false);
        SelectedCell = null;
    }

    public void SetCircleRadius(float radius)
    {
        _cursorCircle.CreatePoints(radius);
    }
}
