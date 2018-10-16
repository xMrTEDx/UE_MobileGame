using UnityEngine;

public class AutoPointsComponent : MonoBehaviour
{

    private int _autoPoints = 0; // points added every interval
    private float _globalPointsMultipler = 1; // global points multipler

    public int AutoPoints
    {
        get
        {
            return _autoPoints;
        }
    }
    public float GlobalPointsMultipler
    {
        get
        {
            return _globalPointsMultipler;
        }
    }

    public void AddAutoPoints(int addedValue) //dodanie do puli dodawanej co interwal
    {
        CoreClickerSystem.Instance.autoPointsManager.DodajLiczbePunktow(addedValue);
        _autoPoints += addedValue;
    }
    public void AddAutoPoints(int addedValue, int time) //dodanie do puli dodawanej co interwal (czasowo)
    {
        CoreClickerSystem.Instance.autoPointsManager.DodajLiczbePunktow(addedValue, time);
    }

    public void ChangeAutoPointsValue(int newValue) //zmiana puli dodawanej co interwal
    {
        AddAutoPoints(newValue - _autoPoints);
    }
    public void ChangeAutoPointsValue(int newValue, int time) //zmiana puli dodawanej co interwal (czasowo)
    {
        AddAutoPoints(newValue - _autoPoints, time);
    }


    public void AddPointsMultipler(float multiplingValue) //dodanie do mnoznika czasowy (przemnozenie)
    {
        CoreClickerSystem.Instance.autoPointsManager.DodajMnoznikPunktow(multiplingValue);
        _globalPointsMultipler *= multiplingValue;
    }
    public void AddPointsMultipler(float multiplingValue, int time) //dodanie do mnoznika czasowy (przemnozenie) - czasowo
    {
        CoreClickerSystem.Instance.autoPointsManager.DodajMnoznikPunktow(multiplingValue, time);
    }
    public void ChangePointsMultipler(float newValue) //zmiana mnoznika
    {
        AddPointsMultipler(newValue / _globalPointsMultipler);
    }
    public void ChangePointsMultipler(float newValue, int time) //zmiana mnoznika czasowa
    {
        AddPointsMultipler(newValue / _globalPointsMultipler, time);
    }


}

