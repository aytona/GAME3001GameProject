using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class WeaponTrigger : MonoBehaviour {

    public GameObject defaultShooter;
    public GameObject upgradedPeaShooter;
    public GameObject coneShooter;
    public GameObject constantShooter;

    void Update()
    {
        if (GameData._Instance.UpgradeCount == 0)
        {
            defaultShooter.SetActive(true);
        }
        else if (GameData._Instance.UpgradeCount == 1)
        {
            defaultShooter.SetActive(false);
            upgradedPeaShooter.SetActive(true);
        }
        else if (GameData._Instance.UpgradeCount == 10)
        {
            upgradedPeaShooter.SetActive(false);
            coneShooter.SetActive(true);
        }
        else if (GameData._Instance.UpgradeCount == 100)
        {
            coneShooter.SetActive(false);
            constantShooter.SetActive(true);
        }
    }
}