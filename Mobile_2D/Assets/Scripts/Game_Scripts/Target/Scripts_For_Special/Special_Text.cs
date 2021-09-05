using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Text : MonoBehaviour
{
    public Special_Target_Action special;

    void Start()
    {
        special = this.transform.parent.gameObject.GetComponent<Special_Target_Action>();
    }

    void Update()
    {
        if (special.NotInAction)
            this.gameObject.SetActive(false);
    }
}
