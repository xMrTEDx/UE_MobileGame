using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictMapManager : MonoBehaviour {

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowDistrictMap(bool show)
    {
        switch (show)
        {
            case false:
                gameObject.SetActive(false);
                break;
            case true:
                gameObject.SetActive(true);
                break;
        }
    }
}
