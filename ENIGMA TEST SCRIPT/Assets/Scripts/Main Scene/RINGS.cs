using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RINGS : MonoBehaviour
{
    public GameObject Update_1, Update_2, Update_3, Update_ReverseRing;

    public int childCount_1, childCount_2, childCount_3, childCount_ReverseRing;

    public List<int> PierścienPierwszy = new List<int>(new int[] { 16, 12,  6,  4, 10, 18,  0,  8, 34, 17, 23,  3, 13, 27, 1,
                                                                   29, 22,  9, 33, 28, 24,  2, 14, 35, 21, 15, 31,  7, 19, 36,
                                                                   20, 32,  5, 25, 11, 30, 26}); // 15 X 15 X 7 = 37
    

    public List<int> PierścienDrugi = new List<int>(new int[]    { 20,  8, 23, 27, 28, 32, 36, 14,  2,  5, 31, 35,  4, 18, 26,
                                                                   10, 24, 25,  1, 19, 13, 21, 30,  0, 34,  7, 12,  6, 11, 17,
                                                                    3, 29, 15, 33,  9, 22, 16}); // 15 X 15 X 7 = 37
    

    public List<int> PierścienTrzeci = new List<int>(new int[]   { 25,  6, 31, 30,  2, 11, 24,  0, 14, 15, 22, 10, 26, 16,  5,
                                                                    9, 28,  3,  7, 12, 35, 20, 17, 29, 13, 27, 19, 34,  4, 36,
                                                                   21,  8,  1, 32, 18, 23, 33}); // 15 X 15 X 7 = 37

    public List<int> BebenOdwaracajacy = new List<int>(new int[] { 15,  7, 24, 13,  4, 31, 11, 16, 35,  2, 21,  5, 34, 23, 19,
                                                                    1, 10, 32, 18, 25,  3,  0, 28, 33, 17, 20, 12, 36, 26, 27,
                                                                    6,  9,  8, 30, 22, 29, 14}); // 15 X 15 X 7 = 37

    public int GetRing_1(int i)
    {
        return PierścienPierwszy[i];
    }

    public int GetRing_2(int i)
    {
        return PierścienDrugi[i];
    }

    public int GetRing_3(int i)
    {
        return PierścienTrzeci[i];
    }

    public int GetRing_BebenOdwracajacy(int i)
    {
        return BebenOdwaracajacy[i];
    }

    public float Angle = 0,Ring1_Angle = 0, Ring2_Angle = 0, Ring3_Angle = 0;

    public GameObject Ring_1, Ring_2, Ring_3;
    MAIN Main;

    public void Start()
    {
        Angle = 360f / 37f;  // PODMIENIANE RECZNIE PEŁEN OBROT PRZEZ ILOSC ZNAKOW
        Main = GameObject.Find("BUTTONS").GetComponent<MAIN>();
        childCount_1 = Update_1.transform.childCount;
        childCount_2 = Update_2.transform.childCount;
        childCount_3 = Update_3.transform.childCount;
        childCount_ReverseRing = Update_ReverseRing.transform.childCount;
    }

    public void CofnieciePierscienPierwszy()
    {
        int temp = PierścienPierwszy[36];     // PODMIENIANA RECZNA ILOSC ZNAKOW - 1
        PierścienPierwszy.RemoveAt(36);      // PODMIENIANA RECZNA ILOSC ZNAKOW - 1
        PierścienPierwszy.Insert(0, temp);
        Ring1_Angle -= Angle;
        if(Ring1_Angle <= -1)
        {
            Ring1_Angle = 360 - Angle;
        }
        //Debug.Log(Ring1_Angle);
        Ring_1.transform.localRotation = Quaternion.Euler(0, -90, Ring1_Angle);
        //Ring_1.transform.Rotate(-Angle, 0.0f, 0.0f, Space.Self);
    }
    public void CofnieciePierscienDrugi()
    {
        int temp = PierścienDrugi[36];    // PODMIENIANA RECZNA ILOSC ZNAKOW - 1
        PierścienDrugi.RemoveAt(36);     // PODMIENIANA RECZNA ILOSC ZNAKOW - 1
        PierścienDrugi.Insert(0, temp);
        Ring2_Angle -= Angle;
        if (Ring2_Angle <= -1)
        {
            Ring2_Angle = 360 - Angle;
        }
        Ring_2.transform.localRotation = Quaternion.Euler(0, -90, Ring2_Angle);
        //Ring_2.transform.Rotate(-Angle, 0.0f, 0.0f, Space.Self);
    }
    public void CofnieciePierscienTrzeci()
    {
        int temp = PierścienTrzeci[36];    // PODMIENIANA RECZNA ILOSC ZNAKOW - 1
        PierścienTrzeci.RemoveAt(36);     // PODMIENIANA RECZNA ILOSC ZNAKOW - 1
        PierścienTrzeci.Insert(0, temp);
        Ring3_Angle -= Angle;
        if (Ring3_Angle <= -1)
        {
            Ring3_Angle = 360 - Angle;
        }
        Ring_3.transform.localRotation = Quaternion.Euler(0, -90, Ring3_Angle);
        //Ring_3.transform.Rotate(-Angle, 0.0f, 0.0f, Space.Self);
    }
    public void PrzesunieciePierscienPierwszy()
    {
        int temp = PierścienPierwszy[0];
        PierścienPierwszy.RemoveAt(0);
        PierścienPierwszy.Add(temp);
        Ring1_Angle += Angle;
        Ring_1.transform.localRotation = Quaternion.Euler(0, -90, Ring1_Angle);
        //Ring_1.transform.Rotate(Angle, 0.0f, 0.0f, Space.World);
        //Debug.Log(Ring1_Angle);
    }
    public void PrzesunieciePierscienDrugi()
    {
        int temp = PierścienDrugi[0];
        PierścienDrugi.RemoveAt(0);
        PierścienDrugi.Add(temp);
        Ring2_Angle += Angle;
        Ring_2.transform.localRotation = Quaternion.Euler(0, -90, Ring2_Angle);
        //Ring_2.transform.Rotate(Angle, 0.0f, 0.0f, Space.Self);
    }
    public void PrzesunieciePierscienTrzeci()
    {
        int temp = PierścienTrzeci[0];
        PierścienTrzeci.RemoveAt(0);
        PierścienTrzeci.Add(temp);
        Ring3_Angle += Angle;
        Ring_3.transform.localRotation = Quaternion.Euler(0, -90, Ring3_Angle);
        //Ring_3.transform.Rotate(Angle, 0.0f, 0.0f, Space.Self);
    }

    /*public void Cofniecie() //int i
    {
        //Debug.Log(Ring1_Angle);
        //Debug.Log(Ring2_Angle);
        //Debug.Log(Ring2_Angle);

        if (Ring1_Angle <= 1)
        {
            if (Ring2_Angle <= 1)
            {
                if (Ring3_Angle <= 1)
                {
                    //labelPierscien1.Text = (ScrollBarPierscien1.Value = 37).ToString();
                    //labelPierscien2.Text = (ScrollBarPierscien2.Value = 37).ToString();
                    //labelPierscien3.Text = (ScrollBarPierscien3.Value = 37).ToString();
                    //Ring_1.transform.localRotation = Quaternion.Euler(360 - Angle, 0, 0);
                    //Ring_2.transform.localRotation = Quaternion.Euler(360 - Angle, 0, 0);
                    //Ring_3.transform.localRotation = Quaternion.Euler(360 - Angle, 0, 0);

                    Ring1_Angle = 360;
                    Ring2_Angle = 360;
                    Ring3_Angle = 360;

                    CofnieciePierscienPierwszy();
                    CofnieciePierscienDrugi();
                    CofnieciePierscienTrzeci();

                    
                }
                else
                {
                    //labelPierscien1.Text = (ScrollBarPierscien1.Value = 37).ToString();
                    //labelPierscien2.Text = (ScrollBarPierscien2.Value = 37).ToString();
                    //labelPierscien3.Text = (ScrollBarPierscien3.Value -= 1).ToString();
                    //Ring_1.transform.localRotation = Quaternion.Euler(360 - Angle, 0, 0);
                    //Ring_2.transform.localRotation = Quaternion.Euler(360 - Angle, 0, 0);
                    //Ring_3.transform.Rotate(-Angle, 0.0f, 0.0f, Space.Self);

                    Ring1_Angle = 360;
                    Ring2_Angle = 360;

                    CofnieciePierscienPierwszy();
                    CofnieciePierscienDrugi();
                    CofnieciePierscienTrzeci();

                    
                }
            }
            else
            {
                //labelPierscien1.Text = (ScrollBarPierscien1.Value = 37).ToString();
                //labelPierscien2.Text = (ScrollBarPierscien2.Value -= 1).ToString();
                //Ring_1.transform.localRotation = Quaternion.Euler(360 - Angle, 0, 0);
                //Ring_2.transform.Rotate(-Angle, 0.0f, 0.0f, Space.Self);
                Ring1_Angle = 360;

                CofnieciePierscienPierwszy();
                CofnieciePierscienDrugi();

            }
        }
        else
        {
            //labelPierscien1.Text = (ScrollBarPierscien1.Value -= 1).ToString();
            //Ring_1.transform.Rotate(-Angle, 0.0f, 0.0f, Space.Self);

            CofnieciePierscienPierwszy();
        }
        //ZapalenieLampki(i);
    }*/

    public void Przesuniecie() // int i
    {
        

        //Debug.Log(Ring1_Angle + "  " + Ring2_Angle + "  " + Ring3_Angle);

        if (Ring1_Angle >= 350)   // PODMIENIANA RECZNA 360 / ILOSC ZNAKOW ZAOKRAGLIJ DO PEŁNEJ WARTOSCI W DÓŁ
        {
            if (Ring2_Angle >= 350)   // PODMIENIANA RECZNA 360 / ILOSC ZNAKOW ZAOKRAGLIJ DO PEŁNEJ WARTOSCI W DÓŁ
            {
                if (Ring3_Angle >= 350)   // PODMIENIANA RECZNA 360 / ILOSC ZNAKOW ZAOKRAGLIJ DO PEŁNEJ WARTOSCI W DÓŁ
                {
                    //labelPierscien1.Text = (ScrollBarPierscien1.Value = 1).ToString();
                    //labelPierscien2.Text = (ScrollBarPierscien2.Value = 1).ToString();
                    //labelPierscien3.Text = (ScrollBarPierscien3.Value = 1).ToString();
                    //Ring_1.transform.localRotation = Quaternion.Euler(Angle, 0, 0);
                    ///Ring_2.transform.localRotation = Quaternion.Euler(Angle, 0, 0);
                    //Ring_3.transform.localRotation = Quaternion.Euler(Angle, 0, 0);

                               

                    PrzesunieciePierscienPierwszy();
                    PrzesunieciePierscienDrugi();
                    PrzesunieciePierscienTrzeci();

                    Ring1_Angle = 0;
                    Ring2_Angle = 0;
                    Ring3_Angle = 0;
                }
                else
                {
                    //labelPierscien1.Text = (ScrollBarPierscien1.Value = 1).ToString();
                    //labelPierscien2.Text = (ScrollBarPierscien2.Value = 1).ToString();
                    //labelPierscien3.Text = (ScrollBarPierscien3.Value += 1).ToString();
                    //Ring_1.transform.localRotation = Quaternion.Euler(Angle, 0, 0);
                    //Ring_2.transform.localRotation = Quaternion.Euler(Angle, 0, 0);
                    //Ring_3.transform.Rotate(Angle, 0.0f, 0.0f, Space.Self);

                    

                    PrzesunieciePierscienPierwszy();
                    PrzesunieciePierscienDrugi();
                    PrzesunieciePierscienTrzeci();

                    Ring1_Angle = 0;
                    Ring2_Angle = 0;
                }
            }
            else
            {
                //labelPierscien1.Text = (ScrollBarPierscien1.Value = 1).ToString();
                //labelPierscien2.Text = (ScrollBarPierscien2.Value += 1).ToString();
                //Ring_1.transform.localRotation = Quaternion.Euler(Angle, 0, 0);
                //Ring_2.transform.Rotate(Angle, 0.0f, 0.0f, Space.Self);
                PrzesunieciePierscienPierwszy();
                PrzesunieciePierscienDrugi();

                Ring1_Angle = 0;
                //Ring_1.transform.localRotation = Quaternion.Euler(Ring1_Angle, 0, 0);

                //Debug.Log(Ring1_Angle);

                
                
            }
        }
        else
        {
            //labelPierscien1.Text = (ScrollBarPierscien1.Value += 1).ToString();
            //Ring_1.transform.Rotate(Angle, 0.0f, 0.0f, Space.Self);

            PrzesunieciePierscienPierwszy();
        }
        //ZapalenieLampki(i);
    }

    /*void ZapalenieLampki(int i)
    {
        MeshRenderer test = Main.Lights.transform.GetChild(i).GetComponent<MeshRenderer>();
        test.material = Resources.Load("LIGHTS_KB_ON", typeof(Material)) as Material;
    }*/

    public void UpdateRings()
    {
        PierścienPierwszy.Clear();
        PierścienDrugi.Clear();
        PierścienTrzeci.Clear();
        BebenOdwaracajacy.Clear();

        int temp;

        for (int i = 0; i < childCount_1; i++)
        {
            temp = int.Parse(Update_1.transform.GetChild(i).GetComponentInChildren<Text>().text);
            PierścienPierwszy.Add(temp);
        }

        for (int i = 0; i < childCount_2; i++)
        {
            temp = int.Parse(Update_2.transform.GetChild(i).GetComponentInChildren<Text>().text);
            PierścienDrugi.Add(temp);
        }

        for (int i = 0; i < childCount_3; i++)
        {
            temp = int.Parse(Update_3.transform.GetChild(i).GetComponentInChildren<Text>().text);
            PierścienTrzeci.Add(temp);
        }

        for (int i = 0; i < childCount_ReverseRing; i++)
        {
            temp = int.Parse(Update_ReverseRing.transform.GetChild(i).GetComponentInChildren<Text>().text);
            BebenOdwaracajacy.Add(temp);
        }
    }
}
