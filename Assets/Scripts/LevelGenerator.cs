using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator: MonoBehaviour
{
    public Texture2D mapTexture;
    public PixelToObject[] pixelColorMappings;
    private Color pixelColor;

    private void Start()
    {
        GenerateLevel();

    }

    void GenerateLevel()
    {
        //scan whole Texture and get positions of objects
        for(int x = 0; x <mapTexture.width; x++)
        {
            for (int y = 0; y < mapTexture.height; y++)
            {
                GenerateObject(x, y);

            }
        }
    }

    void GenerateObject(int x,int y)
    {
        //Read Pixel Color
        pixelColor = mapTexture.GetPixel(x, y);
        if(pixelColor.a ==0)
        {
            //do nothing
            return;
        }
        foreach (PixelToObject pixelColorMapping in pixelColorMappings)
        {
            //Scan pixelColorMappings array for Matching color mapping
            if(pixelColorMapping.pixelColor.Equals (pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(pixelColorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
