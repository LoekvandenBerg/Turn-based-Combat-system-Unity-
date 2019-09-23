using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int health;
    public int maxHealth;
    public int attackPower;
    public int defensePower;
    public int manaPoints;
    public List<Spell> spells;

    public void Hurt(int amount)
    {
        int dmgAmount = Random.Range(0, 1)* (amount - defensePower);
        //can't go below 0 health
        health = Mathf.Max(health - dmgAmount, 0);
        if (health == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        int healAmount = Random.Range(0, 1) * (amount + attackPower);
        //can't go above maxHealth
        health = Mathf.Min(health + healAmount, maxHealth);
    }

    public void Defend()
    {
        defensePower += (int)(defensePower * .33);
        Debug.Log("Defense increased");
    }

    public bool CastSpell(Spell spell, Character targetCharacter)
    {
        bool succesfull = manaPoints >= spell.manaCost;
        if (succesfull)
        {
            Spell spellToCast = Instantiate<Spell>(spell, transform.position, Quaternion.identity);
            manaPoints -= spell.manaCost;
            spellToCast.Cast(targetCharacter);
        }

        return succesfull;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        Debug.LogFormat("{0} has died!", characterName);
    }
}
