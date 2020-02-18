using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.ArtificialBased;

public class valve : MonoBehaviour
{
    public VRTK_ArtificialRotator rotator;
    float rot_value;
    public byte result = 0;
    byte check_Valve()
    {
        rot_value = rotator.GetValue();
        if (Math.Abs(rot_value) >= 360.0f) result = 1;
        else result = 0;
        Debug.Log(result);
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        rotator = GetComponentInParent<VRTK_ArtificialRotator>();
        rot_value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        check_Valve();
    }
}
