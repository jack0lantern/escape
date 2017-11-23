using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour
{

	public GameObject spawns;

	private GameObject[] spawned;

	// Use this for initialization
	void Start ()
	{
		SpawnCircle (12, 5);
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void SpawnCollectible (Vector3 location)
	{
		GameObject collectible = Instantiate (spawns, location, Quaternion.identity) as GameObject;
	}

	void SpawnRandom (int n)
	{
		for (int i = 0; i < n; ++i) {
			Vector3 RandomVector = new Vector3 (Random.Range (-9.25f, 9.25f), 0.5f, Random.Range (-9.25f, 9.25f));
			SpawnCollectible (RandomVector);
		}
	}

	void SpawnCircle (int n, int radius)
	{
		for (int i = 0; i < n; ++i) {
			// In radians
			float angle = i * 2 * Mathf.PI / n;
			Vector3 CircleVector = new Vector3 (radius * Mathf.Sin (angle), 0.5f, radius * Mathf.Cos (angle));
			SpawnCollectible (CircleVector);
		}
	}
}
