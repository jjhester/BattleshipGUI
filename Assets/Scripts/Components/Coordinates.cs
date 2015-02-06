using UnityEngine;

using System.Collections;

public class Coordinates: MonoBehaviour {
   private string address;
   public void SetName ( byte row, byte column ) {
		this.name = char.ConvertFromUtf32(row + 65) + (column + 1);
   }
	public void SetName (string prefix, byte index) {
		this.name = prefix + index;
	}
//   public override string ToString () {
//	 return name;
//   }
}
