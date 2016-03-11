using System;
using Newtonsoft.Json;

namespace AedOpenDataApiWrapper
{
	/// <summary>
	/// 市区町村
	/// </summary>
	public sealed class City : IEquatable<City>
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

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null))
				return false;

			if (object.ReferenceEquals(this, obj))
				return true;

			if (this.GetType() != obj.GetType())
				return false;

			return this.Equals(obj as Country);
		}

		bool IEquatable<City>.Equals(City other)
		{
			return this.PerfectureName == other.PerfectureName &&
				this.CityName == other.CityName &&
				this.Count == other.Count;
		}

		public override string ToString()
		{
			return "{" +
				$"{nameof(PerfectureName)}={PerfectureName}, " +
				$"{nameof(CityName)}={CityName}, " +
				$"{nameof(Count)}={Count}" +
				"}";
		}
	}
}
