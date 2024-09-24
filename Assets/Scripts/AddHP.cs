using UnityEngine;

public class AddHP : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private int hill;

    private Distructable addHill;

    private void OnTriggerEnter(Collider other)
    {
        addHill = other.GetComponent<Distructable>();
        addHill.AddHitPoint(hill);
        Instantiate(impactEffect);
    }
}
