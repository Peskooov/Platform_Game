using SimpleFPS;
using UnityEngine;

public class Pikup : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if(fps != null)
        {
            Destroy(gameObject);
        }
    }
}
