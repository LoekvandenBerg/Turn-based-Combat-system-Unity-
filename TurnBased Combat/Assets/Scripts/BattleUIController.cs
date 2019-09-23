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

    void SelectAttack()
    {
        BattleController.Instance.playerSelectedSpell = null;
        BattleController.Instance.playerIsAttacking = true;
    }
}
