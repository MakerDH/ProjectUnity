using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringFormat : MonoBehaviour
{
    public Text text;

    public float aaa = 50;
    public float bbb = 100;
    public float ccc = 200;
    public float ddd = 500;
    public float fff = 1000;

    /// <summary>
    /// string format test
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Format("aaa {0} , bbb {1} , ccc {2} , ddd {3}\n fff : {4} ({5}%)\n",
            aaa, bbb, ccc, ddd, fff,
            ((aaa / (bbb + ccc)) * 100f).ToString("F1"));
    }

 
}
