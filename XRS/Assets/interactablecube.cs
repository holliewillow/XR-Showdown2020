using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;



public class interactablecube : MonoBehaviour
{
    public VRTK.VRTK_InteractableObject obj;
    public Material m1;
    public Material m2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (obj.IsGrabbed())
        {
            gameObject.GetComponent<Renderer>().material = m2;
            Debug.Log("You grabbed me!");
        }
        else if (!obj.IsGrabbed())
        {
            gameObject.GetComponent<Renderer>().material = m1;
        }
    }
}
