using System;
using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Animator unityAnimator;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float stoppingDistance;
        
        private Vector3 _targetPosition;

        private void Awake()
        {
            _targetPosition = transform.position;
        }

        private void Update()
        {
            Transform unitTransform = transform;
            
            if (Vector3.Distance(unitTransform.position, _targetPosition) > stoppingDistance)
            {
                Vector3 position = unitTransform.position;
                Vector3 moveDirection = (_targetPosition - position).normalized;
                position += moveDirection * (moveSpeed * Time.deltaTime);
                unitTransform.position = position;

                transform.forward = Vector3.Lerp(transform.forward,moveDirection, Time.deltaTime * rotateSpeed);
                
                unityAnimator.SetBool("isWalking", true);
            }
            else
            {
                unityAnimator.SetBool("isWalking", false);
            }
        }
        public void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }
}
