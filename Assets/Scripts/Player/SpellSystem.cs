using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSystem : MonoBehaviour
{
    public List<Spell> spells = new List<Spell>();
    public Spell currentSpell;

    void Start()
    {
        //Populate the list of spells with the spells that the player knows

    }

    public void CastSpell(string spellName)
    {
        Spell spell = spells.Find(s => s.name == spellName);
        if (spell != null)
        {
            currentSpell = spell;
            //currentSpell.Cast();
        }
    }
}
