using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int attackDamage;

    private bool isAgressive;

    public enum FactionType { mouse, rat};
    private FactionType faction;

    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
	void Update ()
    {
		
	}

    public int GetHealth()
    {
        return health;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public bool GetIsAgressive()
    {
        return isAgressive;
    }

    public int GetAttackDamage()
    {
        return attackDamage;
    }

    public FactionType GetFactionType()
    {
        return faction;
    }

    public void SetHealth(int amount)
    {
        health = amount;
    }

    public void SetSpeed(int amount)
    {
        speed = amount;
    }

    public void SetIsAgressive(bool aggression)
    {
        isAgressive = aggression;
    }

    public void SetAttackDamage(int amount)
    {
        attackDamage = amount;
    }

    public void SetFactionType(FactionType type)
    {
        faction = type;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        //if they die
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
