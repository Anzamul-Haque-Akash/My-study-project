using Cinemachine;
using UnityEngine;

namespace StudyFromCodeMonkey.Study.Scripts
{
    public class CameraController : MonoBehaviour
    {
        private const float MIN_FOLLOW_Y_OFFSET = 2f;
        private const float MAX_FOLLOW_Y_OFFSET = 12f;
        
        [SerializeField] private CinemachineVirtualCamera mCinemachineVirtualCamera;

        private CinemachineTransposer _cinemachineTransposer;
        private Vector3 _targetFollowOffset;

        private float moveSpeed = 10f;
        private float rotationSpeed = 100f;
        private float zoomAmount = 1f;
        
        private void Start()
        {
            _cinemachineTransposer = mCinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            _targetFollowOffset = _cinemachineTransposer.m_FollowOffset;
        }

        private void Update()
        {
            MoveCamera();
            RotateCamera();
            ZoomInAndZoomOut();
        }

        private void MoveCamera()
        {
            Vector3 inputMoveDir = new Vector3(0f, 0f, 0f);
            
            if (Input.GetKey(KeyCode.W))
            {
                inputMoveDir.z = +1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputMoveDir.z = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputMoveDir.x = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputMoveDir.x = +1f;
            }
            
            Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
            
            transform.position += moveVector * moveSpeed * Time.deltaTime;
        }
        private void RotateCamera()
        {
            Vector3 rotationVector = new Vector3(0f, 0f, 0f);
            if (Input.GetKey(KeyCode.Q))
            {
                rotationVector.y = +1f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                rotationVector.y = -1f;
            }
            transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
        }
        private void ZoomInAndZoomOut()
        {
            
            if (Input.GetKey(KeyCode.Z))
            {
                _targetFollowOffset.y -= zoomAmount;
            }
            if (Input.GetKey(KeyCode.X))
            {
                _targetFollowOffset.y += zoomAmount;
            }

            _targetFollowOffset.y = Mathf.Clamp(_targetFollowOffset.y, MIN_FOLLOW_Y_OFFSET, MAX_FOLLOW_Y_OFFSET);

            float zoomSpeed = 5f;
            _cinemachineTransposer.m_FollowOffset = Vector3.Lerp(_cinemachineTransposer.m_FollowOffset,
                _targetFollowOffset, Time.deltaTime * zoomSpeed);
            
        }
    }
}