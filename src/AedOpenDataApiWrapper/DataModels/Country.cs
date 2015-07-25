using Newtonsoft.Json;

namespace AedOpenDataApiWrapper
{
	public class Country
	{
		/// <summary>
		/// 国コード
		/// </summary>
		[JsonProperty("Country")]
		public string CountryCode { get; set; }
	}
}
