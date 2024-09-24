using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Distructable distructable = other.GetComponent<Distructable>();

        if (distructable != null)
        {
            distructable.Kill();
        }
    }
}
