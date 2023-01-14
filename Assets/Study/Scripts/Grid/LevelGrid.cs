using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts.Grid
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField] private Transform mGridDebugObjectPrefab;
        
        private GridSystem _gridSystem;
        
        public static LevelGrid Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There's More Then One LevelGrid " + transform + " " + Instance);
                Destroy(gameObject);
                return;
            }
            Instance = this;
            
            _gridSystem = new GridSystem(10, 10, 2f);
            _gridSystem.CreateDebugObject(mGridDebugObjectPrefab);
        }

        public void SetUnitAGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            gridObject.SetUnit(unit);
        }
        public Unit GetUnitAGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            return gridObject.GetUnit();
        }

        public void ClearUnitAGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            gridObject.SetUnit(null);
        }

        public void UnitMoveGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
        {
            ClearUnitAGridPosition(fromGridPosition);
            SetUnitAGridPosition(toGridPosition, unit);
        }

        public GridPosition GetGridPosition(Vector3 worldPosition) => _gridSystem.GetGridPosition(worldPosition);

    }
}