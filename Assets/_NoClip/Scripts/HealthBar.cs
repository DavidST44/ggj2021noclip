using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public RectTransform healthBar;

    private void Update()
    {
        Vector3 scale = healthBar.localScale;
        scale.x = playerHealth.GetHealthNormalised();
        healthBar.localScale = scale;
    }

}
