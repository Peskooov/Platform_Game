using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 speed;
    
    private void Update()
    {
        transform.Rotate(speed * Time.deltaTime);        
    }
}
