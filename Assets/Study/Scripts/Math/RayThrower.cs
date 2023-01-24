using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts.Math
{
    public class RayThrower : MonoBehaviour
    {
        [SerializeField, Range(1f, 500f)] private float mRayRange;
        
        private RaycastHit _hit;

        public RaycastHit ThrowRay()
        {
            if (Physics.Raycast(transform.position, transform.forward, out _hit, mRayRange))
            {
                return _hit; 
            }

            return _hit;
        }

    }
}