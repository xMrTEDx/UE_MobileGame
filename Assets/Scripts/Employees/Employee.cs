using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1LJ0Bm-kiHVCUED1aXR4eYYMeoHanxb11K6mofgrlbIU/edit")]
public class Employee : MonoBehaviour
{
    private float _experienceProductivity; //wydajnosc z doswiadczenia (dla kazdego pracownika osobno)
    public float ExperienceProductivity
    {
        get
        {
            return _experienceProductivity;
        }
        set
        {
            if (value > 40)
                _experienceProductivity = 40;
            else if (value < 0)
                _experienceProductivity = 0;
            else _experienceProductivity = value;
        }
    }
    void Awake() //losuje wydajnosc z doswiadczenia po dodaniu pracownika na scene
    {
        _experienceProductivity = UnityEngine.Random.Range(10, 20);
    }
}
