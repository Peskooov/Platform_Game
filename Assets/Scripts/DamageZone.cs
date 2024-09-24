using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageRate;
    [SerializeField] private AudioSource audioDamage;

    private Distructable distructable;
    private float timer;

    private void Update()
    {
        if (distructable == null) return;

        timer += Time.deltaTime;

        if (timer >= damageRate)
        {
            if (distructable != null)
            {
                distructable.ApplyDamage(damage);

                audioDamage.Play();
            }

            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        distructable = other.GetComponent<Distructable>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Distructable>() == distructable)
            distructable = null;
    }
}