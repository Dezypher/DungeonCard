using UnityEngine;
using System.Collections;

public class MapHandler : MonoBehaviour {

	public class Tile	{
		public int type;

		public Tile(int type){
			this.type = type;
		}
	}

	public class Map {
		private Tile[,] tileMap;

		public void instantiateBlank(int width, int height){
			tileMap = new Tile[width, height];

			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					tileMap [x, y] = new Tile (0);
				}
			}
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
	}

	public Map map;

	void Start () {
		map = new Map ();
		map.instantiateBlank (20, 20);
	}

	void Update () {
		
	}
}
