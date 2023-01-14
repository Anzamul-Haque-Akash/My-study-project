using System.Collections.Generic;
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

        public void AddUnitAGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            gridObject.AddUnit(unit);
        }
        public List<Unit> GetUnitListAGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            return gridObject.GetUnitList();
        }

        public void RemoveUnitAGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            gridObject.RemoveUnit(unit);
        }

        public void UnitMoveGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
        {
            RemoveUnitAGridPosition(fromGridPosition, unit);
            AddUnitAGridPosition(toGridPosition, unit);
        }

        public GridPosition GetGridPosition(Vector3 worldPosition) => _gridSystem.GetGridPosition(worldPosition);

    }
}