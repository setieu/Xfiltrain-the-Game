using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class BopsHP : MonoBehaviour
{
    public Image healthBar;
    public float bosHP = 70f;
    public TextMeshProUGUI health;
    public float HP;
    private Bossman bossMan;
    private GameManager gameManager;
    private GameObject bossObject;
    // Start is called before the first frame update
    void Start()
    {
        
        healthBar = GameObject.Find("BossHealthBar").GetComponent<Image>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        healthBar.fillAmount = bosHP / HP;
        health.text = "Boss HP: " + bosHP;

        //if (gameManager.timePassed > 3.41f && gameManager.modeeE == 5)
        {
            bossObject = GameObject.Find("Ridehogger(Clone)");
            if (bossObject != null)
            {
                bossMan = GameObject.Find("Ridehogger(Clone)").GetComponent<Bossman>();
                HP = bossMan.health;
                bosHP = bossMan.bosShp;
            }
        }
        
    }
}
//Sean is cool.   