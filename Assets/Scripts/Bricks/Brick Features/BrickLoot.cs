using UnityEngine;

public class BrickLoot
{
    private BrickLootSO _brickLootSO;

	public BrickLoot(BrickLootSO brickLootSO)
    {
        _brickLootSO = brickLootSO;
    }

    public void ChooseLoot()
    {
        int random = Random.Range(1, CalculateTotalOdds() + 1);
        int cumulativeOdds = 0;
        foreach (LootOdds lootOdds in _brickLootSO.LootOdds)
        {
            cumulativeOdds += lootOdds.Odds;
            if (random < cumulativeOdds)
            {
                DropLoot(lootOdds.ItemPrefab);
            }
        }
    }

    private void DropLoot(GameObject itemPrefab)
    {
        // Can't instantiate without Monobehaviour, grab from object pool instead?
        //GameObject itemInstance = Instantiate(itemPrefab);
    }

    private int CalculateTotalOdds()
    {
        int total = 0;

        foreach (LootOdds lootOdds in _brickLootSO.LootOdds)
        {
            total += lootOdds.Odds;
        }

        return total;
    }
}