using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictCollisionDetection : MonoBehaviour {

    BuyPanelManager buyPanelMan;

    private void Start()
    {
        buyPanelMan = GetComponentInParent<BuyPanelManager>();
    }

    private void OnMouseDown()
    {
        buyPanelMan.EnableBuyPanel(gameObject);
    }
}
