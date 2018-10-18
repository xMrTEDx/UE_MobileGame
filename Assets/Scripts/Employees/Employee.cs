using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public Employee() //konstruktor, przy tworzeniu nowego pracownika losuje jego wydajnosc z doswiadczenia
	{
		_experienceProductivity = UnityEngine.Random.Range(10,20);
	}
}
