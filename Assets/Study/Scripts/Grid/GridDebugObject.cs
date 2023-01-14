using UnityEngine;
using TMPro;

namespace StudyFromCodeMonkey.Study.Scripts.Grid
{
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] private TextMeshPro mTextMeshPro;
        private GridObject _gridObject;
        
        public void SetGridObject(GridObject gridObject)
        {
            _gridObject = gridObject;
        }

        private void Update()
        {
            mTextMeshPro.text = _gridObject.ToString();
        }
    }
}