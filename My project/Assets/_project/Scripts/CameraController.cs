using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour {

    enum Mode {Fixed, Relative, Follow}
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI modeText;
    private Vector3 offset;
    private Mode mode;

    void Start() {
        mode = Mode.Relative;
        modeText.text = "Relative";
        offset = new Vector3(5, 10, 0);
    }

    void LateUpdate() {
        if (mode == Mode.Relative) {
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform);
        } else if (mode == Mode.Fixed) {
            transform.LookAt(player.transform);
        } else if (mode == Mode.Follow) {
            transform.position = player.transform.position - player.transform.forward * 5f;
            transform.LookAt(player.transform);
            transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        }
    }

    public void ChangeViewMode() {
        if (mode == Mode.Relative) {
            mode = Mode.Fixed;
            modeText.text = "Fixed";
            transform.position = new Vector3(0, 10, 0);
        } else if (mode == Mode.Fixed) {
            mode = Mode.Follow;
            modeText.text = "Follow";
        } else if (mode == Mode.Follow) {
            mode = Mode.Relative;
            modeText.text = "Relative";
        }
    }
}
