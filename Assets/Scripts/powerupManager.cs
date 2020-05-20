using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sitter på main camera i game, ger effekter & hanterar powerups

public class powerupManager : MonoBehaviour

{
    public AudioClip slowsound;
    public AudioClip repairsound;
    public AudioClip speedup;
    public bool reversing = false;

    void Update()
    {
        if (collisions.powerupdoubleS == true)
        {
            StartCoroutine(doublepoints());
        }
        if (collisions.powerupslowS == true)
        {
            StartCoroutine(slowdown());
        }
        if (collisions.powerupshieldS == true)
        {
            StartCoroutine(shield());
        }
        if (collisions.poweruprepair == true)
        {
            StartCoroutine(repair());
        }
        if (collisions.powerupReverseS == true)
        {
            StartCoroutine(reverse());
        }

    }


    IEnumerator doublepoints()
    {
        PlayerPrefs.SetInt("powercollects", PlayerPrefs.GetInt("powercollects", 0) + 1);
        Debug.Log("Double points started");
        collisions.powerupdoubleS = false;
        collisions.powerupdouble = true;
        yield return new WaitForSeconds(5f);
        collisions.powerupdouble = false;
        Debug.Log("Double points ended");
    }
    IEnumerator repair()
    {
        PlayerPrefs.SetInt("powercollects", PlayerPrefs.GetInt("powercollects", 0) + 1);
        collisions.poweruprepair = false;
        GetComponent<AudioSource>().clip = repairsound;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Thanos repaired");
    }
    IEnumerator reverse()
    {
        PlayerPrefs.SetInt("powercollects", PlayerPrefs.GetInt("powercollects", 0) + 1);
        collisions.powerupReverseS = false;
        collisions.powerupReverse = true;
        yield return new WaitForSeconds(0.1f);
        Debug.Log("reverse started");
        reversing = true;
    }
    IEnumerator shield()
    {
        PlayerPrefs.SetInt("powercollects", PlayerPrefs.GetInt("powercollects", 0) + 1);
        Debug.Log("Shield started");
        collisions.powerupshield = true;
        collisions.powerupshieldS = false;
        yield return new WaitForSeconds(10f);
        collisions.powerupshield = false;
        Debug.Log("Shield ended");
    }

    IEnumerator slowdown()
    {
        PlayerPrefs.SetInt("powercollects", PlayerPrefs.GetInt("powercollects", 0) + 1);
        GetComponent<AudioSource>().clip = slowsound;
        GetComponent<AudioSource>().Play();
        Debug.Log("Slow started");
        collisions.powerupslowS = false;
        collisions.powerupslow = true;
        flyingHitObjectsMovement.Speed = 5;
        heroController.verticalSpeed = 50;
        heroController.rotationdown = -33;
        heroController.rotationup = 33;
        pvpController.verticalSpeed = 50;
        pvpController.rotationdown = -33;
        pvpController.rotationup = 33;
        flyingHitObjectsSpawn.spawninvterval = 0.28f;
        //väntar 5.5s och sen ändrar tillbaka spawn interval
        yield return new WaitForSeconds(6f);
        flyingHitObjectsSpawn.spawninvterval = 0.3f;
        GetComponent<AudioSource>().clip = speedup;
        GetComponent<AudioSource>().Play();
        collisions.powerupslow = false;
        heroController.verticalSpeed = 125;
        flyingHitObjectsMovement.Speed = 9;
        heroController.rotationdown = -42;
        heroController.rotationup = 42;
        pvpController.verticalSpeed = 125;
        pvpController.rotationdown = -42;
        pvpController.rotationup = 42;
        yield return new WaitForSeconds(0.2f);
        //klar
        heroController.verticalSpeed = 150;
        flyingHitObjectsSpawn.spawninvterval = 0.3f;
        flyingHitObjectsMovement.Speed = 10;
        heroController.rotationdown = -45;
        heroController.rotationup = 45;
        pvpController.verticalSpeed = 150;
        pvpController.rotationdown = -45;
        pvpController.rotationup = 45;
        Debug.Log("Slow ended");
    }

    //Ändrar alla nummer till standard när spelet börjar
    private void Start()
    {
        Debug.Log("Värden återställda");
        heroController.verticalSpeed = 150;
        flyingHitObjectsSpawn.spawninvterval = 0.3f;
        flyingHitObjectsMovement.Speed = 10;
        heroController.rotationdown = -45;
        heroController.rotationup = 45;
        pvpController.verticalSpeed = 150;
        pvpController.rotationdown = -45;
        pvpController.rotationup = 45;
        collisions.powerupslow = false;
        collisions.powerupdouble = false;
        collisions.powerupshield = false;
        collisions.poweruprepair = false;
    }
}
