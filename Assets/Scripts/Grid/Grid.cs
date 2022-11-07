using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int _gridWidth = 16, _gridHeight = 8;
    [SerializeField] private int _minPathLength = 30;
    [SerializeField] private GridCellObject[] _pathCells;
    [SerializeField] private GridCellObject[] _SceneryCallObjects;
    [SerializeField] private Transform _gridParent;

    [Space]
    [SerializeField] private GameObject _gamePanel;

    private PathGenerator pathGenerator;
    private void Start()
    {
        pathGenerator = new PathGenerator(_gridWidth, _gridHeight);
        List<Vector2Int> pathCells = pathGenerator.GeneratePath();

        int pathSize = pathCells.Count;

        while (pathSize < _minPathLength)
        {
            pathCells = pathGenerator.GeneratePath();
            pathSize = pathCells.Count;
        }


        
        StartCoroutine(LayPatchCells(pathCells));
        StartCoroutine(LaySceneryCells(pathCells));
    }

    private IEnumerator LayPatchCells(List<Vector2Int> pathCells)
    {
        foreach (Vector2Int pathCell in pathCells)
        {
            
            int neighbourValue = pathGenerator.getCellNeighbourValue(pathCell.x, pathCell.y);
            GameObject cellPrefab = _pathCells[neighbourValue].CellPrefab;

            Instantiate(cellPrefab, new Vector3(pathCell.x, 0, pathCell.y), Quaternion.Euler(0, this._pathCells[neighbourValue].yRotation, 0), _gridParent);
            yield return new WaitForSeconds(0.05f);
            
        }

        _gamePanel.SetActive(true);
    }

    private IEnumerator LaySceneryCells(List<Vector2Int> pathCells)
    {
        for (int x = 0; x < _gridWidth; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                if (pathGenerator.CellIsEmpty(x, y))
                {
                    int randomIndex = Random.Range(0, _SceneryCallObjects.Length);
                    Instantiate(_SceneryCallObjects[randomIndex].CellPrefab, new Vector3(x, 0, y), Quaternion.identity, _gridParent);

                    yield return new WaitForSeconds(0.015f);
                }
            }
        }
    }
}
