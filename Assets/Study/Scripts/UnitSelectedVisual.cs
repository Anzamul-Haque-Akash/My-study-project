using System;
using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts
{
    public class UnitSelectedVisual : MonoBehaviour
    { 
        [SerializeField] private Unit unit;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        private void Start()
        {
            UnitActionSystem.Instance.OnSelectedUnitChange += UnitActionSystem_OnSelectedUnitChanged;
            UpdateVisual();
        }
        private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }
        private void UpdateVisual()
        {
            if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
            {
                _meshRenderer.enabled = true;
            }
            else
            {
                _meshRenderer.enabled = false;
            }
        }
    }
}

