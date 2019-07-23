# NoiseMaps-Unity

Noise generated terrains in Unity. Using this is as simple as cloning the repository into your project and attaching each script to a Terrain Game object. Each script will modify the terrain it is assigned to.

## perlinMap.cs
Generates a Terrain using Perlin noise.
#### Enable Terraces
Switches from an exponential function to a rounding function to change the shape of the generated terrain, creates flatter land
#### Debug Mode
Allows the user to adjust the Width, Height, Depth, Scale, Power and Terrace Factor values in play mode. Utitilzes the Update method to regenerate the terrain each frame. **Extremely inefficient, novice users should leave this option unchecked**

## paintTerrain.cs
Uses the array of Terrain Layers assigned to the Terrain to try and blend them based on the starting and ending heights defined by the user.
#### Debug Mode
Allows the user to adjust the starting and ending heights in play mode to customize texture blending. **Extremely inefficient, novice users should leave this option unchecked**
