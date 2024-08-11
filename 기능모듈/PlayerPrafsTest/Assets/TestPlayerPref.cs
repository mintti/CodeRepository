using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestPlayerPref : MonoBehaviour
{
    private const string c_strKey  = "strTypeKeyName";
    private const string c_intKey  = "intTypeKeyName";
    private const string c_floatKey = "floatTypeKeyName";

    [SerializeField] private TMP_InputField _strTMP;
    [SerializeField] private TMP_InputField _intTMP;
    [SerializeField] private TMP_InputField _floatTMP;
    
    public void Awake()
    {
        try
        {
            CMD_GetPrefData();
        }
        catch (Exception e)
        {
            Debug.Log($"오류! {e.ToString()}");
        }
    }

    public void CMD_SetPrefData()
    {
        PlayerPrefs.SetString(c_strKey, _strTMP.text);
        PlayerPrefs.SetInt(c_intKey, Int32.Parse(_intTMP.text));
        PlayerPrefs.SetFloat(c_floatKey, float.Parse(_floatTMP.text));
        
        PlayerPrefs.Save();
    }
    
    public void CMD_GetPrefData()
    {
        _strTMP.text = PlayerPrefs.GetString(c_strKey);
        _intTMP.text = PlayerPrefs.GetInt(c_intKey).ToString();
        _floatTMP.text = PlayerPrefs.GetFloat(c_floatKey).ToString();
    }
}
