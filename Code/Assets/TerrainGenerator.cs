using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 100;

    public int width = 256;
    public int height = 256;

    public float scale = 1f;




    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain (TerrainData terrainData) {
        terrainData.heightmapResolution = width + 1;


        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights () {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++) {
             for (int y = 0; y < height; y++) {
                heights[x, y] = CalculateHeight(x, y);
             }
        }

        return heights;
    }

    float CalculateHeight (int x, int y) {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        return Mathf.PerlinNoise(xCoord, yCoord) * ((Mathf.Pow(xCoord, 4) + Mathf.Pow(yCoord, 4)) / 10);
    }
}
