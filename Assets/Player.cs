using UnityEngine;

public class Player : MonoBehaviour {

    public Vector2Int position;
    [Range (.1f, 5)]
    public float speed = 1;


    void Update() {
        var targetPosition = new Vector3(position.x, 0, position.y);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

}
