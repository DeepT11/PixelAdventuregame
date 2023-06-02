using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int cherries=0;

    [SerializeField] private Text cherriesText;

    private void OnTriggerEnter2D(Collider2D collison)
    {

        if (collison.gameObject.CompareTag("Cherry"))
        {
            Destroy(collison.gameObject);
            cherries++;
            // Debug.Log("Cherries: " + cherries);
            cherriesText.text = "Cherries: " + cherries;
        }

    }
}
