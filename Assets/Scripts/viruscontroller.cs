using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viruscontroller : MonoBehaviour
{
    private int selectedVirus;
    public GameObject Camera;
    public GameObject thanosdmg;
    public Texture damage;
    public static bool hasvirus = false;
    
    // Start is called before the first frame update
    void Start()
    {
        hasvirus = false;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "virus" && hasvirus == false)
        {
            PlayerPrefs.SetInt("viruses", PlayerPrefs.GetInt("viruses", 0) + 1);
            hasvirus = true;
            thanosdmg.GetComponent<Renderer>().material.mainTexture = damage;
            Destroy(collider.gameObject);
            selectedVirus = Random.Range(0, 11);
            Debug.Log(selectedVirus);
            if (selectedVirus == 0)
            {
                Camera.AddComponent<CameraFilterPack_AAA_SuperComputer>();
            } else if (selectedVirus == 1)
            {
                Camera.AddComponent<CameraFilterPack_Distortion_Dream>();
            }
            else if (selectedVirus == 2)
            {
                Camera.AddComponent<CameraFilterPack_Distortion_Heat>();
            }
            else if (selectedVirus == 3)
            {
                Camera.AddComponent<CameraFilterPack_FX_InverChromiLum>();
            }
            else if (selectedVirus == 4)
            {
                Camera.AddComponent<CameraFilterPack_Gradients_NeonGradient>();
            }
            else if (selectedVirus == 5)
            {
                Time.timeScale = 2f;
                guiController.scoreHit = 0; 
            }
            else if (selectedVirus == 6)
            {
                Camera.AddComponent<CameraFilterPack_Pixel_Pixelisation>();
            }
            else if (selectedVirus == 7)
            {
                Camera.AddComponent<CameraFilterPack_Oculus_NightVision2>();
            }
            else if (selectedVirus == 8)
            {
                Camera.AddComponent<CameraFilterPack_TV_Old_Movie>();
            }
            else if (selectedVirus == 9)
            {
                flyingHitObjectsMovement.Speed =+ 5;
            }
            else if (selectedVirus == 10)
            {
                guiController.scoreHit = -10;
            }
            else if (selectedVirus == 11)
            {
                heroController.verticalSpeed = 60;
            }
            else if (selectedVirus == 12)
            {
                Time.timeScale = 1.5f;
            }



        }
    }
}
 
