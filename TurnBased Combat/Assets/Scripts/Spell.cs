using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public string spellName;
    public int power;
    public int manaCost;
    public enum SpellType {Attack, Heal }
    public SpellType spellType;

    private Vector3 targetPos;

    private void Update()
    {
        if(targetPos != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, .15f);
            if(Vector3.Distance(transform.position, targetPos)< .25f)
            {
                Destroy(gameObject, 1);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Cast(Character target)
    {
        targetPos = target.transform.position;
        Debug.Log(spellName + " was cast on " + target.name + "!"); 
        if(spellType == SpellType.Attack)
        {
            target.Hurt(power);
        }
        else if(spellType == SpellType.Heal)
        {
            target.Heal(power);
        }
    }


}
