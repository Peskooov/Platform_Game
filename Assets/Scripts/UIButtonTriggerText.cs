using UnityEngine;

public class UIButtonTriggerText : MonoBehaviour
{
    [SerializeField] private GameObject messageBox;

    private void OnTriggerEnter(Collider other)
    {
        messageBox.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        messageBox.SetActive(false);
    }
}
