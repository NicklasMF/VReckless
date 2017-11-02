using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitController : MonoBehaviour {

    [SerializeField] Text StatusTxt;

	void Start () {
        UnityEngine.XR.XRSettings.showDeviceView = false;

    }
}
