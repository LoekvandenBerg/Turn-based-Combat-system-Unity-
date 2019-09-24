using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIController : MonoBehaviour
{   
    [SerializeField]
    private GameObject spellPanel;
    [SerializeField]
    private Button[] actionButtons;
    [SerializeField]
    private Button button;
    [SerializeField]
    private Text[] characterInfo;

    private void Start()
    {
        spellPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction);
            if(hitInfo.collider != null && hitInfo.collider.CompareTag("Character"))
            {
                BattleController.Instance.SelectCharacter(hitInfo.collider.GetComponent<Character>());
            }
        }
    }

    public void ToggleSpellPanel(bool state)
    {
        spellPanel.SetActive(state);
        if (state)
        {
            BuildSpellList(BattleController.Instance.GetCurrentCharacter().spells);
        }
    }

    public void ToggleActionState(bool state)
    {
        ToggleSpellPanel(state);
        foreach(Button button in actionButtons)
        {
            button.interactable = state;
        }
    }

    public void BuildSpellList(List<Spell> spells)
    {
        if(spellPanel.transform.childCount > 0)
        {
            foreach(Button button in spellPanel.transform.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }

        foreach(Spell spell in spells)
        {
            Button spellButton = Instantiate<Button>(button, spellPanel.transform);
            spellButton.GetComponentInChildren<Text>().text = spell.spellName;
            spellButton.onClick.AddListener(() => SelectSpell(spell));
        }
    }

    void SelectSpell(Spell spell)
    {
        BattleController.Instance.playerSelectedSpell = spell;
        BattleController.Instance.playerIsAttacking = false;
    }

    public void SelectAttack()
    {
        BattleController.Instance.playerSelectedSpell = null;
        BattleController.Instance.playerIsAttacking = true;
    }

    public void UpdateCharacterUI()
    {
        for(int i = 0; i < BattleController.Instance.characters[0].Count; i++)
        {
            Character character = BattleController.Instance.characters[0][i];
            characterInfo[i].text = string.Format("{0} hp: {1}/{2} mp: {3}", character.characterName, character.health, character.maxHealth, character.manaPoints);
        }
    }

    public void Defend()
    {
        BattleController.Instance.GetCurrentCharacter().Defend();
    }
}
