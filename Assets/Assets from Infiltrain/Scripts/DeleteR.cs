using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteR : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject tanks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.modeeE == 6)
        {
            Destroy(tanks);
        }
    }
}
