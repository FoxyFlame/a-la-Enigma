using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CLICKABLE_MENAGER : MonoBehaviour
{
    public float _rayLength;
    public LayerMask _layerMask;
    RaycastHit _hit;
    Ray _ray;
    RINGS _rings;
    MAIN _mainScript;
    PAUSE_MENU _pause_menu;
    NOTEBOOK _notebook;
    //UPDATE_1 _update_1;
    //UPDATE_2 _update_2;
    //UPDATE_3 _update_3;
    Vector3 _moveObjectOnClickBy = new Vector3(0f, 0.05f, 0f);

    private void Start()
    {
        _rings = GameObject.Find("RINGS_OBJ").GetComponent<RINGS>();
        _mainScript = GameObject.Find("BUTTONS").GetComponent<MAIN>();
        _pause_menu = GameObject.Find("Canvas").GetComponent<PAUSE_MENU>();
        _notebook = GameObject.Find("TEXT_ON_PAGE").GetComponent<NOTEBOOK>();
    }

    void Update()
    {
        if (!PAUSE_MENU._gameIsPaused)
        {
            if (Input.GetMouseButtonDown(0)) // && !EventSystem.current.IsPointerOverGameObject()
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, _layerMask))
                {
                    if (_hit.collider.name == "1_DOWN")
                    {                     
                        _rings.PrzesunieciePierscienPierwszy();
                        if (_rings.Ring1_Angle >= 360) _rings.Ring1_Angle = 0;
                    }
                    else
                    {
                        if (_hit.collider.name == "1_UP")
                        {
                            _rings.CofnieciePierscienPierwszy();
                        }
                    }

                    if (_hit.collider.name == "2_DOWN")
                    {     
                        _rings.PrzesunieciePierscienDrugi();
                        if (_rings.Ring2_Angle >= 360) _rings.Ring2_Angle = 0;
                    }
                    else
                    {
                        if (_hit.collider.name == "2_UP")
                        {
                            _rings.CofnieciePierscienDrugi();
                        }
                    }

                    if (_hit.collider.name == "3_DOWN")
                    {                    
                        _rings.PrzesunieciePierscienTrzeci();
                        if(_rings.Ring3_Angle >= 360) _rings.Ring3_Angle = 0;
                    }
                    else
                    {
                        if (_hit.collider.name == "3_UP")
                        {
                            _rings.CofnieciePierscienTrzeci();
                        }
                    }

                    if (_hit.collider.name == "SWITCH_SYFRATION_TYPE")
                    {
                        _notebook.ClearVaribles();
                        _mainScript.ZmianaDefSzyf();
                    }

                    if (_hit.collider.name == "RINGS_CONF")
                    {
                        _pause_menu.OpenConfUpdateRings();
                    }

                    if (_hit.collider.name == "RUBBER")
                    {
                        if (MAIN.Deszyfracja)
                        {
                            _mainScript.ZmianaDefSzyf();
                        }
                        _notebook.ClearVaribles();
                        _notebook.ClearPage();
                    }

                    if (_hit.collider.name == "PREVIOUS_PAGE_BUTTON")
                    {
                        _notebook.ButtonPreviousPage();
                    }

                    if (_hit.collider.name == "NEXT_PAGE_BUTTON")
                    {
                        _notebook.ButtonNextPage();
                    }

                    if (_hit.collider.name != "SWITCH_SYFRATION_TYPE")
                    {
                        _hit.transform.position -= _moveObjectOnClickBy;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, _layerMask))
                {
                    if (_hit.collider.name != "SWITCH_SYFRATION_TYPE")
                    {
                        _hit.transform.position += _moveObjectOnClickBy;
                    }
                }
            }
        }
    }
}
