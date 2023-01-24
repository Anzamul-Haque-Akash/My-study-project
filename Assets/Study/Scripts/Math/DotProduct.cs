using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts.Math
{
    public class DotProduct : MonoBehaviour
    {
        [SerializeField] private RayThrower mRayThrower;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                RaycastHit hit;
                hit = mRayThrower.ThrowRay();
                
                Debug.Log(hit.point.normalized);
            }
        }
    }
}