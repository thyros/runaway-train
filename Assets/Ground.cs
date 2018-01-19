

using UnityEngine;

public class Ground : MonoBehaviour {

    public int width;
    public int depth;

    public GameObject tilePrefab;

    void Start() {
        var size = tilePrefab.GetComponent<Renderer>().bounds.size;
        var offset = new Vector3(-(width - 1) / 2 * size.x, 0, 0);

        Debug.Log(string.Format("Creating ground. Offset: {0} tile size: {1}", offset, size));

        for (int z = 0; z < depth; ++z) {
            for (int x = 0; x < width; ++x) {
                var tile = Instantiate(tilePrefab);
                tile.transform.position = offset + new Vector3(x * size.x, 0, z * size.z);
                tile.transform.SetParent(transform);
                tile.name = string.Format("Tile [{0}, {1}]", x, z);
            }
        }
    }
}