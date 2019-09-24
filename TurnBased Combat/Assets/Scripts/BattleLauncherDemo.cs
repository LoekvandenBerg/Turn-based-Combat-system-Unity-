using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLauncherDemo : MonoBehaviour
{
    [SerializeField]
    private List<Character> players, enemies;
    [SerializeField]
    private BattleLauncher launcher;
    
    public void Launch()
    {
        launcher.PrepareBattle(enemies, players);
    }
}
