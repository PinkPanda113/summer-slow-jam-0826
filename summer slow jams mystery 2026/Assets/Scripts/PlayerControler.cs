using UnityEngine;

namespace Wizard
{   
    public class PlayerControler : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;


        private Vector2 _moveDirection;
        private bool _isJumping;
        private void Start()
        {
            inputReader.MoveEvent += HandleMove;
            inputReader.JumpEvent += HandleJump;
            inputReader.JumpCanceledEvent += HandleJumpCanceled;
        }

        private void Update()
        {
            Move();
            Jump();
            
        }
        private void HandleMove(Vector2 dir)
        {
           _moveDirection = dir;
        }

        private void HandleJump()
        {
            _isJumping = true;
        }

        private void HandleJumpCanceled()
        {
            _isJumping = false;
        } 

        private void Move()
        {
            if (_moveDirection == Vector2.zero)
            {
                return;
            }
            transform.position += new Vector3(_moveDirection.x, 0, _moveDirection.y) * moveSpeed * Time.deltaTime;
        }

        private void Jump()
        {
            if (_isJumping)
            {
                transform.position += Vector3.up * jumpForce * Time.deltaTime;
            }
        }
    }
}