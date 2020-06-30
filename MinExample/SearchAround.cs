using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchAround : MonoBehaviour
{
    public static float size;

    private static Direction
        _left = new Direction(Vector2.left, "left"),
        _right = new Direction(Vector2.right, "right"),
        _up = new Direction(Vector2.up, "up"),
        _down = new Direction(Vector2.down, "down");

    private void Awake()
    {
        name = Generator.itemId.ToString();
    }

    private void Start()
    {
        //z localScale isn't part of the issue. with localScale = new Vector3(size, size, size) issue keeps there :(
        transform.localScale = new Vector2(size, size);
        GetNeighbour(_left);
        GetNeighbour(_right);
        GetNeighbour(_up);
        GetNeighbour(_down);
    }

    //get the collision at a direction and prints colliders name
    //ignores himself collision becauseof
    private void GetNeighbour(Direction dir)
    {
        //all layersMask, raycast distance is setted at the size because we should need more to get some item
        var col = Physics2D.Raycast(transform.position, dir.vector, size).collider;
        if (col == null) Debug.Log(name + " doesn't collision at " + dir.name);
        else Debug.Log(name + " collisions with " + col.gameObject.name + " at " + dir.name);
    }

    private struct Direction
    {
        public Direction(Vector2 vector, string name)
        {
            this.vector = vector;
            this.name = name;
        }
        public Vector2 vector;
        public string name;
    }
}
