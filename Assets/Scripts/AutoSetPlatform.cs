using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AutoSetPlatform : MonoBehaviour
{
#if UNITY_EDITOR
	public Vector2 size = default;

	private void OnDrawGizmos()
	{
		var col = transform.Find("volume").GetComponent<BoxCollider2D>();
		if (size == default)
		{
			size = col.size;
			size = new(size.x, size.y + 0.1f);
		}

		if (col.size == size || size == default)
			return;

		var floor = transform.Find("floor").GetComponent<BoxCollider2D>();
		var spr = GetComponentsInChildren<SpriteRenderer>();
		spr = spr.Where(s => s.drawMode == SpriteDrawMode.Tiled).ToArray();

		floor.size = new(size.x, 0.1f);
		floor.transform.localPosition = new(0, size.y / 2f, 0);
		col.size = new(size.x, size.y - 0.1f);
		foreach (var s in spr)
		{
			s.size = size;
		}
	}
#endif
}
