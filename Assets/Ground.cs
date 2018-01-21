

using UnityEngine;

public class Ground : MonoBehaviour {

    public GameObject tilePrefab;
    public GameObject borderPrefab;

    public void AddTile(Vector2Int position) {
        Instantiate(tilePrefab, position, "tile");
    }

    public void AddBorder(Vector2Int position) {
        Instantiate(borderPrefab, position, "border");
    }

    void Instantiate(GameObject prefab, Vector2Int position, string type) {
        var go = Instantiate(prefab);
        go.transform.position = new Vector3(position.x, 0, position.y);
        go.transform.SetParent(transform);
        go.name = string.Format("{0} {1}", type, position);
    }
}