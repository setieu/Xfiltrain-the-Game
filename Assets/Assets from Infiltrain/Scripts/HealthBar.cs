using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float MaxHP = 500f;

    public float HP = 100f;

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        healthBar = GetComponent < Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = HP / MaxHP;
    }
}
