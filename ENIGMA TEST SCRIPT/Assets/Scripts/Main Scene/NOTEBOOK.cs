using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NOTEBOOK : MonoBehaviour
{
    public TextMeshPro _textMesh;
    public TextMeshPro _textMesh_2;

    MAIN _main;

    public int _currentpage = 1;
    void Start()
    {
        ClearPage();
        _main = GameObject.Find("BUTTONS").GetComponent<MAIN>();
    }

    private void Update()
    {
        if (!PAUSE_MENU._gameIsPaused && Input.GetKeyDown(KeyCode.Return))  //Return -> ENTER
        {
            if (!MAIN.Deszyfracja)
            {
                CodingTime();
            }
            else
            {
                UncodingTime();
            }
        }

        if (!PAUSE_MENU._gameIsPaused && Input.GetKeyUp(KeyCode.Return))
        {
            LastPage();
        }

        if (!PAUSE_MENU._gameIsPaused && Input.GetKeyDown(KeyCode.Backspace))
        {
            if (!MAIN.Deszyfracja)
            {
                _textMesh.text = _textMesh.text.Substring(0, _textMesh.text.Length - 1);
                _textMesh_2.text = _textMesh_2.text.Substring(0, _textMesh_2.text.Length - 1);
            }
            else
            {
                _main.UsuwanieOstatniejLitery();
            }
        }
    }

    public void ClearPage()
    {
        _textMesh.text = "ENIGMA CODE TIME: \n\nNOWY SZYFROWANY TEKST: \n ";
        _textMesh_2.text = "\n\nNOWY ZASZYFROWANY TEKST: \n ";
        MAIN._tempText = _textMesh.text;
        MAIN._tempText_2 = _textMesh_2.text;
        _textMesh.pageToDisplay = 1;
        _textMesh_2.pageToDisplay = 1;
        _currentpage = 1;
    }

    public void ClearVaribles()
    {
        MAIN._tempText = "";
        MAIN._tempText_2 = "";
        _main._writedText.Clear();
        _main._writedText_2.Clear();
    }

    public void CodingTime()
    {
        _textMesh.text = _textMesh.text + "\nSZYFROWANY TEKST: \n ";
        _textMesh_2.text = _textMesh_2.text + "\nZASZYFROWANY TEKST: \n ";
    }

    public void UncodingTime()
    {
        _textMesh.text = _textMesh.text + "\nODSZYFROWYWANY TEKST: \n ";
        _textMesh_2.text = _textMesh_2.text + "\nODSZYFROWANY TEKST: \n ";
        MAIN._tempText = _textMesh.text;
        MAIN._tempText_2 = _textMesh_2.text;
    }

    public void ButtonNextPage()
    {
        int totalpages = _textMesh.textInfo.pageCount;       

        if (_currentpage < totalpages)
        {
            _currentpage++;
            _textMesh.pageToDisplay++;
            _textMesh_2.pageToDisplay++;
        }
    }

    public void ButtonPreviousPage()
    {
        int totalpages = _textMesh.textInfo.pageCount;

        if (_currentpage > 1)
        {
            _currentpage--;
            _textMesh.pageToDisplay--;
            _textMesh_2.pageToDisplay--;
        }
    }

    public void LastPage()
    {
        int totalpages = _textMesh.textInfo.pageCount;

        if (_currentpage < totalpages)
        {
            _currentpage = totalpages;
            _textMesh.pageToDisplay = _currentpage;
            _textMesh_2.pageToDisplay = _currentpage;
        }
    }
}
