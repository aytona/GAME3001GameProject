using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public enum EnemyType
    {
        Melee = 3,
        Boss = 9,
        Range = 2
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
            health -= 2;
        }
        if (other.tag == "ConeBullet")
        {
            health -= 3;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "ConstantBullet")
        {
            health -= 1;
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
