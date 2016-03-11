using System;
using Newtonsoft.Json;

namespace AedOpenDataApiWrapper
{
	/// <summary>
	/// 都道府県
	/// </summary>
	public sealed class Perfecture : IEquatable<Perfecture>
	{
		/// <summary>
		/// 都道府県名
		/// </summary>
		[JsonProperty("Perfecture")]
		public string PerfectureName { get; set; }

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

		public bool Equals(Perfecture other)
		{
			return this.PerfectureName == other.PerfectureName &&
				this.Count == other.Count;
		}

		public override string ToString()
		{
			return "{" +
				$"{nameof(PerfectureName)}={PerfectureName}, " +
				$"{nameof(Count)}={Count}" +
				"}";
		}
	}
}
