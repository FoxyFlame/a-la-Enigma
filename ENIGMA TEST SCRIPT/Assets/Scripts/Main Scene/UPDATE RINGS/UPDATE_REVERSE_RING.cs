using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPDATE_REVERSE_RING : MonoBehaviour
{
    public int _childCount;
    Text _newText;
    public GameObject _myGameObject;
    RINGS _rings;

    void OnEnable()
    {
        _rings = _myGameObject.GetComponent<RINGS>();
        _childCount = transform.childCount;
        if (_rings.BebenOdwaracajacy != null)
        {
            GetNumberOn();
        }
    }

    public void GetNumberOn()
    {
        for (int i = 0; i < _childCount; i++)
        {
            _newText = transform.GetChild(i).GetComponentInChildren<Text>();
            _newText.text = _rings.GetRing_BebenOdwracajacy(i).ToString();
        }
    }
}
