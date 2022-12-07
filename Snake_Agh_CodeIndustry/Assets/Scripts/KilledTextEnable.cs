using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledTextEnable : MonoBehaviour
{
    public GameObject killedUI;

    public IEnumerator killed()
    {
        yield return new WaitForSeconds(1f);
        killedUI.SetActive(false);
    }

}
