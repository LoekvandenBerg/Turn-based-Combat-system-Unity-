using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSpawnPoint : MonoBehaviour
{
    public Character Spawn(Character character)
    {
        Character characterTospawn = Instantiate<Character>(character, this.transform);
        return characterTospawn;
    }
}
