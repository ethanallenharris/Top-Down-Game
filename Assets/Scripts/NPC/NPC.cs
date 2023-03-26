using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int level;
    public string name;
    public NpcFaction faction;



   // public NPC(int _level, string _name, string _faction)
    //{
    //    level = _level;
    //    name = _name;
    //    faction = (NpcFaction)System.Enum.Parse(typeof(NpcFaction), _faction);
    //}
}

public enum NpcFaction
{
    goblin,
    civilian,
    bandit

}