using System;
using Newtonsoft.Json;

namespace AedOpenDataApiWrapper
{
#pragma warning disable CS0659 // 型は Object.Equals(object o) をオーバーライドしますが、Object.GetHashCode() をオーバーライドしません
	/// <summary>
	/// 国
	/// </summary>
	public sealed class Country : IEquatable<Country>
#pragma warning restore CS0659 // 型は Object.Equals(object o) をオーバーライドしますが、Object.GetHashCode() をオーバーライドしません
	{
		/// <summary>
		/// 国コード
		/// </summary>
		[JsonProperty("Country")]
		public string CountryCode { get; set; }

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
		bool IEquatable<Country>.Equals(Country other)
		{
			return this.CountryCode == other.CountryCode;
		}

		/// <summary>
		/// 文字列表現を取得します。
		/// </summary>
		public override string ToString()
		{
			return "{" +
				$"{nameof(CountryCode)}={CountryCode}" + 
				"}";
		}
	}
}
