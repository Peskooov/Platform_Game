using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] private PlayerInputController controller;

    [Header("Player")]
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody player;

    [Header("Raycast")]
    [SerializeField] private float rayLength;
    [SerializeField] private Vector3 rayOffset;
    [SerializeField] private Vector3 boxSize;

    private bool isGround;
    public bool IsGround => isGround;

    private void OnCollisionStay(Collision collision)
    {
        if (collision != null)
            isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }

    public void Rotate()
    {
        transform.Rotate(0, controller.MoveHorizontal * rotateSpeed * Time.deltaTime, 0);
    }

    public void Walk()
    {
        transform.Translate(Vector3.forward * controller.MoveVertical * walkSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        player.AddForce(transform.forward * controller.MoveVertical * jumpForce, ForceMode.Impulse);
        player.AddForce(transform.right * controller.MoveHorizontal * jumpForce, ForceMode.Impulse);
    }

    public void Run()
    {
        transform.Translate(Vector3.forward * controller.MoveVertical * runSpeed * Time.deltaTime);
    }
}
