using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintTerrain : MonoBehaviour
{
    [System.Serializable]
    public class SplatHeights
    {
        public int textureIndex;
        public float startingHeight;
        public float endingHeight;
    }

    public SplatHeights[] colorHeights; //set the size of this to the number of texture layers you're adding to the terrain
    TerrainData tdata;

    // Start is called before the first frame update
    void Start()
    {
        tdata = Terrain.activeTerrain.terrainData;
        int yMax = tdata.alphamapHeight;
        int xMax = tdata.alphamapWidth;

        float[,,] splatmapData = new float[xMax,
                                            yMax,
                                            tdata.alphamapLayers];

        for (int y = 0; y < yMax; y++)
        {
            for (int x = 0; x < xMax; x++)
            {
                float terrainHeight = tdata.GetHeight(y, x);
                float[] splat = new float[colorHeights.Length];

                for (int i = 0; i < colorHeights.Length; i++)
                {
                    
                    if ((terrainHeight >= colorHeights[i].startingHeight) && (terrainHeight <= colorHeights[i].endingHeight))
                    {
                        splat[i] = 1;
                    }
                }
                for (int j = 0; j < colorHeights.Length; j++)
                {
                    splatmapData[x, y, j] = splat[j];
                }
            }
        }

        tdata.SetAlphamaps(0, 0, splatmapData);
    }


}
