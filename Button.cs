using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(getdown());
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(getup());
    }

    IEnumerator getdown()
    {
        for(int i = 0; i < 10; i++)
        {
            transform.Translate(Vector3.down * Time.deltaTime/50);
            yield return new WaitForSeconds(0.01f);
        }  
    }

    IEnumerator getup()
    {
        
        while(true)
        {
            transform.Translate(Vector3.up * Time.deltaTime/10);
            yield return new WaitForSeconds(0.01f);
            if (this.gameObject.transform.position.y >= 0.0f)
                break;
        }
    }
}
