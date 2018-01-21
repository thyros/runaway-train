using UnityEngine;

public class Character : MonoBehaviour {

    public Vector2Int position;
    public Vector2Int nextPosition;

    public Vector2Int velocity;
    [Range (.1f, 5)]
    public float speed = 5;

    public void Move(Vector2Int velocityDelta) {
        velocity += velocityDelta;
        position += velocity;
        nextPosition = position + velocity;
    }

    public void SetPosition(Vector2Int position) {
        this.position = position;
        this.nextPosition = position + this.velocity;
    }

    void Update() {
        var targetPosition = new Vector3(position.x, 0, position.y);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

}
