using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    //public GameObject Enemy;

    //private bool waveOnGoing = true;
    //public int currentWave = 0;
    //private int enemyHealth;
    //private float waveDuration;
    //private float spawnTimer;
    //private float spawningInterval;

    //public GameObject gracePeriodUI;

    //public GameObject leftUpgradeCard;
    //public GameObject rightUpgradeCard;


    //public GameObject Player;

 

    





    //// Start is called before the first frame update
    //void Start()
    //{
    //    startNextRound();
    //}

    //// point1 x = 48
    //// point1 y = 0.6
    //// point1 z = -48

    //// point2 x = -48
    //// point2 y = 0.6
    //// point1 z = 48


    //// Update is called once per frame
    //void Update()
    //{
    //    if (waveOnGoing)
    //    {

            

    //        waveDuration -= Time.deltaTime;
    //        spawnTimer -= Time.deltaTime;



    //        if (spawnTimer <= 0)
    //        {
    //            spawnTimer = spawningInterval;
    //            spawnEnemy();
    //        }

    //        if (waveDuration <= 0)
    //        {
    //            waveOnGoing = false;
    //            beginGracePeriod(currentWave);
    //        }
                

    //    }
    //}


    //public void spawnEnemy()
    //{
    //    bool ValidSpawnPoint = false;
    //    while (!ValidSpawnPoint)
    //    {
    //        int xPosition = Random.Range(-48, 48);
    //        int zPosition = Random.Range(-48, 48);

    //        //if player is within a 10 unit radius, dont spawn enemy there
    //        if (!(Mathf.RoundToInt(Player.transform.position.x - 15) < xPosition && 
    //            Mathf.RoundToInt(Player.transform.position.x + 15) > xPosition &&
    //            Mathf.RoundToInt(Player.transform.position.z - 15) < zPosition &&
    //            Mathf.RoundToInt(Player.transform.position.z + 15) > zPosition))
    //        {
    //            Instantiate(Enemy, new Vector3(xPosition, 0.6f, zPosition), Quaternion.identity);
    //            return;
    //        }
    //    }

    //}

    //void generateWaveSettings()
    //{

    //    spawnTimer = 0;

    //    waveDuration = 0 + (currentWave * 1);

    //    enemyHealth = currentWave + (currentWave / 3);

    //    if (currentWave >= 7)
    //    {
    //        spawningInterval = 0.5f;
    //    }
    //    else
    //    {
    //        spawningInterval = (float)Mathf.Log((10 - currentWave)) - 0.5f;
    //    }


      
        
    //}

    //void beginGracePeriod(int wave)
    //{
    //    wave++;
    //    gracePeriodUI.SetActive(true);
    //    gracePeriodUI.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = "Wave " + (wave - 1) + " complete!";
    //    leftUpgradeCard.SetActive(true);
    //    rightUpgradeCard.SetActive(true);
    //    generateCards();
    //}


    //public void generateCards()
    //{

    //    Sprite powerUpImage;

    //    //sets left card upgrade
    //    int spellID = Random.Range(0, 7);
        
    //    var tex = Resources.Load<Texture2D>(gameObject.GetComponent<PowerUps>().GetPowerUpData()[spellID].getImage());
    //    var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

    //    leftUpgradeCard.GetComponent<Transform>().Find("Image").GetComponent<Image>().sprite = sprite;

    //    leftUpgradeCard.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = gameObject.GetComponent<PowerUps>().GetPowerUpData()[spellID].getDescpription();

    //    //leftUpgradeCard.GetComponent<Transform>().Find("CardButton").GetComponent<SpellCard>().setSpell(spellID);


    //    //sets right card upgrade
    //    spellID = Random.Range(0, 9);

    //    tex = Resources.Load<Texture2D>(gameObject.GetComponent<PowerUps>().GetPowerUpData()[spellID].getImage());
    //    sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

    //    rightUpgradeCard.GetComponent<Transform>().Find("Image").GetComponent<Image>().sprite = sprite;

    //    rightUpgradeCard.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = gameObject.GetComponent<PowerUps>().GetPowerUpData()[spellID].getDescpription();

    //   // rightUpgradeCard.GetComponent<Transform>().Find("CardButton").GetComponent<SpellCard>().setSpell(spellID);
    //}



    //public void startNextRound()
    //{
    //    gracePeriodUI.SetActive(false);
    //    leftUpgradeCard.SetActive(false);
    //    rightUpgradeCard.SetActive(false);
    //    currentWave++;
    //    generateWaveSettings();
    //    waveOnGoing = true;
    //}

    //public float getEnemyHealth()
    //{
    //    return enemyHealth;
    //}



}
