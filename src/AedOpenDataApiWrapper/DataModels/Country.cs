using System;
using Newtonsoft.Json;

namespace AedOpenDataApiWrapper
{
	/// <summary>
	/// 国
	/// </summary>
	public sealed class Country : IEquatable<Country>
	{
		/// <summary>
		/// 国コード
		/// </summary>
		[JsonProperty("Country")]
		public string CountryCode { get; set; }

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

		bool IEquatable<Country>.Equals(Country other)
		{
			return this.CountryCode == other.CountryCode;
		}

		public override string ToString()
		{
			return "{" +
				$"{{nameof(CountryCode)}={CountryCode}}" + 
				"}";
		}
	}
}
