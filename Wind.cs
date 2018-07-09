using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    public float windspeed = 5.0f;


    [SerializeField]
    private GameObject character;

    [SerializeField]
    private GameObject des;

    private Rigidbody rb;
    private bool winding = false;

    private Vector3 temp;

    private void Start()
    {
        rb = character.GetComponent<Rigidbody>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    character.GetComponent<Rigidbody>().useGravity = false;
    //}


    private void OnTriggerStay(Collider other)
    {
        if (other.tag =="Player")
        {
       
          //  Debug.Log("strcor");
            if (!winding)
            {

                winding = true;
                StartCoroutine(getback(other));

            }
 
        }
    }

    //temp = transform.rotation* Vector3.back;

    IEnumerator getback(Collider other)
    {
        while (winding)
        {
           Debug.Log("AddForce");
            // other.GetComponent<Rigidbody>().AddForce(transform.rotation * Vector3.back * windspeed);

            temp = new Vector3(des.transform.position.x - character.transform.position.x, des.transform.position.y - character.transform.position.y, des.transform.position.z - character.transform.position.z);
 

            // other.transform.Translate(temp.normalized * windspeed);

            //other.transform.position.Set(other.transform.position.x - temp.normalized.x *10, other.transform.position.y - temp.normalized.y * 10, other.transform.position.z - temp.normalized.z * 10);

            other.transform.position += temp.normalized * windspeed;


            // other.transform.Translate((c.transform.rotation * Vector3.back * windspeed));
            //yield return null;
            //yield return new WaitForSeconds(0.03f);
            //yield return new WaitForEndOfFrame();

            yield return new WaitForSeconds(0.011f);


        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("strcor");
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().isKinematic = false;
            winding = false;
            //character.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
