using System;
using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts
{
    public class UnitActionSystem : MonoBehaviour
    {
        [SerializeField] private Unit selectedUnit;
        [SerializeField] private LayerMask unitLayerMask;

        public event EventHandler OnSelectedUnitChange;

        public static UnitActionSystem Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There's More Then One UnitActionSystem " + transform + " " + Instance);
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(TryHandleUnitSelection()) return;
                
                selectedUnit.Move(MouseWorld.GetPosition());
            }
        }
        private bool TryHandleUnitSelection()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitLayerMask))
            { 
                if(hit.transform.TryGetComponent<Unit>(out Unit unit))
                {
                    SelectedUnit(unit);
                    return true;
                }
            }
            return false;
        }
        private void SelectedUnit(Unit unit)
        {
            selectedUnit = unit;
            OnSelectedUnitChange!.Invoke(this, EventArgs.Empty);
        }

        public Unit GetSelectedUnit()
        {
            return selectedUnit;
        }
    }
}
