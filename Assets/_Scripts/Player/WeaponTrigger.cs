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

    public int damagePerShot;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    private float timer;
    private Ray shootRay;
    private RaycastHit shootHit;
    private int shootableMask;
    private LineRenderer gunLine;
    private Light gunLight;
    private float effectsDisplay = 0.2f;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenBullets * effectsDisplay)
            DisableEffects();

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
        damagePerShot = 1;
        Shoot(damagePerShot);
    }

    void UpgradedShoot()
    {
        damagePerShot = 3;
        Shoot(damagePerShot);
    }

    void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot(int _damagePerShot)
    {
        gunLight.enabled = true;
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.right;
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(_damagePerShot, shootHit.point);
            gunLine.SetPosition(1, shootHit.point);
        }
        else
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
    }
}