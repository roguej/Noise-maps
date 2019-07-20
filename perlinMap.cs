using UnityEngine;
using System.Collections;

public class perlinMap : MonoBehaviour
{
    public int pixelWidth;
    public int pixelHeight;

    public float xOrigin;
    public float yOrigin;

    public float scale = 1.0F;

    private Texture2D noiseTexture;
    private Color[] pixels;
    private Renderer rend;
    

    public void Start()
    {
        rend = GetComponent<Renderer>();

        // Set up the texture and a Color array to hold pixels during processing.
        noiseTexture = new Texture2D(pixelWidth, pixelHeight);
        pixels = new Color[noiseTexture.width * noiseTexture.height];
        rend.material.mainTexture = noiseTexture;
        CalcNoise();
    }

        void CalcNoise()
    {
        // For each pixel in the texture...
        float y = 0.0F;

        while (y < noiseTexture.height)
        {
            float x = 0.0F;
            while (x < noiseTexture.width)
            {
                float xCoord = xOrigin + x / noiseTexture.width * scale;
                float yCoord = yOrigin + y / noiseTexture.height * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                pixels[(int)y * noiseTexture.width + (int)x] = new Color(sample, sample, sample);
                x++;
            }
            y++;
        }

        // Copy the pixel data to the texture and load it into the GPU.
        noiseTexture.SetPixels(pixels);
        noiseTexture.Apply();
    }
}
