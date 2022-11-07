using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    public bool IsTaken = true;
    private void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, 0.2f);
    }

    public void PlaceBuilding(GameObject prefab)
    {
        IsTaken = true;
    }

    private void OnMouseEnter()
    {
        BuildCursor.MoveCursor(this);
    }
}
