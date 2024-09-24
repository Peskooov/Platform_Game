using UnityEngine;

public class MoveToDelay : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timer;
    [SerializeField] private Transform target;

    private void TransformPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void FixedUpdate()
    { 
        Invoke("TransformPosition", timer);
    }
}
