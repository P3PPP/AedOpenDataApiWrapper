using Newtonsoft.Json;

namespace AedOpenDataApiWrapper
{
	public class City
	{
		/// <summary>
		/// 都道府県名
		/// </summary>
		[JsonProperty("Perfecture")]
		public string PerfectureName { get; set; }

		/// <summary>
		/// 市区町村名
		/// </summary>
		[JsonProperty("City")]
		public string CityName { get; set; }

		/// <summary>
		/// AED登録数
		/// </summary>
		[JsonProperty("CNT")]
		public int Count { get; set; }
    }
}
