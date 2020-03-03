using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Sitter på main camera i game, spawnar föremål i spelet

public class flyingHitObjectsSpawn : MonoBehaviour
{
    public Transform goodObj01;
    public Transform goodObj02;
    public Transform goodObj03;
    public Transform crowEnemy;
    public Transform fastEnemy1;
    public Transform fastEnemy2;
    public Transform fastEnemy3;
    public Transform fastEnemy4;
    public Transform powerupSlow;
    public Transform powerupDouble;
    public Transform powerupShield;
    public Transform powerupRepair;
    public Transform powerupTimer;
    public Transform powerupVirus;
    //interval som gör så att objektens spawn minskar tillsammans med hastigheten
    public static float spawninvterval = 0.3f;

    //Samla alla flyingHitObjects i en array
    private Transform[] flyingHitObjects;
    private Transform[] powerupObjects;
    private Transform[] swarmObjects;
    //Hitta random element i array
    private int randomflyingHitObject;
    private int randomPowerupObject;
    private int randomswarmObject;

    //Startposition för flyingHitObjects
    private float maxPositionY;
    private float minPositionY;
    private float randomPosY;
    private static float positionX;

    //Hur tätt ska flyingHitObjects dyka upp! Interval kommer vara ett random värde!
    //Om du vill ändra tätheten, ändra de 2 värdena i den sista kodraden i detta skript!
    private float interval;
    private float catchTime = 0f;



    void Start()
    {
        guiController.lastmodepvp = false;
        interval = 1.0f;

        //Definiera storleken på min array
        flyingHitObjects = new Transform[9];
        //Lägga in objekten i min array
        flyingHitObjects[0] = goodObj01;
        flyingHitObjects[1] = goodObj01;
        flyingHitObjects[2] = goodObj01;
        flyingHitObjects[3] = crowEnemy;
        flyingHitObjects[4] = goodObj02;
        flyingHitObjects[5] = goodObj02;
        flyingHitObjects[6] = crowEnemy;
        flyingHitObjects[7] = goodObj02;
        flyingHitObjects[8] = goodObj03;
        powerupObjects = new Transform[6];
        powerupObjects[0] = powerupSlow;
        powerupObjects[1] = powerupDouble;
        powerupObjects[2] = powerupShield;
        powerupObjects[3] = powerupRepair;
        powerupObjects[4] = powerupTimer;
        powerupObjects[5] = powerupVirus;
        swarmObjects = new Transform[11];
        swarmObjects[0] = goodObj01;
        swarmObjects[1] = goodObj01;
        swarmObjects[2] = goodObj02;
        swarmObjects[3] = goodObj02;
        swarmObjects[4] = goodObj03;
        swarmObjects[5] = fastEnemy1;
        swarmObjects[6] = fastEnemy2;
        swarmObjects[7] = fastEnemy3;
        swarmObjects[8] = fastEnemy4;
        swarmObjects[9] = fastEnemy3;
        swarmObjects[10] = fastEnemy2;





        //Högst upp på skärmen. Värdet -0.8 fick jag testa mig fram till
        maxPositionY = (Camera.main.orthographicSize) - 0.8f;
        //Längst ned på skärmen
        minPositionY = -Camera.main.orthographicSize;
        //Bortom högra sidan av skärmen 
        positionX = Camera.main.orthographicSize * 1 * Camera.main.aspect;

    }

    void Update()
    {
        if (guiController.swarmmode == false && guiController.osu == false)
        {
            if (Time.time - catchTime > interval)
            {
                SpawnflyingHitObjects();
            }
        }
        else if (guiController.swarmmode == true)
        {
            if (Time.time - catchTime > interval)
            {
                spawnswarm();
            }
        }
        else if (guiController.osu == true)
        {
            //funktion som spawnar osu 
        }
        //spawnar en powerup 19-28 sekunder efter förra
        if (guiController.actualPlayTime > Random.Range(19, 24))
        {
                    SpawnPowerupObject();
        }
    }


    void SpawnflyingHitObjects()
    {
        randomflyingHitObject = Random.Range(0, flyingHitObjects.Length);
       // Debug.Log (randomflyingHitObject);

        randomPosY = Random.Range(minPositionY, maxPositionY);
        Instantiate(flyingHitObjects[randomflyingHitObject], new Vector3(positionX, randomPosY, 0), Quaternion.identity);
        catchTime = Time.time;
        interval = Random.Range(0.05f, spawninvterval);
        // Debug.Log(interval);
        if (flyingHitObjects[randomflyingHitObject] == crowEnemy)
        {
            PlayerPrefs.SetInt("shurikenspawns", PlayerPrefs.GetInt("shurikenspawns", 0) + 1);
        }
        else
        {
            PlayerPrefs.SetInt("goodspawns", PlayerPrefs.GetInt("goodspawns", 0) + 1);
        }
    }

    void spawnswarm()
    {
        randomswarmObject = Random.Range(0, swarmObjects.Length);
        // Debug.Log (randomflyingHitObject);

        randomPosY = Random.Range(minPositionY, maxPositionY);
        Instantiate(swarmObjects[randomswarmObject], new Vector3(positionX, randomPosY, 0), Quaternion.identity);
        catchTime = Time.time;
        interval = Random.Range(0.05f, spawninvterval-0.11f);
        // Debug.Log(interval);
        PlayerPrefs.SetInt("shurikenspawns", PlayerPrefs.GetInt("shurikenspawns", 0) + 1);
    }

    void SpawnPowerupObject()
    {
        randomPowerupObject = Random.Range(0, powerupObjects.Length);
        randomPosY = Random.Range(minPositionY, maxPositionY);
        Instantiate(powerupObjects[randomPowerupObject], new Vector3(positionX, randomPosY, 0), Quaternion.identity);
        guiController.actualPlayTime = 0;
        PlayerPrefs.SetInt("powerspawns", PlayerPrefs.GetInt("powerspawns", 0) + 1);
    }

}
