using UnityEngine;
using System.Collections;

public class perlinMap : MonoBehaviour
{
    public int width = 500;
    public int height = 500;
    public int depth = 20; //how high any mountains will go

    public float scale = 20.0F; //how varied the terrain will be. Lower numbers result in flatness
    public int power = 1; //an exponent that will be used to create valleys; increase for depth

    private Terrain terrain;
    private TerrainData tdata;


    public void Start()
    {
        terrain = GetComponent<Terrain>();
        tdata = terrain.terrainData;
        generateTerrain();
    }

    void generateTerrain()
    {
        tdata.heightmapResolution = width + 1;
        tdata.size = new Vector3(width, depth, height);
        
        tdata.SetHeights(0, 0, CalcHeights());
    }

    float[,] CalcHeights()
    {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float e = 1f * CalcNoiseForPixel(1.0f * x, 1.0f * y)
                                + 0.5f * CalcNoiseForPixel(2.0f * x, 2.0f * y)
                                + 0.25f * CalcNoiseForPixel(4.0f * x, 2.0f * y);
                heights[x, y] = Mathf.Pow(e, power);
            }
        }
        return heights;
    }

    float CalcNoiseForPixel(float x, float y)
    {
        float xCoord = x / width * scale;
        float yCoord = y / height * scale;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
