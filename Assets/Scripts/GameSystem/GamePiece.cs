using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour {

    private ClickerGame _clickerGame;

    public ClickerGame ClickerGame
    {
        get
        {
            return _clickerGame;
        }
    }

    public void SetParent(ClickerGame clickerGame)
	{
		_clickerGame = clickerGame;
	}
}

