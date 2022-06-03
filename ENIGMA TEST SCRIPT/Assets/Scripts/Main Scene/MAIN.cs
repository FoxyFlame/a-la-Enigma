using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MAIN : MonoBehaviour
{

    public List<KeyCode> KlawiszePodst  = new List<KeyCode> (new KeyCode[] { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, 
                                                                             KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, 
                                                                             KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z, KeyCode.Space });

    bool Nacisk = false; 
    public static bool Deszyfracja = false;

    public int przechowanie_i_keydown, ChildCount, active_light_button;

    Vector3 poprzednia_pozycja;

    public GameObject Lights;
    GameObject Player, SzyfrDeszyfr;
    RINGS Rings;
    NOTEBOOK _notebook;
    public static string _tempText, _tempText_2;
    public List<string> _writedText = new List<string>();
    public List<string> _writedText_2 = new List<string>();
    
    private void Start()
    {
        SzyfrDeszyfr = GameObject.Find("SWITCH_SYFRATION_TYPE");
        ChildCount = transform.childCount;
        active_light_button = 0;
        Rings = GameObject.Find("RINGS_OBJ").GetComponent<RINGS>();
        _notebook = GameObject.Find("TEXT_ON_PAGE").GetComponent<NOTEBOOK>();
    }


    void Update()
    {
        if (!PAUSE_MENU._gameIsPaused)
        {
            //Debug.Log(ChildCount + "  " + KlawiszePodst.Count);
            for (int i = 0; i < ChildCount; i++)
            {
                WykrycieNacisku(i);               
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                _writedText.Clear();
            }
        }   
    }

    void WykrycieNacisku(int i)
    {
        if (!Nacisk)
        {
            if (Input.GetKeyDown(KlawiszePodst[i]))
            {
                Nacisk = true;
                przechowanie_i_keydown = i;
                poprzednia_pozycja = transform.GetChild(i).position;
                transform.GetChild(i).position -= new Vector3(0f, 10f * Time.deltaTime, 0f);
                
                if (!Deszyfracja)
                {
//SZYFROWANIE

                    active_light_button = Rings.PierścienTrzeci[Rings.PierścienDrugi[
                                          Rings.PierścienPierwszy[Rings.BebenOdwaracajacy[
                                          Rings.PierścienPierwszy[Rings.PierścienDrugi[
                                          Rings.PierścienTrzeci[przechowanie_i_keydown]]]]]]];

                    _notebook._textMesh_2.text += SwitchIfItsSpecialCharacter_Normal(active_light_button);
                    _notebook._textMesh.text += SwitchIfItsSpecialCharacter_Normal(i);

                    ZapalenieLampki(active_light_button);
                    Rings.Przesuniecie();
                }
                else
                {
//DESZYFROWANIE                   
                    for (int j = 0; j < ChildCount; j++)
                    {
                        if (Rings.PierścienTrzeci[j] == i)
                            for (int k = 0; k < ChildCount; k++)
                            {
                                if (Rings.PierścienDrugi[k] == j)
                                    for (int z = 0; z < ChildCount; z++)
                                    {
                                        if (Rings.PierścienPierwszy[z] == k)
                                            for (int x = 0; x < ChildCount; x++)
                                            {
                                                if (Rings.BebenOdwaracajacy[x] == z)
                                                    for (int c = 0; c < ChildCount; c++)
                                                    {
                                                        if (Rings.PierścienPierwszy[c] == x)
                                                            for (int v = 0; v < ChildCount; v++)
                                                            {
                                                                if (Rings.PierścienDrugi[v] == c)
                                                                    for (int b = 0; b < ChildCount; b++)
                                                                    {
                                                                        if (Rings.PierścienTrzeci[b] == v)
                                                                            active_light_button = b;
                                                                    }
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
                    //_notebook._textMesh_2.text = KlawiszePodst[active_light_button].ToString() + _notebook._textMesh_2.text;
                    //_notebook._textMesh.text = KlawiszePodst[i].ToString() + _notebook._textMesh.text;
                    //_notebook._textMesh.text += " ";

                    //_notebook._textMesh_2.text += SwitchIfItsSpecialCharacter_Normal(active_light_button);
                    //_notebook._textMesh.text += SwitchIfItsSpecialCharacter_Normal(i);
                    
                    Rings.Przesuniecie();

                    _writedText.Add(SwitchIfItsSpecialCharacter_Normal(i));
                    _writedText_2.Add(SwitchIfItsSpecialCharacter_Normal(active_light_button));

                    WpisywanyTekst();

                    ZapalenieLampki(active_light_button);

                    //Rings.Cofniecie(i);
                }

                if(_notebook._currentpage < _notebook._textMesh.textInfo.pageCount)
                {
                    _notebook.LastPage();
                }

            }
        }

        if (Input.GetKeyUp(KlawiszePodst[przechowanie_i_keydown]))
        {
            transform.GetChild(przechowanie_i_keydown).position = poprzednia_pozycja;
            Nacisk = false;
            GaszenieLampki(active_light_button);
        }
    }

    public void WpisywanyTekst()
    {
        _notebook._textMesh.text = _tempText;
        _notebook._textMesh_2.text = _tempText_2;
        for (int rev = 0; rev < _writedText.Count; rev++)
        {
            _notebook._textMesh.text += _writedText[rev].ToString();
            _notebook._textMesh_2.text += _writedText_2[rev].ToString();
        }
    }

    public void UsuwanieOstatniejLitery()
    {
        if(_writedText.Count <= 1)
        {
            _writedText.Clear();
            _writedText_2.Clear();
        }
        else
        {
            _writedText.RemoveAt(_writedText.Count - 1);
            _writedText_2.RemoveAt(_writedText_2.Count - 1);
        }
        WpisywanyTekst();
    }

    public void ZmianaDefSzyf()
    {   
        if (Deszyfracja)
        {
            Deszyfracja = false;
            SzyfrDeszyfr.transform.Rotate(0, -90, 0, Space.Self);
            //Rings.Przesuniecie(przechowanie_i_keydown);
            Debug.Log("Aktywowano zmine szyfracji - szyfrowanie :" + !Deszyfracja);
            _notebook.CodingTime();
        }
        else
        {
            Deszyfracja = true;
            SzyfrDeszyfr.transform.Rotate(0, 90, 0, Space.World);
            //Rings.Cofniecie(przechowanie_i_keydown);
            Debug.Log("Aktywowano zmine szyfracji - szyfrowanie :" + !Deszyfracja);
            _notebook.UncodingTime();
        }
    }

    void ZapalenieLampki(int i)
    {
        MeshRenderer test = Lights.transform.GetChild(i).GetComponent<MeshRenderer>();
        test.material = Resources.Load("LIGHTS_KB_ON", typeof(Material)) as Material;
    }

    void GaszenieLampki(int i)
    {
        MeshRenderer test = Lights.transform.GetChild(i).GetComponent<MeshRenderer>();
        test.material = Resources.Load("LIGHTS_KB_OFF", typeof(Material)) as Material;
    }

    public string SwitchIfItsSpecialCharacter_Normal(int active_button)
    {
        string _returnedCaracter = KlawiszePodst[active_button].ToString();

        if (KlawiszePodst[active_button].ToString() == "Alpha0") _returnedCaracter = "0";
        if (KlawiszePodst[active_button].ToString() == "Alpha1") _returnedCaracter = "1";
        if (KlawiszePodst[active_button].ToString() == "Alpha2") _returnedCaracter = "2";
        if (KlawiszePodst[active_button].ToString() == "Alpha3") _returnedCaracter = "3";
        if (KlawiszePodst[active_button].ToString() == "Alpha4") _returnedCaracter = "4";
        if (KlawiszePodst[active_button].ToString() == "Alpha5") _returnedCaracter = "5";
        if (KlawiszePodst[active_button].ToString() == "Alpha6") _returnedCaracter = "6";
        if (KlawiszePodst[active_button].ToString() == "Alpha7") _returnedCaracter = "7";
        if (KlawiszePodst[active_button].ToString() == "Alpha8") _returnedCaracter = "8";
        if (KlawiszePodst[active_button].ToString() == "Alpha9") _returnedCaracter = "9";
        if (KlawiszePodst[active_button].ToString() == "Space")  _returnedCaracter = "_";

        return _returnedCaracter;
    }
}
