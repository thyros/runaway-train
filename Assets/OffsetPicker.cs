using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPicker : MonoBehaviour
{
    public void Show(Vector2Int position, bool[] states)
    {
        for (int i = 0; i < states.Length; ++i) {
            transform.GetChild(i).GetComponent<Renderer>().material.color = states[i] ? Color.red : Color.green;
        }
        transform.position = new Vector3(position.x, 0, position.y);
    }
}
