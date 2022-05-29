using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    
    
    private void OnTriggerEnter(Collider other)
    {
        
        GameManager.instance.coinFX.Play();
        CollectableControl.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
