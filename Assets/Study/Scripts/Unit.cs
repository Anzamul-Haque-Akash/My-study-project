using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Animator unityAnimator; 
        [SerializeField] private float moveSpeed = 4f;
        
        private Vector3 _targetPosition;
        private float _stoppingDistance = 0.1f;
        
        private void Update()
        {
            Transform unitTransform = transform;
            
            if (Vector3.Distance(unitTransform.position, _targetPosition) > _stoppingDistance)
            {
                Vector3 position = unitTransform.position;
                Vector3 moveDirection = (_targetPosition - position).normalized;
                position += moveDirection * (moveSpeed * Time.deltaTime);
                unitTransform.position = position;

                transform.forward = Vector3.Lerp(transform.forward,moveDirection, 0.5f);
                
                unityAnimator.SetBool("isWalking", true);
            }
            else
            {
                unityAnimator.SetBool("isWalking", false);
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                Move(MouseWorld.GetPosition());
            }
        }

        private void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }
}
