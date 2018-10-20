using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1GmD-UPM0SOgiVftxFA0Hn5nTW3_RDDbCUoN2FU8n1Rc/edit")]
public class AutoPointsModifier : MonoBehaviour
{

    private float _autoPoints = 0; // points added every interval
    private float _globalPointsMultipler = 1; // global points multipler

    public float AutoPoints
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

    public void AddAutoPoints(float addedValue) //dodanie do puli dodawanej co interwal
    {
        CoreClickerSystem.Instance.autoPointsManager.DodajLiczbePunktow(addedValue);
        _autoPoints += addedValue;
    }
    public void AddAutoPoints(float addedValue, int time) //dodanie do puli dodawanej co interwal (czasowo)
    {
        CoreClickerSystem.Instance.autoPointsManager.DodajLiczbePunktow(addedValue, time);
    }

    public void ChangeAutoPointsValue(float newValue) //zmiana puli dodawanej co interwal
    {
        AddAutoPoints(newValue - _autoPoints);
    }
    public void ChangeAutoPointsValue(float newValue, int time) //zmiana puli dodawanej co interwal (czasowo)
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

