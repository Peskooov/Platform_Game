using SimpleFPS;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Teleporter target;
    [SerializeField] private AudioSource audioTeleport;

    [HideInInspector] public bool isRecive;

    private void OnTriggerEnter(Collider other)
    {
        if (isRecive == true) return;

        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            target.isRecive = true;

            fps.transform.position = target.transform.position;

            audioTeleport.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            isRecive = false;
        }
    }
}
