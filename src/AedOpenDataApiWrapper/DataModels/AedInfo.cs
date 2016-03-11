using System;
using Newtonsoft.Json;

namespace AedOpenDataApiWrapper
{
	/// <summary>
	/// AED位置情報
	/// </summary>
	public sealed class AedInfo : IEquatable<AedInfo>
	{
		/// <summary>
		/// 距離(m)
		/// </summary>
		[JsonProperty("DIST")]
		public int Distance { get; set; }

		/// <summary>
		/// Id
		/// </summary>
		[JsonProperty("Id")]
		public int Id { get; set; }

		/// <summary>
		/// 場所_地名【名称】
		/// </summary>
		[JsonProperty("LocationName")]
		public string LocationName { get; set; }

		/// <summary>
		/// 構造化住所_都道府県
		/// </summary>
		[JsonProperty("Perfecture")]
		public string Perfecture { get; set; }

		/// <summary>
		/// 構造化住所_市区町村
		/// </summary>
		[JsonProperty("City")]
		public string City { get; set; }

		/// <summary>
		/// 構造化住所_町名
		/// </summary>
		[JsonProperty("AddressArea")]
		public string AddressArea { get; set; }

		/// <summary>
		/// 緯度経度座標系_緯度
		/// </summary>
		[JsonProperty("Latitude")]
		public double Latitude { get; set; }

		/// <summary>
		/// 緯度経度座標系_経度
		/// </summary>
		[JsonProperty("Longitude")]
		public double Longitude { get; set; }

		/// <summary>
		/// 公共設備_ID
		/// </summary>
		[JsonProperty("FacilityId")]
		public string FacilityId { get; set; }

		/// <summary>
		/// 公共設備_名称
		/// </summary>
		[JsonProperty("FacilityName")]
		public string FacilityName { get; set; }

		/// <summary>
		/// 公共設備_設置場所【設置場所】※受付横とか
		/// </summary>
		[JsonProperty("FacilityPlace")]
		public string FacilityPlace { get; set; }

		/// <summary>
		/// 公共設備_利用可能時間【利用可能時間】
		/// </summary>
		[JsonProperty("ScheduleDayType")]
		public string ScheduleDayType { get; set; }

		/// <summary>
		/// 開始時間(将来的に構造変更予定)
		/// </summary>
		[JsonProperty("ScheduleDayStartTime")]
		public string ScheduleDayStartTime { get; set; }

		/// <summary>
		/// 終了時間(将来的に構造変更予定)
		/// </summary>
		[JsonProperty("ScheduleDayEndTime")]
		public string ScheduleDayEndTime { get; set; }

		/// <summary>
		/// 公共設備_建物内外【建物内外】
		/// </summary>
		[JsonProperty("AccessAvailabilityOfPad")]
		public string AccessAvailabilityOfPad { get; set; }

		/// <summary>
		/// 公共設備_利用者【利用制限】
		/// </summary>
		[JsonProperty("FacilityUser")]
		public string FacilityUser { get; set; }

		/// <summary>
		/// 公共設備_写真URL【写真】
		/// </summary>
		[JsonProperty("PhotoOfAedUrl")]
		public string PhotoOfAedUrl { get; set; }

		/// <summary>
		/// 公共設備_ホームページ【ホームページ】
		/// </summary>
		[JsonProperty("Url")]
		public string Url { get; set; }

		/// <summary>
		/// 公共設備_設置者【設置者】
		/// </summary>
		[JsonProperty("FacilityOwner")]
		public string FacilityOwner { get; set; }

		/// <summary>
		/// 公共設備_管理者
		/// </summary>
		[JsonProperty("FacilityOperater")]
		public string FacilityOperater { get; set; }

		/// <summary>
		/// 公共設備_連絡先【連絡先】
		/// </summary>
		[JsonProperty("ContactPoint")]
		public string ContactPoint { get; set; }

		/// <summary>
		/// 連絡先_電話番号
		/// </summary>
		[JsonProperty("ContactTelephone")]
		public string ContactTelephone { get; set; }

		/// <summary>
		/// 連絡先_内線番号
		/// </summary>
		[JsonProperty("ContactExtension")]
		public string ContactExtension { get; set; }

		/// <summary>
		/// 公共設備_補足【補足】
		/// </summary>
		[JsonProperty("FacilityNote")]
		public string FacilityNote { get; set; }

		/// <summary>
		/// AED_パッド種類
		/// </summary>
		[JsonProperty("TypeOfPad")]
		public string TypeOfPad { get; set; }

		/// <summary>
		/// AED_有効期限
		/// </summary>
		[JsonProperty("ExpiryDate")]
		public string ExpiryDate { get; set; }

		/// <summary>
		/// AED_パッド有効期限
		/// </summary>
		[JsonProperty("ExpiryDateOfPads")]
		public string ExpiryDateOfPads { get; set; }

		/// <summary>
		/// AED_バッテリ有効期限
		/// </summary>
		[JsonProperty("ExpiryDateOfBatteries")]
		public string ExpiryDateOfBatteries { get; set; }

		/// <summary>
		/// AED_タイプ
		/// </summary>
		[JsonProperty("TypeOfDefibrillator")]
		public string TypeOfDefibrillator { get; set; }

