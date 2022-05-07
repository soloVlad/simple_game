using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager != null && gameManager.isGameActive)
        {
            int targetWorth = other.gameObject.GetComponent<Target>().worth;
            gameManager.UpdateScore(targetWorth);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
