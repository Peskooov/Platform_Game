using System;
using UnityEngine;

public class DamageDelay : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageDelay;
    [SerializeField] private float resetDelay;
    [SerializeField] private GameObject button;
    [SerializeField] private Material materialActivate;
    [SerializeField] private Material materialDamage;
    [SerializeField] private Material materialBase;
    [SerializeField] private Vector3 buttonPosition;

    private Distructable distructable;
    private Renderer render;
    private bool isActivated;

    private void Start()
    {
        isActivated = false;
        render = button.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (distructable != null && !isActivated)
        {
            ActivateTrap();
        }
    }

    private void ActivateTrap()
    {
        isActivated = true;
        render.material = materialActivate;
        Invoke(nameof(DealDamage), damageDelay);
        button.transform.position -= buttonPosition ; 
    }

    private void DealDamage()
    {
        render.material = materialDamage;
        if (distructable != null)
        {
            Invoke(nameof(BaseMaterial), damageDelay);
            distructable.ApplyDamage(damage);
            Invoke(nameof(ResetTrap), resetDelay);
        }
    }

    private void BaseMaterial()
    {
        render.material = materialBase;
    }

    private void ResetTrap()
    {
        isActivated = false;
        
        button.transform.position += buttonPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        distructable = other.GetComponent<Distructable>();
    }
}