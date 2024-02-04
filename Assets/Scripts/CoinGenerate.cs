using UnityEngine;

public class CoinGenerate : MonoBehaviour
{
    public GameObject coinPrefab;
    public int numberOfCoins = 10;
    public float terrainWidth = 50f;
    public float spawnHeightAboveTerrain = 5f; 

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-terrainWidth / 2f, terrainWidth / 2f),
                spawnHeightAboveTerrain, 
                Random.Range(-terrainWidth / 2f, terrainWidth / 2f)
            );

            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        }
    }
}
