using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class BopsHP : MonoBehaviour
{
    private Image healthBar;
    public float bosHP = 10f;
    public TextMeshProUGUI health;
    public float HP = 10f;
    private Bossman bossMan;
    private GameManager gameManager;
    private GameObject bossObject;
    // Start is called before the first frame update
    void Start()
    {
        
        healthBar = GetComponent<Image>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        healthBar.fillAmount = HP / bosHP;
        health.text = "Train Health: " + HP + "/" + bosHP;

        //if (gameManager.timePassed > 3.41f && gameManager.modeeE == 5)
        {
            bossObject = GameObject.Find("Ridehogger(Clone)");
            if (bossObject != null)
            {
                bossMan = GameObject.Find("Ridehogger(Clone)").GetComponent<Bossman>();
            }
        }
        //bosHP = Bossman.bosShp;
    }
}