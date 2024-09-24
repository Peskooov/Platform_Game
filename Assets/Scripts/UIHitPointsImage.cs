using UnityEngine.UI;
using UnityEngine;

public class UIHitPointsImage : MonoBehaviour
{
    [SerializeField] private Distructable distructable;
    [SerializeField] private Image image;

    private void Start()
    {
        distructable.ChangeHitPoints.AddListener(OnChangeHitPoints);
    }
    private void OnDestroy()
    {
        distructable.ChangeHitPoints.RemoveListener(OnChangeHitPoints);
    }
    private void OnChangeHitPoints()
    {
        image.fillAmount = (float)distructable.GetHitPoints() / (float)distructable.GetMaxHitPoints();
    }
}
