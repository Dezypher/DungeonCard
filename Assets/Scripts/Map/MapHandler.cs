using UnityEngine;
using System.Collections;

public class MapHandler : MonoBehaviour {

	public Map map;

	private MapGenerator mapGenerator;

	void Start () {
		map = new Map ();
		map.instantiateBlank (20, 20);

		mapGenerator = GetComponent<MapGenerator> ();

		// Make premade dungeon

		map.setTile (10, 10, new Tile (1));
		map.setTile (11, 10, new Tile (1));
		map.setTile (12, 10, new Tile (1));
		map.setTile (13, 10, new Tile (1));
		map.setTile (14, 10, new Tile (1));
		map.setTile (14, 11, new Tile (1));
		map.setTile (14, 12, new Tile (1));
		map.setTile (15, 11, new Tile (1));
		map.setTile (15, 12, new Tile (1));
		map.setTile (15, 13, new Tile (1));
		map.setTile (15, 14, new Tile (1));
		map.setTile (15, 15, new Tile (1));
		map.setTile (15, 16, new Tile (1));
		map.setSpawn (10, 10);

		mapGenerator.Generate (map);
	}
}

public class Tile	{
	public int type;

	public Tile(int type){
		this.type = type;
	}
}

public class Map {
	public int width;
	public int height;

	public int spawnPointX;
	public int spawnPointY;

	private Tile[,] tileMap;

	public void instantiateBlank(int width, int height){
		tileMap = new Tile[width, height];
		this.width = width;
		this.height = height;

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				tileMap [x, y] = new Tile (0);
			}
		}
	}

	public void setSpawn(int x, int y){
		spawnPointX = x;
		spawnPointY = y;
	}

	public void setTileMap(Tile[,] tileMap){
		this.tileMap = tileMap;
	}

	public Tile getTile(int x, int y){
		return tileMap [x, y];
	}

	public void setTile(int x, int y, Tile tile){
		tileMap [x, y] = tile;
	}

	public void setTile(int x, int y, int type){
		tileMap [x, y].type = type;
	}


}