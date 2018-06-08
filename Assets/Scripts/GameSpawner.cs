using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;

	public Text waveCountdonwText;
	private float countdown = 2f;

	private int waveIndex = 0; 

	void Update(){
	
		if (countdown <= 0f) 
		{
			StartCoroutine (Spawnwave ());
			countdown = timeBetweenWaves;
		}
		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		waveCountdonwText.text = string.Format ("{0:00.00}", countdown);
			
	}
	IEnumerator Spawnwave()
	{
		waveIndex++;
        PlayerStats.Rounds++;
		//Debug.Log ("Wave coming!");
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.3f);
		}

	}
	void SpawnEnemy (){
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);

	}

}
