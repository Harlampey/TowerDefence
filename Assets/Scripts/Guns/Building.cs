using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private BuildCursor buildCursor;
    [SerializeField] private GameObject[] _towersPrefabs;

    private int _prefabID;
    private bool _isBuilding;

    private int[] _prices;

    private void Start()
    {
        _prices = new int[_towersPrefabs.Length];

        for (int i = 0; i < _prices.Length; i++)
        {
            _prices[i] = _towersPrefabs[i].GetComponent<Gun>().Price;
        }
    }

    private void Build()
    {
        if (_isBuilding && buildCursor.SelectedCell && Balance.TrySpendMoney(_prices[_prefabID]))
        {
            Cell cell = buildCursor.SelectedCell;

            if (!cell.IsTaken)
            {
                GameObject tower = Instantiate(_towersPrefabs[_prefabID], cell.transform.position, Quaternion.identity);
                cell.PlaceBuilding(tower);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Build();

            if (!Input.GetKey(KeyCode.LeftShift))
                StopBuilding();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopBuilding();
        }
    }

    public void SetGun(int id)
    {
        if (Balance.Instance.Money >= _prices[id])
        {
            _prefabID = id;

            Gun gun = _towersPrefabs[_prefabID].GetComponent<Gun>();
            buildCursor.SetCircleRadius(gun.Radius);
            buildCursor.Show(_prefabID);

            _isBuilding = true;
        }
    }

    private void StopBuilding()
    {
        buildCursor.Hide();
        _isBuilding = false;
    }
}
