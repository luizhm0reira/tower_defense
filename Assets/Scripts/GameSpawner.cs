using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSpawner : MonoBehaviour {



    public static int EnemiesAlive = 0;
    public Wave[] waves;
    //public Transform enemyPrefab;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;

	public Text waveCountdonwText;
	private float countdown = 2f;

	private int waveIndex = 0; 

	void Update(){

        if (EnemiesAlive > 0)
        {
            return;
        }
	
		if (countdown <= 0f) 
		{
			StartCoroutine (Spawnwave ());
			countdown = timeBetweenWaves;
            return;
		}
		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		waveCountdonwText.text = string.Format ("{0:00.00}", countdown);
			
	}
	IEnumerator Spawnwave()
	{
		PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];

		//Debug.Log ("Wave coming!");
		for (int i = 0; i < wave.count; i++) {
			SpawnEnemy (wave.enemy);
			yield return new WaitForSeconds (1 / wave.rate);
		}
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level Won!");
            this.enabled = false;
        }

    }
	void SpawnEnemy (GameObject enemy)
    {
		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;

	}

}
