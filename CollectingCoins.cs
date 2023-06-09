using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    public Scoring score;
    // Start is called before the first frame update
 
    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
        {
            Debug.Log("Coin collected");
            score.AddScore(1);
            // Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }
    }
 
    // Update is called once per frame

}
