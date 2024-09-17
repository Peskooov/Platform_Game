using UnityEngine;
using UnityEngine.Events;

public class PlayerInputController : MonoBehaviour
{
    public event UnityAction IdleEvent;
    public event UnityAction WalkEvent;
    public event UnityAction RunEvent;
    public event UnityAction JumpEvent;

    [SerializeField] private Movment player;

    private float moveHorizontal;
    private float moveVertical;

    public float MoveHorizontal => moveHorizontal;
    public float MoveVertical => moveVertical;

    private void Update()
    {
        player.transform.up = Vector3.up;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (!player.IsGround)
        {
            JumpEvent?.Invoke();
        }
        else
        {
            if (moveVertical == 0)
            {
                player.Rotate();
                IdleEvent?.Invoke();
            }

            if (!Input.GetKey(KeyCode.LeftShift) && moveVertical != 0)
            {
                player.Walk();
                player.Rotate();
                WalkEvent?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.Jump();
            }

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                player.Run();
                player.Rotate();
                RunEvent?.Invoke();
            }
        }
    }
}