using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tooShort : MonoBehaviour
{
    public GameObject tooShortUI;
    
    public IEnumerator tooShortToEat()
    {
        yield return new WaitForSeconds(1f);
        tooShortUI.SetActive(false);
    }
}
