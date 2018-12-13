using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1GmD-UPM0SOgiVftxFA0Hn5nTW3_RDDbCUoN2FU8n1Rc/edit")]
public class AutoPointsModifier : MonoBehaviour
{
    //reprezentuje kazdy obiekt w grze tworzący przychody w postaciu punktów co cykl zegara gry (domyślnie co 2 sekundy)
    //przechowuje liczbe punktów które dodaje oraz operacje do zmiany ilości tychże punktów

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


    #region points operations
    public void AddAutoPoints(float addedValue) //dodanie do puli dodawanej co interwal
    {
        ClickerGame.Instance.PointsSystem.autoPointsManager.DodajLiczbePunktow(addedValue);
        _autoPoints += addedValue;
    }
    public void AddAutoPoints(float addedValue, int time) //dodanie do puli dodawanej co interwal (czasowo)
    {
        ClickerGame.Instance.PointsSystem.autoPointsManager.DodajLiczbePunktow(addedValue, time);
        // nie zwiększam _autoPoints bo i tak zaraz wróci do poprzedniego stanu       
    }

    public void ChangeAutoPointsValue(float newValue) //zmiana puli dodawanej co interwal
    {
        AddAutoPoints(newValue - _autoPoints);
    }
    public void ChangeAutoPointsValue(float newValue, int time) //zmiana puli dodawanej co interwal (czasowo)
    {
        AddAutoPoints(newValue - _autoPoints, time);     
    }
    #endregion




    #region multipler operations
    public void AddPointsMultipler(float multiplingValue) //dodanie do mnoznika czasowy (przemnozenie)
    {
        ClickerGame.Instance.PointsSystem.autoPointsManager.DodajMnoznikPunktow(multiplingValue);
        _globalPointsMultipler *= multiplingValue;
    }
    public void AddPointsMultipler(float multiplingValue, int time) //dodanie do mnoznika (przemnozenie) - czasowo
    {
        ClickerGame.Instance.PointsSystem.autoPointsManager.DodajMnoznikPunktow(multiplingValue, time);
        // nie zmieniam _globalPointsMultipler bo i tak zaraz wróci do poprzedniego stanu
    }
    public void ChangePointsMultipler(float newValue) //zmiana mnoznika
    {
        AddPointsMultipler(newValue / _globalPointsMultipler);
    }
    public void ChangePointsMultipler(float newValue, int time) //zmiana mnoznika czasowa
    {
        AddPointsMultipler(newValue / _globalPointsMultipler, time);
    }
    #endregion

}

