using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class WeaponTrigger : MonoBehaviour {

    public GameObject defaultShooter;
    public GameObject upgradedPeaShooter;
    public GameObject coneShooter;
    public GameObject constantShooter;

    public GameObject defaulBullet;
    public GameObject upgradedBullet;
    public Transform defaultSpawner;
    public Transform upgradedSpawner;

    void Update()
    {
        if (GameData._Instance.UpgradeCount == 0)
        {
            defaultShooter.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
                DefaultShoot();
        }
        else if (GameData._Instance.UpgradeCount == 1)
        {
            defaultShooter.SetActive(false);
            upgradedPeaShooter.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
                UpgradedShoot();
        }
        else if (GameData._Instance.UpgradeCount == 10)
        {
            upgradedPeaShooter.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
                coneShooter.SetActive(true);
            else
                coneShooter.SetActive(false);
        }
        else if (GameData._Instance.UpgradeCount == 100)
        {
            coneShooter.SetActive(false);
            if (Input.GetKey(KeyCode.Space))
                constantShooter.SetActive(true);
            else
                constantShooter.SetActive(false);
        }
    }

    void DefaultShoot()
    {
        GameObject _defaultBullet = Instantiate(defaulBullet) as GameObject;
        _defaultBullet.transform.position = defaultSpawner.transform.position;
    }

    void UpgradedShoot()
    {
        GameObject _defaultBullet = Instantiate(upgradedBullet) as GameObject;
        _defaultBullet.transform.position = upgradedSpawner.transform.position;
    }
}