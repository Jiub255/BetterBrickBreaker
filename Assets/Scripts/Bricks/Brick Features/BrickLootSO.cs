using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Brick Loot SO", fileName = "New Brick Loot SO")]
public class BrickLootSO : ScriptableObject
{
    [SerializeField]
    private List<LootOdds> _lootOdds;

    public List<LootOdds> LootOdds { get { return _lootOdds; } }
}