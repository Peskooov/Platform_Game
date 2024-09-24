using UnityEngine;

public class Wing : MonoBehaviour
{
    public Transform transform;
    public Rigidbody rb;
    public float windForce = 10f;

    private Vector3 windDirection;

    private float windDirectionChangeTimer = 0f;

    void Start()
    {
        windDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        if (rb != null)
            rb.AddForce(rb.transform.forward * windForce * Time.deltaTime, ForceMode.Acceleration);

        windDirectionChangeTimer += Time.deltaTime;
        if (windDirectionChangeTimer >= 2f)
        {
            windDirectionChangeTimer = 0f;
            windDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        }
    }

    void OnTriggerStay(Collider other)
    {
        rb = other.gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        rb = null;
    }
}