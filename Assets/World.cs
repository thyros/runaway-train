
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public AboveCamera mainCamera;
    public Ground ground;
    public OffsetPicker offsetPicker;
    public Character player;
    public GameObject npcPrefab;

    public List<Character> npcs;

    [HideInInspector]
    public int movesLeft = 10;

    public Level level;

    void Start()
    {
        CreateWorld(level.level);
        movesLeft = level.movesLeft;

        PickOffset(player);
    }

    void CreateWorld(Texture2D level)
    {
        for (int y = 0; y < level.height; ++y)
        {
            for (int x = 0; x < level.width; ++x)
            {
                var pixel = level.GetPixel(x, y);
                var position = new Vector2Int(x, y);
                if (pixel == Color.green)
                {
                    ground.AddTile(position);
                }
                else if (pixel == Color.blue)
                {
                    ground.AddTile(position);
                    player.SetPosition(position);
                    Debug.Log(string.Format("Spawning player at {0}", position));
                }
                else if (pixel == Color.red)
                {
                    ground.AddBorder(position);
                }
                else if (pixel == Color.black)
                {
                    ground.AddTile(position);
                    var npc = Instantiate(npcPrefab, new Vector3(x, 0, y), Quaternion.identity);
                    npc.transform.SetParent(transform);
                    var character = npc.GetComponent<Character>();
                    character.SetPosition(position);
                    character.Move(new Vector2Int(0, 1));

                    npcs.Add(character);
                }
            }
        }
    }

    void PickOffset(Character player)
    {
        var position = player.nextPosition;
        bool[] states = {IsGround(position + new Vector2Int(-1,  1)),
                         IsGround(position + new Vector2Int( 0,  1)),
                         IsGround(position + new Vector2Int( 1,  1)),
                         IsGround(position + new Vector2Int(-1,  0)),
                         IsGround(position + new Vector2Int( 0,  0)),
                         IsGround(position + new Vector2Int( 1,  0)),
                         IsGround(position + new Vector2Int(-1, -1)),
                         IsGround(position + new Vector2Int( 0, -1)),
                         IsGround(position + new Vector2Int( 1, -1))};

        offsetPicker.Show(player.nextPosition, states);
    }

    void OffsetSelected(Vector2Int offset)
    {
        player.Move(offset);
        PickOffset(player);

        var yOffset = mainCamera.offset.y;
        mainCamera.offset = new Vector3(player.velocity.x, yOffset, player.velocity.y);

        foreach(var npc in npcs) {
            npc.Move(new Vector2Int());
        }

        --movesLeft;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var offset = hit.collider.GetComponent<Offset>();
                if (offset != null)
                {
                    OffsetSelected(offset.offset);
                }
            }
        }
    }

    bool IsGround(Vector2Int position) {
        return level.level.GetPixel(position.x, position.y) == Color.green;
    }
}