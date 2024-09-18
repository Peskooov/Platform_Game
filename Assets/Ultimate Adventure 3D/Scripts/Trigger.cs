using SimpleFPS;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioTrigger;

    public UnityEvent Enter;
    public UnityEvent Exit;

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            Enter.Invoke();
            audioTrigger.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            Exit.Invoke();
        }
    }
}
