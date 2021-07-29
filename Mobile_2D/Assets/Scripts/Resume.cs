using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause_Button;

    public void Set_Resume()
    {
        Pause_Button.GetComponent<Button>().interactable = true;
        this.transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
