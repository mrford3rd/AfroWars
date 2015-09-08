//This is a wave spawner based
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehavior
{
	
	public enum SpawnState {SPAWNING, WAITING, COUNTDOWN}
	//Make it serializable to allow it to be seen in the inspector
	[System Serializable]
	
	//The Fields that make up a wave from name to the enemy how many of the enemy to spawn and how often.
	public class Wave
	{
		public String name; //Name of the enemy
		public Transform enemy; //This may change to active when used with an  object pool
		public int bossPTS; //How many points to add to the boss
		public int playerPTS; //If killed how many points player gets
		public int enemyHealth; //Enemy Health
		public int count; //How many of the enemy to spawn
		public float rate; //How fast to spwan the enemy
	}
	
	public Wave[] waves;
	private int nextWave =0;
	public float timeBetweenWaves = 5f;
	public float waveCountdown;
	private SpawnState state = SpawnState.COUNTDOWN;
	
	void Start()
	{
		//Set waveCountdown to timeBetweenWaves and the waveCountdown will be the variable modified
		waveCountdown = timeBetweenWaves;
	}
	
	void update()
	{
		//If waveCountdown is not zero keep running the timer down based on game time and then when
		//zero change state to spawning and call the spawn function
		if (waveCountdown <=0)
		{
			//This checks to see if we are spawning enemies and if so don't start another spawning of enemies
			if (state != SpawnState.SPAWNING)
			{
				StarteCorutine(SpawnWave(waves[nextWave]));
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}
	
	IEnumerator SpawnWave(Wave _wave)
	{
		//Set state to spawning
		state = SpawnState.SPAWNING; 
		
		//Run for loop till total enemies for wave have been spawned
		for (int i =0; i< _wave.count); i++)
		{
			//Spawn enemy then wait for so many seconds then spawn another enemy
			SpawnEnemy(_wave.enemy);
			yield return new waitForSeconds(1f/_wave.rate);
		}
		
		//Once done spawning enemies stop and set state to waiting
		state = SpawnState.WAITING;
		//Stop Coroutine
		yield break;
	}
	
	void SpawnEnemy(Transform _enemy)
	{
		//Spawn Enemy this is where the object pool code should go
		//Check to see if there are any unactive enemies then 
		//set them active.
		Debug.Log("Spawning Enemy" + _enemy.name)
	}
	
}

