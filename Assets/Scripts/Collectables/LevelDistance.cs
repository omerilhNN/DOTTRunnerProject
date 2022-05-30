using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
   [SerializeField] public GameObject distDisplay;
   [SerializeField] public int distRun;
    public float distDelay= 0.35f;
    public bool addingDist=false;
   

    
    void Update()
    {
        if(addingDist==false)
        {
            addingDist = true;
            StartCoroutine(AddingDist());

        }
    }
    IEnumerator AddingDist()
    {
        distRun += 3;
        distDisplay.GetComponent<Text>().text = "" + distRun;
        yield return new WaitForSeconds(distDelay);
        addingDist = false;
    }
}
