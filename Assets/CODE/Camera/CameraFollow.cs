using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    public void LateUpdate() {
        if (target != null) {
            transform.position = new Vector3(target.position.x, target.position.y, -10f);
        }
    }
}
