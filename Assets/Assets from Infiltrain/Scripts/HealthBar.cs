using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float MaxHP = 10f;
    public TextMeshProUGUI health;
    public float HP = 10f;

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
        health.text = "Train Health: " + HP + "/" +MaxHP;
    }
}
