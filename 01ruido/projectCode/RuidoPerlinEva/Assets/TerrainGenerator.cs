using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 20;
    public int width = 256;
    public int height = 256;

    public float scale = 20;

    public float offsetX = 100f;
    public float offsetY = 100f;

    void Start()
    {
        offsetX = Random.Range(0f, 999f);
        offsetY = Random.Range(0f, 999f);
    }
   
    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        if (Input.GetKey(KeyCode.LeftArrow)) offsetX += 0.1f;
        if (Input.GetKey(KeyCode.RightArrow)) offsetX -= 0.1f;
       
        if (Input.GetKey(KeyCode.UpArrow)) offsetY += 0.1f;
        if (Input.GetKey(KeyCode.DownArrow)) offsetY -= 0.1f;

        if (Input.GetKey(KeyCode.D)) depth += 1;
        if (Input.GetKey(KeyCode.X) && (depth > 0)) depth -= 1;

        if (Input.GetKey(KeyCode.S)) scale += 0.1f;
        if (Input.GetKey(KeyCode.Z) && (scale > 0)) scale -= 0.1f;
    }

    TerrainData GenerateTerrain (TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights ()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x,y);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
