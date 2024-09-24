using UnityEngine;
using UnityEngine.Events;

public class Distructable : MonoBehaviour
{
    [SerializeField] private int maxHitPoints;

    public UnityEvent Distructive;
    public UnityEvent ChangeHitPoints;
    private int hitPoints;

    private void Start()
    {
        hitPoints = maxHitPoints;

        ChangeHitPoints.Invoke();
    }
    public void ApplyDamage(int damage)
    { 
        hitPoints -= damage;

        ChangeHitPoints.Invoke();

        if (hitPoints <= 0)
        {
            Kill();
            Debug.Log("Kill");
        }
    }
    public void AddHitPoint(int hill)
    {
        hitPoints += hill;

        ChangeHitPoints.Invoke();

        if (hitPoints >= maxHitPoints)
        {
            hitPoints = maxHitPoints;
        }     
    }

    public void Kill()
    {
        hitPoints = 0;

        ChangeHitPoints.Invoke();
        Distructive.Invoke();
    }
    public int GetHitPoints()
    {
        return hitPoints;
    }
    public int GetMaxHitPoints()
    {
        return maxHitPoints;
    }
}
