using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class GameController : MonoBehaviour {

    List<string> ActiveDevices = new List<string>();
    InputDevice previousInputDevice;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerUITransform;

    void Start() {
        InputManager.OnDeviceAttached += inputDevice => Debug.Log("Attached: " + inputDevice.GUID.ToString());
        InputManager.OnDeviceDetached += DetachedDevice;
    }

    void Update() {
        var currentInputDevice = InputManager.ActiveDevice;
        if (currentInputDevice != previousInputDevice) {
            previousInputDevice = InputManager.ActiveDevice;
            print("Aktiv: "+currentInputDevice.GUID.ToString());
            if (currentInputDevice.DeviceStyle.ToString() != "Unknown") {
                for (int i = 0; i < ActiveDevices.Count; i++) {
                    InputDevice device = InputManager.Devices[i];
                    if (currentInputDevice.GUID.ToString() == ActiveDevices[i]) {
                        return;
                    }
                }
                ActiveDevices.Add(currentInputDevice.GUID.ToString());
                playerUITransform.GetChild(ActiveDevices.Count - 1).GetComponent<PlayerUI>().Setup();
                GameObject player = Instantiate(playerPrefab);
                player.GetComponent<MyPlayerController>().inputDevice = currentInputDevice;

            } else {
                print(currentInputDevice.DeviceStyle.ToString() + " blev ikke godkendt");
            }
        }
    }

    void DetachedDevice(InputDevice _device) {
        print(_device.GUID.ToString() + " is out");
        for (int i = 0; i < ActiveDevices.Count; i++) {
            if (_device.GUID.ToString() == ActiveDevices[i]) {
                ActiveDevices.Remove(_device.GUID.ToString());
                playerUITransform.GetChild(i).GetComponent<PlayerUI>().Reconnect();


                return;
            }
        }
    }
}
