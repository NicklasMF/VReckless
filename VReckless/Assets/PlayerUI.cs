using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField] Text playernameTxt;
    [SerializeField] Text playerscoreTxt;
    [SerializeField] Text pressToPlayTxt;

    void Awake () {
        playernameTxt.text = "Yeah";
        playerscoreTxt.text = "0";
        pressToPlayTxt.text = "Tryk på en tast";
        playernameTxt.gameObject.SetActive(false);
        playerscoreTxt.gameObject.SetActive(false);
        pressToPlayTxt.gameObject.SetActive(true);
    }

    public void Setup() {
        playernameTxt.gameObject.SetActive(true);
        playerscoreTxt.gameObject.SetActive(true);
        pressToPlayTxt.gameObject.SetActive(false);
    }

    public void Reconnect() {
        playernameTxt.gameObject.SetActive(false);
        playerscoreTxt.gameObject.SetActive(false);
        pressToPlayTxt.gameObject.SetActive(true);
        pressToPlayTxt.text = "Reconnecting";
    }
}
