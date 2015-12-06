using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public enum EnemyType
    {
        Melee = 25,
        Range = 15,
        Boss = 80
    }

    private EnemyType type;
    private int health;
    private CapsuleCollider capsuleCollider;
    bool isDead;

    void Awake()
    {
        CheckType();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;
        health -= amount;
        if (health <= 0)
            Destroy(gameObject);
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
