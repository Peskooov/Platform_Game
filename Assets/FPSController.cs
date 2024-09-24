using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    private Rigidbody rb;

    private float inputX;
    private float inputY;
    private float inputZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Jump");
        inputZ = Input.GetAxis("Vertical");

        Vector3 move = rb.velocity;

       // transform.Translate(inputX, inputY, inputZ);
        rb.velocity =  new Vector3(inputX, inputY, inputZ) * speed * Time.deltaTime;
    }

    public void ChangePosinion(Transform transform, float speed, bool state)
    {
        if (state)
        {
           this.transform.Translate(transform.transform.forward * speed * Time.deltaTime);
        }
    }
}