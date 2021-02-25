using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILog : MonoBehaviour
{
    public Text txtLog;
    public GameObject panelLog;
    public bool showLog = true;
    
    void Start()
    {
        if(!showLog)
            panelLog.SetActive(false);
        
    }

    public void SetText(string s){
        txtLog.text = s;
    }

}
