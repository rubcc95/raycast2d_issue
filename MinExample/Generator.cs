using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float size;
    public int width, height;
    public GameObject item;
    public static int itemId;

    //it spawns a bunch of "item" next to the other
    private void Awake()
    {
        //items should ignore himself collider. Anyway I've this option set at my project settings, just to remember you because it's might be part of the issue
        Physics2D.queriesStartInColliders = false;

        SearchAround.size = size;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Instantiate(
                    item,
                    new Vector3(size * (((float)(width - 1) / 2f) - i), size * (((float)(height - 1) / 2f) - j)),
                    Quaternion.identity
                );

                //this var names the items at their Awake()
                itemId++;
            }
        }
    }
}
