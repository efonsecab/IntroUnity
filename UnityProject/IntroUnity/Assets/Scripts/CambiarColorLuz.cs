using UnityEngine;
using System.Collections;

public class CambiarColorLuz : MonoBehaviour
{
    private Light objLightComponent = null;
    // Use this for initialization
    void Start()
    {
        this.objLightComponent = base.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            objLightComponent.color = Color.green;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            objLightComponent.color = Color.white;
        }
    }
}
