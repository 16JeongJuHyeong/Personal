using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Text : MonoBehaviour
{
    public Special_Target_Action special;
    // Start is called before the first frame update
    void Start()
    {
        special = this.transform.parent.gameObject.GetComponent<Special_Target_Action>();
    }

    // Update is called once per frame
    void Update()
    {
        if (special.NotInAction)
            this.gameObject.SetActive(false);
    }
}
