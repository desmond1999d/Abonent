using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectText : MonoBehaviour {

    [TextArea]
    public string m_Description;


    public string GetDescription()
    {
        return m_Description;
    }
    
}
