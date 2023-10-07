using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCollect : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("YellowOrb"))
        {
            gameManager.CollectYellowOrb();
            Destroy(other.gameObject);
        }
    }
}

