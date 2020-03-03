using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Sitter på GameObject i game, hanterar good luck fade effekten

public class goodluckFade : MonoBehaviour
{
    public static bool fadingspeed;
    public Text timertext;
    public Image m_Image;
    public Image timer;

    public Image speedmodeimage;
    bool m_Fading;

    bool speedfade;
    public GameObject gears;

    void Update()
    {


        if (m_Fading == true)
        {
            m_Image.CrossFadeAlpha(1, 0.34f, false);
        }

        if (m_Fading == false)
        {
            m_Image.CrossFadeAlpha(0, 0.04f, false);
        }
            if (speedfade == true)
        {
            speedmodeimage.CrossFadeAlpha(1, 0.2f, false);
        }

        if (speedfade == false)
        {
            speedmodeimage.CrossFadeAlpha(0, 0.09f, false);
        }
        	if(guiController.sharpmode == false){
		 gears.SetActive(false);
	} else if (guiController.sharpmode == true){
		gears.SetActive(true);
	}

    }

    void Start()
    { if (guiController.speedmode == false && guiController.newmode == false)
		{
        StartCoroutine(goodluck());
        m_Image.CrossFadeAlpha(0, 0, false);
        speedmodeimage.CrossFadeAlpha(0, 0, false);
        Cursor.visible = false;
    } 
		if(guiController.speedmode == true)
		{
        StartCoroutine(speedluck());
        speedmodeimage.CrossFadeAlpha(0, 0, false);
        m_Image.CrossFadeAlpha(0, 0, false);
        Cursor.visible = false;
    } 
    if (guiController.sharpmode == true){
        Cursor.visible = false;
        timer.CrossFadeAlpha(0, 0, false);
        timertext.CrossFadeAlpha(0, 0, false);
    }

    }


    IEnumerator goodluck()
    {

        guiController.lifes = 3;
        if (guiController.pvpmode == true)
        {
            heroController.verticalSpeed = 130;
            heroController.horizontalSpeed = 90;
        }
        else
        {
            heroController.verticalSpeed = 150;
        }
        heroController.rotationdown = -35;
        heroController.rotationup = 35;
        pvpController.verticalSpeed = 130;
        pvpController.horizontalSpeed = 90;
        pvpController.rotationdown = -45;
        pvpController.rotationup = 45;
        flyingHitObjectsSpawn.spawninvterval = 0.3f;
        flyingHitObjectsMovement.Speed = 9;
        backgroundMovement.backgroundSpeedBack = 0.1f;
        backgroundMovement.backgroundSpeedFront = 0.32f;
        backgroundMovement.backgroundSpeedMiddle = 0.23f;
        yield return new WaitForSeconds(2.8f);
 
        m_Fading = true;
        flyingHitObjectsMovement.Speed = 4;
        heroController.verticalSpeed = 40;
        heroController.rotationdown = -25;
        heroController.rotationup = 25;
        pvpController.verticalSpeed = 40;
        pvpController.rotationdown = -25;
        pvpController.rotationup = 25;
        flyingHitObjectsSpawn.spawninvterval = 1f;
        
        yield return new WaitForSeconds(1.45f);
        m_Fading = false;
        if (guiController.pvpmode == true)
        {
            heroController.verticalSpeed = 130;
            heroController.horizontalSpeed = 90;
        }
        else
        {
            heroController.verticalSpeed = 150;
        }
        flyingHitObjectsSpawn.spawninvterval = 0.3f;
        flyingHitObjectsMovement.Speed = 9;
        heroController.rotationdown = -37;
        heroController.rotationup = 37;
        pvpController.verticalSpeed = 130;
        pvpController.horizontalSpeed = 90;
        pvpController.rotationdown = -35;
        pvpController.rotationup = 35;
        yield return new WaitForSeconds(0.1f);
        flyingHitObjectsMovement.Speed = 10;
    }
        IEnumerator speedluck()
    {
        backgroundMovement.backgroundSpeedBack = 0.1f;
        backgroundMovement.backgroundSpeedFront = 0.32f;
        backgroundMovement.backgroundSpeedMiddle = 0.23f;
        yield return new WaitForSeconds(2.8f);
        speedfade = true;
        fadingspeed = true;
        flyingHitObjectsMovement.Speed = 4;
        heroController.verticalSpeed = 40;
        heroController.rotationdown = -25;
        heroController.rotationup = 25;
        flyingHitObjectsSpawn.spawninvterval = 1f;
        
        yield return new WaitForSeconds(1.45f);
        speedfade = false;
        heroController.verticalSpeed = 200;
        backgroundMovement.backgroundSpeedBack = 0.3f;
        backgroundMovement.backgroundSpeedFront = 0.96f;
        backgroundMovement.backgroundSpeedMiddle = 0.69f;
        flyingHitObjectsSpawn.spawninvterval = 0.24f;
        flyingHitObjectsMovement.Speed = 12;
        heroController.rotationdown = -35;
        heroController.rotationup = 35;
        yield return new WaitForSeconds(0.1f);
        fadingspeed = false;
        flyingHitObjectsMovement.Speed = 14;
    }
}