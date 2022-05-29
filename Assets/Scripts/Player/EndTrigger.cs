
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
   public GameManager gameManager;
     void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Player")
        {
            gameManager.CompleteDemo();
        }
    }
}
