using UnityEngine;
using System.Collections;

[System.Serializable]
public class ZabytkiData
{
	/*public string nazwa_zb;
	public string opis_zabytku;
	public Sprite zdjecie_zabytku;
	[Range(1.0f, 5.0f)]
	public float ocena_zabytku;*/
	public string Nazwa_zb{ get; set; }
	public string Opis_zb{ get; set; }
	public Sprite Zdjecie_zb{ get; set; }
	public float Ocena_zb{ get; set; }


	public ZabytkiData(
		string nazwa = "Brak nazwy",
		string opis = "Brak opisu",
		Sprite zdjecie = null,
		float ocena = 0.0f)
	{
		Nazwa_zb = nazwa;
		Opis_zb = opis;
		Zdjecie_zb = zdjecie;
		Ocena_zb = ocena;
	}
}