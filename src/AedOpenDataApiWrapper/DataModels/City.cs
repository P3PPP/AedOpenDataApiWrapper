using System;
using Newtonsoft.Json;

namespace AedOpenDataApiWrapper
{
#pragma warning disable CS0659 // 型は Object.Equals(object o) をオーバーライドしますが、Object.GetHashCode() をオーバーライドしません
	/// <summary>
	/// 市区町村
	/// </summary>
	public sealed class City : IEquatable<City>
#pragma warning restore CS0659 // 型は Object.Equals(object o) をオーバーライドしますが、Object.GetHashCode() をオーバーライドしません
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

		/// <summary>
		/// 指定のオブジェクトが現在のオブジェクトと等しいかどうかを判断します。
		/// </summary>
		/// <param name="obj">比較するオブジェクト</param>
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

		/// <summary>
		/// 指定のオブジェクトが現在のオブジェクトと等しいかどうかを判断します。
		/// </summary>
		/// <param name="other">比較するオブジェクト</param>
		bool IEquatable<City>.Equals(City other)
		{
			return this.PerfectureName == other.PerfectureName &&
				this.CityName == other.CityName &&
				this.Count == other.Count;
		}

		/// <summary>
		/// 文字列表現を取得します。
		/// </summary>
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
