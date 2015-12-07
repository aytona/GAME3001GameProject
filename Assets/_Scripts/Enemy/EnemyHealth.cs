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
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "DefaultBullet")
            Destroy(other.gameObject);
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
