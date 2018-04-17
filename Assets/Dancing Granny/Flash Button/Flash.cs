using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
public class Flash : MonoBehaviour {

    public UnityEngine.UI.Image ButtonImage;
    public UnityEngine.UI.Image CircleImage;
    private bool toggle;
    private Color originalInnerColor;
    private Color originalCircleColor;

    // Use this for initialization
	void Start () {
        originalInnerColor = ButtonImage.color;
        originalCircleColor = CircleImage.color;
	}
	

    public void ToggleFlash()
    {
        toggle = !toggle;
        CameraDevice.Instance.SetFlashTorchMode(toggle);

        /*if (toggle)
        {
            ButtonImage.color = originalCircleColor;
            CircleImage.color = originalInnerColor;
        }
        else {
            ButtonImage.color = originalInnerColor;
            CircleImage.color = originalCircleColor;
        }*/
    }
}