		/// <summary>
		/// AED_モデルナンバー
		/// </summary>
		[JsonProperty("ModelNumber")]
		public string ModelNumber { get; set; }

		/// <summary>
		/// AED_シリアルナンバー
		/// </summary>
		[JsonProperty("SerialNumber")]
		public string SerialNumber { get; set; }

		/// <summary>
		/// メタデータ_情報源
		/// </summary>
		[JsonProperty("Source")]
		public string Source { get; set; }

		/// <summary>
		/// ？？？
		/// </summary>
		[JsonProperty("VenueId")]
		public string VenueId { get; set; }

		/// <summary>
		/// 更新日時
		/// </summary>
		[JsonProperty("DateOfUpdatingInformation")]
		public string DateOfUpdatingInformation { get; set; }

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

		public bool Equals(AedInfo other)
		{
			return this.Distance == other.Distance &&
				this.Id == other.Id &&
				this.LocationName == other.LocationName &&
				this.Perfecture == other.Perfecture &&
				this.City == other.City &&
				this.AddressArea == other.AddressArea &&
				this.Latitude == other.Latitude &&
				this.Longitude == other.Longitude &&
				this.FacilityId == other.FacilityId &&
				this.FacilityName == other.FacilityName &&
				this.FacilityPlace == other.FacilityPlace &&
				this.ScheduleDayType == other.ScheduleDayType &&
				this.ScheduleDayStartTime == other.ScheduleDayStartTime &&
				this.ScheduleDayEndTime == other.ScheduleDayEndTime &&
				this.AccessAvailabilityOfPad == other.AccessAvailabilityOfPad &&
				this.FacilityUser == other.FacilityUser &&
				this.PhotoOfAedUrl == other.PhotoOfAedUrl &&
				this.Url == other.Url &&
				this.FacilityOwner == other.FacilityOwner &&
				this.FacilityOperater == other.FacilityOperater &&
				this.ContactPoint == other.ContactPoint &&
				this.ContactTelephone == other.ContactTelephone &&
				this.ContactExtension == other.ContactExtension &&
				this.FacilityNote == other.FacilityNote &&
				this.TypeOfPad == other.TypeOfPad &&
				this.ExpiryDate == other.ExpiryDate &&
				this.ExpiryDateOfPads == other.ExpiryDateOfPads &&
				this.ExpiryDateOfBatteries == other.ExpiryDateOfBatteries &&
				this.TypeOfDefibrillator == other.TypeOfDefibrillator &&
				this.ModelNumber == other.ModelNumber &&
				this.SerialNumber == other.SerialNumber &&
				this.Source == other.Source &&
				this.VenueId == other.VenueId &&
				this.DateOfUpdatingInformation == other.DateOfUpdatingInformation;
		}

		public override string ToString()
		{
			return "{" +
				$"{nameof(Distance)}={Distance}, " +
				$"{nameof(Id)}={Id}, " +
				$"{nameof(LocationName)}={LocationName}, " +
				$"{nameof(Perfecture)}={Perfecture}, " +
				$"{nameof(City)}={City}, " +
				$"{nameof(AddressArea)}={AddressArea}, " +
				$"{nameof(Latitude)}={Latitude}, " +
				$"{nameof(Longitude)}={Longitude}, " +
				$"{nameof(FacilityId)}={FacilityId}, " +
				$"{nameof(FacilityName)}={FacilityName}, " +
				$"{nameof(FacilityPlace)}={FacilityPlace}, " +
				$"{nameof(ScheduleDayType)}={ScheduleDayType}, " +
				$"{nameof(ScheduleDayStartTime)}={ScheduleDayStartTime}, " +
				$"{nameof(ScheduleDayEndTime)}={ScheduleDayEndTime}, " +
				$"{nameof(AccessAvailabilityOfPad)}={AccessAvailabilityOfPad}, " +
				$"{nameof(FacilityUser)}={FacilityUser}, " +
				$"{nameof(PhotoOfAedUrl)}={PhotoOfAedUrl}, " +
				$"{nameof(Url)}={Url}, " +
				$"{nameof(FacilityOwner)}={FacilityOwner}, " +
				$"{nameof(FacilityOperater)}={FacilityOperater}, " +
				$"{nameof(ContactPoint)}={ContactPoint}, " +
				$"{nameof(ContactTelephone)}={ContactTelephone}, " +
				$"{nameof(ContactExtension)}={ContactExtension}, " +
				$"{nameof(FacilityNote)}={FacilityNote}, " +
				$"{nameof(TypeOfPad)}={TypeOfPad}, " +
				$"{nameof(ExpiryDate)}={ExpiryDate}, " +
				$"{nameof(ExpiryDateOfPads)}={ExpiryDateOfPads}, " +
				$"{nameof(ExpiryDateOfBatteries)}={ExpiryDateOfBatteries}, " +
				$"{nameof(TypeOfDefibrillator)}={TypeOfDefibrillator}, " +
				$"{nameof(ModelNumber)}={ModelNumber}, " +
				$"{nameof(SerialNumber)}={SerialNumber}, " +
				$"{nameof(Source)}={Source}, " +
				$"{nameof(VenueId)}={VenueId}, " +
				$"{nameof(DateOfUpdatingInformation)}={DateOfUpdatingInformation}" +
				"}";
		}
	}
}

