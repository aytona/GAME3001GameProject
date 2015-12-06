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
    private CapsuleCollider capsuleCollider;
    bool isDead;

    void Awake()
    {
        CheckType();
        capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log(health);
    }

    void Update()
    {
        Debug.Log(health);
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        Debug.Log(health);
        if (isDead)
            return;
        health -= amount;
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
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
