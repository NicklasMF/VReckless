using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class MyPlayerController : MonoBehaviour {

    float speed = 5f;
    public InputDevice inputDevice;

    void Start() {

    }

    void Update() {
        if (inputDevice != null) {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime * inputDevice.LeftStickY));
            transform.Translate(new Vector3(speed * Time.deltaTime * inputDevice.LeftStickX, 0, 0));
        }
    }
}
