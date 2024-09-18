using UnityEngine;

public class RotateTo : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 targetRotate;

    void Update()
    {
        targetTransform.localRotation = Quaternion.RotateTowards(targetTransform.localRotation, Quaternion.Euler(targetRotate), speed * Time.deltaTime);
    }
}
