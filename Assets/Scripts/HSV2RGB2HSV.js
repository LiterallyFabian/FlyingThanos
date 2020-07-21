using UnityEngine;

VERSION B in JS ...two HSV 2 RGB functions, to and from, dont put in a plugins folder, make it a static function some place if you need to access it in all scripts:


//CHANGE COLORS FROM RGB TO HSV:				
function Hue(H: float): Vector3 {
	var R: float = Mathf.Abs(H * 6 - 3) - 1;
	var G: float = 2 - Mathf.Abs(H * 6 - 2);
	var B: float = 2 - Mathf.Abs(H * 6 - 4);
	return Vector3(Mathf.Clamp01(R), Mathf.Clamp01(G), Mathf.Clamp01(B));
}

function HSVtoRGB(HSV: Vector3): Vector4 {

	var H = Hue(HSV.x);
	H = Vector3(H.x - 1, H.y - 1, H.z - 1) * HSV.y;
	H = Vector3(H.x + 1, H.y + 1, H.z + 1) * HSV.z;
	return Vector4(H.x, H.y, H.z, 1);
}

function RGBtoHSV(RGB: Vector3): Vector4 {
	var HSV: Vector3 = Vector3.zero;
	HSV.z = Mathf.Max(RGB.x, Mathf.Max(RGB.y, RGB.z));
	var M: float = Mathf.Min(RGB.x, Mathf.Min(RGB.y, RGB.z));
	var C: float = HSV.z - M;
	if (C != 0) {
		HSV.y = C / HSV.z;
		var Delta: Vector3 = Vector3(
			(HSV.z - RGB.x) / C,
			(HSV.z - RGB.y) / C,
			(HSV.z - RGB.z) / C);
		var del = Delta;
		Delta.x -= del.z;
		Delta.y -= del.x;
		Delta.z -= del.y;
		Delta.x += 2.0;
		Delta.y += 4.0;
		if (RGB.x >= HSV.z) { HSV.x = Delta.z; }
		else if (RGB.y >= HSV.z) { HSV.x = Delta.x; }
		else { HSV.x = Delta.y; }
		HSV.x = (HSV.x / 6.0) % 1.0;
	}
	return Vector4(HSV.x, HSV.y, HSV.z, 1);
}