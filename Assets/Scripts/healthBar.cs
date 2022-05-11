using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradiens;
    public Image fill;

    public void SetMaxHealth(float maxHP)
    {
        slider.maxValue = maxHP;
        slider.value = maxHP;

        fill.color = gradiens.Evaluate(1f);
    }

    public void SetHealth(float HP)
    {
        slider.value = HP;

        fill.color = gradiens.Evaluate(slider.normalizedValue);
    }
}
