using System.Collections;
using UnityEngine;

public class CoinSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float spawnInterval = 7f;

    private float minY = -4f;
    private float maxY = 7f;
    private float minX = -12f;
    private float maxX = 12f;

    private bool isSpawning = false;

    private void Start()
    {
        isSpawning = true;
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (isSpawning)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);

            // Check if the spawn position overlaps with a collider with tag "Wall"
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 0.5f);
            //
            bool overlapsWall = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Wall"))
                {
                    overlapsWall = true;
                    break;
                }
            }

            if (overlapsWall)
            {
                continue;
            }

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

 //  public void StopSpawning()
 //  {
 //      isSpawning = false;
 //  }
}

