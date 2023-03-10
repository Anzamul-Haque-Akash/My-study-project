using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts.Math
{
    public class MathTest : MonoBehaviour
    {
        [SerializeField] private Transform a;
        [SerializeField] private Transform b;
        [SerializeField] private Transform c;
        [SerializeField] private Transform d;

        private void Start()
        {
            a.position = new Vector3(3f, 2f, 0f);
            b.position = new Vector3(-4f, 1f, 0f);
            c.position = (a.position + b.position);
            d.position = (a.position - b.position);

            Vector3 distanceVector = (b.position - a.position);
            float distance = Mathf.Sqrt(Mathf.Pow(distanceVector.x, 2) + Mathf.Pow(distanceVector.y, 2));
            Debug.Log("Distance from A to B : " + distance);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(b.position, a.position);
            Gizmos.DrawLine(Vector3.zero, d.position);
            
            Gizmos.color = Color.green;
            Gizmos.DrawLine(b.position, c.position);
            Gizmos.DrawLine(Vector3.zero, a.position);
        }
    }
}