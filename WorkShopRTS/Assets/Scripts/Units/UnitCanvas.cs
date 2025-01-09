using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UnitCanvas : MonoBehaviour
{
    private Quaternion _baseRotation;
    public Image hydratationJauge;
    public Image lifeJauge;

    private void Start()
    {
        _baseRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = _baseRotation;
    }

    public void UpdateLifeJauge(int life, int maxLife)
    {
        lifeJauge.fillAmount = (float)life/(float)maxLife;
    }
    
    public void UpdateHydratationJauge(int hydratation, int maxHydratation)
    {
        hydratationJauge.fillAmount = (float)hydratation/(float)maxHydratation;
    }
}
