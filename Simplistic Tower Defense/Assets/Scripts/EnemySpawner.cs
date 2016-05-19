using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {

    public float spawnCooldown = 0.5f;
    public float spawnCooldownRemaining = 3f;


    [System.Serializable]
    public class WaveComponent{
        public GameObject enemyPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
    }


    public WaveComponent[] waveComps;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        spawnCooldownRemaining -= Time.deltaTime;
        if(spawnCooldownRemaining < 0)
        {
            spawnCooldownRemaining = spawnCooldown;
            bool didSpawn = false;

            //Go through the wave comps until we find something to spawn
            foreach(WaveComponent wc in waveComps)
            {
                if(wc.spawned < wc.num)
                {
                    //Spawn it
                    wc.spawned++;
                    Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);

                    didSpawn = true;
                    break;
                }
            }
            
            if (didSpawn == false)
            {
                //Wave must be complete

                if (transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else if(transform.parent.childCount == 1)
                {
                    //End Game after last spawner, should not contain any enemies
                    SceneManager.LoadScene(0);
                }
                else
                {
                    //That was last wave
                    //Instead of Destroying, set them inactive, then maybe restart at first one with double HP values

                }
                transform.SetParent(null);
                Destroy(gameObject);

            }
        }
	}


}
