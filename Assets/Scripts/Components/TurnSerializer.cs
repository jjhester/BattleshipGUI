using System;
using System.Collections;
using UnityEngine;
using FullSerializer;

public class TurnSerializer {
   private static readonly fsSerializer _serializer = new fsSerializer();
   //Generates a JSON string
   public static string Serialize ( Game gameObject ) {
		fsData gameData;
		_serializer.TrySerialize<Game>(gameObject, out gameData).AssertSuccessWithoutWarnings();
		return fsJsonPrinter.CompressedJson(gameData);
   }
   public static Game Deserialize ( string serializedGame ) {
		fsData gameData = fsJsonParser.Parse(serializedGame);
		Game gameObject = null;
		_serializer.TryDeserialize<Game>(gameData, ref gameObject).AssertSuccessWithoutWarnings();
		return gameObject;
   }

}
