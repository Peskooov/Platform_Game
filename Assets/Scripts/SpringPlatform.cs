using SimpleFPS;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    [SerializeField] private int jumpForce;
    [SerializeField] private AudioSource audioSpring; 

    private float previousJumpForce;

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            previousJumpForce = fps.m_JumpSpeed;

            fps.m_JumpSpeed += jumpForce;
            fps.m_Jump = true;

            audioSpring.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        FirstPersonController fps = other.GetComponent<FirstPersonController>();

        if (fps != null)
        {
            fps.m_JumpSpeed -= previousJumpForce;   
        }
    }
}
