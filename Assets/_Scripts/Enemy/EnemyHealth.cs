using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public enum EnemyType
    {
        Melee = 3,
        Boss = 9,
        Range = 2
    }

    public GameObject animObject;
    public Animation anim;

    private EnemyType type;
    private int health;
    private bool dead = false;
    private NavScriptArrive navScript;
    private BoxCollider boxCollider;

    void Awake()
    {
        CheckType();
        boxCollider = GetComponent<BoxCollider>();
        anim = animObject.GetComponent<Animation>();
        navScript = GetComponentInParent<NavScriptArrive>();
    }

    void Update()
    {
        if (health <= 0 && !dead)
        {
            GameData._Instance.Coins += (int)type;
            GameData._Instance.Score += (int)type;
            dead = true;
            anim.Play("Death", PlayMode.StopSameLayer);
            navScript.agent.Stop();
            boxCollider.enabled = false;
            Destroy(transform.parent.gameObject, anim.GetClip("Death").length);
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

    public bool GetDead()
    {
        return dead;
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
