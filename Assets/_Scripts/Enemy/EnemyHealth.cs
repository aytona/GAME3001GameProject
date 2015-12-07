using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public enum EnemyType
    {
        Melee = 10,
        Range = 7,
        Boss = 25
    }

    private EnemyType type;
    private int health;

    void Awake()
    {
        CheckType();
    }

    void Update()
    {

        if (health <= 0)
        {
            GameData._Instance.Coins += (int)type;
            GameData._Instance.Score += (int)type;
            Destroy(transform.parent.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DefaultBullet")
        {
            Destroy(other.gameObject);
            health -= 1;
        }
        if (other.tag == "UpgradedBullet")
        {
            Destroy(other.gameObject);
            health -= 5;
        }
        if (other.tag == "ConeBullet")
        {
            health -= 10;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "ConstantBullet")
        {
            health -= 15;
        }
    }

    private void CheckType()
    {
        if (gameObject.tag == "Melee")
            type = EnemyType.Melee;
        if (gameObject.tag == "Range")
            type = EnemyType.Range;
        if (gameObject.tag == "Boss")
            type = EnemyType.Boss;
        health = (int)type;
    }
}
