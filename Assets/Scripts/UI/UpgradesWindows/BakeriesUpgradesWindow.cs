using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BakeriesUpgradesWindow : MonoBehaviour
{

    List<BakeryUpgrade> upgrades;
    public GameObject prefabObiektuUlepszenia;
    public void Init()
	{
		upgrades = ClickerGame.Instance.GameSettings.gameUpgrades.bakeriesUpgrades.ToList();
        DodajUlepszenieNaScene();
        DodajUlepszenieNaScene();
        DodajUlepszenieNaScene();
	}
    public void DodajUlepszenieNaScene()
    {
        if (upgrades.Count > 0)
        {
            BakeryUpgrade upgrade = upgrades.First();

            GameObject obiektUlepszenia = Instantiate(prefabObiektuUlepszenia, Vector3.zero, Quaternion.identity, GetComponent<Transform>());

            UpgradeComponent referencjeObiektu = obiektUlepszenia.GetComponent<UpgradeComponent>();
            referencjeObiektu.upgradeDescription.text = upgrade.description;

            referencjeObiektu.button.onClick.AddListener(() =>
            {
                if (ClickerGame.Instance.PointsSystem.BuySomething(upgrade.cost))
                {
                    ClickerGame.Instance.BakeriesSystem.Ulepsz(upgrade);
                    Destroy(obiektUlepszenia);
                    DodajUlepszenieNaScene();
                }
                else
                {
                //wyświetl użytkownikowi że nie ma hajsu
                Debug.Log("Nie masz kasy na to ulepszenie");
                Prompt.Instance.ShowPrompt("Nie masz wystarczającej ilości gotowki na zakup tego ulepszenia");
                }
            });

            upgrades.Remove(upgrades.First());
        }
    }

}
