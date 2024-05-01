using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public static class PerlinGenerator
{
    public static float[,] GeneratePerlin(int width, int height, float scale, int seed)
    {
        if (seed == 0) seed = Random.Range(int.MinValue, int.MaxValue);
        Random.State state = Random.state; // Save Random's state
        Random.InitState(seed); // Seed Random's state
        float randomX = Random.Range(-10000 * scale, 10000 * scale);
        float randomY = Random.Range(-10000 * scale, 10000 * scale);
        Random.state = state; // Restore Random's state
        float[,] perlin = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = x / (width * scale / 10) + randomX;
                float yCoord = y / (height * scale / 10) + randomY;
                perlin[x, y] = Mathf.PerlinNoise(xCoord, yCoord);
            }
        }
        return perlin;
    }
}