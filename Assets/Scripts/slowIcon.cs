using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class slowIcon : MonoBehaviour
{
    public Image slowimage;
    bool slowbool;
    public Image doubleimage;
    bool doublebool;
    public Image shieldimage;
    bool shieldbool;

    private void Start()
    {
        slowimage.CrossFadeAlpha(0, 0, false);
        doubleimage.CrossFadeAlpha(0, 0, false);
        shieldimage.CrossFadeAlpha(0, 0, false);
    }

    void Update()
    {

        if (slowbool == true)
        {
            slowimage.CrossFadeAlpha(1, 0.5f, false);
        }

        if (slowbool == false)
        {
            slowimage.CrossFadeAlpha(0, 0.5f, false);
        }
        if (collisions.powerupslow == true)
        {
            StartCoroutine(slowfade());
        }

        if (doublebool == true)
        {
            doubleimage.CrossFadeAlpha(1, 0.5f, false);
        }

        if (doublebool == false)
        {
            doubleimage.CrossFadeAlpha(0, 0.5f, false);
        }
        if (collisions.powerupdouble == true)
        {
            StartCoroutine(doublefade());
        }

        //Shield
        if (shieldbool == true)
        {
            shieldimage.CrossFadeAlpha(1, 0.5f, false);
        }

        if (shieldbool == false)
        {
            shieldimage.CrossFadeAlpha(0, 0.5f, false);
        }
        if (collisions.powerupshield == true)
        {
            StartCoroutine(shieldfade());
        }
    }

    IEnumerator slowfade()
    {
        slowbool = true;
        yield return new WaitForSeconds(6.9f);
        slowbool = false;
    }
    IEnumerator doublefade()
    {
        doublebool = true;
        yield return new WaitForSeconds(4.7f);
        doublebool = false;
    }
    IEnumerator shieldfade()
    {
        shieldbool = true;
        yield return new WaitForSeconds(9.2f);
        shieldbool = false;
    }
}
