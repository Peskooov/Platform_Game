using UnityEngine;
using UnityEngine.Events;

public class KeyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject messageBox;
    [SerializeField] private int amountKeyActive;

    [SerializeField] private UnityEvent Enter;

    private bool isActive = false;

    protected void OnTriggerEnter(Collider other)
    {
        if (isActive == true) return;

        Bag bag = FindObjectOfType<Bag>();

        if (bag != null)
        {
            if (bag.DrawKey(amountKeyActive) == true)
            {
                Enter.Invoke();
                isActive = true;
            }
            else
            {
                messageBox.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        messageBox.SetActive(false);
    }
}
