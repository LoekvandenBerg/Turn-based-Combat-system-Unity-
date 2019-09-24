using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLauncher : MonoBehaviour
{
    public List<Character> Players { get; set; }
    public List<Character> Enemies { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

   public void PrepareBattle(List<Character> enemies, List<Character> players)
    {
        Players = players;
        Enemies = enemies;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }

    public void Launch()
    {
        BattleController.Instance.StartBattle(Players, Enemies);
    }
}
