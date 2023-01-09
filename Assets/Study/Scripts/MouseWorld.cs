using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts
{
    public class MouseWorld : MonoBehaviour
    {
        private static MouseWorld _instance;
        
        [SerializeField] private LayerMask mousePlaneLayerMask;
        
        private Camera _cam;
        private void Awake()
        {
            _instance = this;
        }
        public static Vector3 GetPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _instance.mousePlaneLayerMask);

            return hit.point;
        }
    }
}