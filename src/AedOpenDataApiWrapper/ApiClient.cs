﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AedOpenDataApiWrapper
{
	/// <summary>
	/// AEDオープンデータプラットフォーム(http://hatsunejournal.jp/w8/aedOpendata/)で公開されているWeb APIのラッパー。
	/// </summary>
	public class ApiClient : IDisposable
	{
		private HttpClient httpClient = new HttpClient();

		/// <summary>
		/// Web APIのベースアドレス
		/// </summary>
		public string BaseUri
		{
			get
			{
				return httpClient.BaseAddress.ToString();
			}
		}

		/// <summary>
		/// Web APIのベースアドレスでインスタンスを初期化します。
		/// </summary>
		/// <param name="baseUri">Web APIのベースアドレス</param>
		public ApiClient(string baseUri = "https://aed.azure-mobile.net/")
		{
			httpClient.BaseAddress = new Uri(baseUri);
		}

		/// <summary>
		/// 登録済国コード取得API
		/// "api/CountryList"
		/// </summary>
		public async Task<List<string>> CountryListAsync()
		{
			var response = await httpClient.GetStringAsync("api/CountryList").ConfigureAwait(false);
			return JsonConvert.DeserializeObject<List<Country>>(response)
				.Select(x => x.CountryCode).ToList();
		}

		/// <summary>
		/// 国コード指定都道府県一覧取得API
		/// "api/PerfectureList/[国コード]"
		/// </summary>
		/// <param name="countryCode">国コード(e.g. jp, tw)</param>
		public async Task<List<Perfecture>> PerfectureListAsync(string countryCode)
		{
			var requestUri = $"api/PerfectureList/{WebUtility.UrlEncode(countryCode)}";
			var response = await httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
			return JsonConvert.DeserializeObject<List<Perfecture>>(response);
		}

		/// <summary>
		/// 市町村区単位での登録件数API
		/// "api/aedgroup"
		/// </summary>
		public async Task<List<City>> AedGroupAsync()
		{
			var response = await httpClient.GetStringAsync("api/aedgroup").ConfigureAwait(false);
			return JsonConvert.DeserializeObject<List<City>>(response);
		}

		/// <summary>
		/// 都道府県単位でのAED位置情報取得API
		/// "api/aedinfo/[県名]/"
		/// </summary>
		/// <param name="perfecture">都道府県名</param>
		public async Task<List<AedInfo>> AedInfoAsync(string perfecture)
		{
			var requestUri = $"api/aedinfo/{WebUtility.UrlEncode(perfecture)}/";
			var response = await httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
			return JsonConvert.DeserializeObject<List<AedInfo>>(response);
		}

		/// <summary>
		/// 市町村区単位でのAED位置情報取得API
		/// "api/aedinfo/[県名]/[市町村区名]"
		/// </summary>
		/// <param name="perfecture">都道府県名</param>
		/// <param name="city">市区町村名</param>
		public async Task<List<AedInfo>> AedInfoAsync(string perfecture, string city)
		{
			var requestUri = $"api/aedinfo/{WebUtility.UrlEncode(perfecture)}/{WebUtility.UrlEncode(city)}/";
			var response = await httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
			return JsonConvert.DeserializeObject<List<AedInfo>>(response);
		}

		/// <summary>
		/// 周辺AED位置情報取得API
		/// "api/AEDSearch?lat=[緯度]&amp;lng=[経度]&amp;r=[検索半径(m)]"
		/// </summary>
		/// <param name="latitude">緯度</param>
		/// <param name="longitude">経度</param>
		/// <param name="radius">半径(m)</param>
		public async Task<List<AedInfo>> AedSearchAsync(double latitude, double longitude, int radius = 1000)
		{
			var requestUri = $"api/AEDSearch?lat={latitude}&lng={longitude}&r={radius}";
			var response = await httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
			return JsonConvert.DeserializeObject<List<AedInfo>>(response);
		}

		/// <summary>
		/// 直近AED位置情報取得API
		/// "api/NearAED?lat=[緯度]&amp;lng=[経度]"
		/// </summary>
		/// <param name="latitude">緯度</param>
		/// <param name="longitude">経度</param>
		public async Task<List<AedInfo>> NearAedAsync(double latitude, double longitude)
		{
			var requestUri = $"api/NearAED?lat={latitude}&lng={longitude}";
			var response = await httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
			return JsonConvert.DeserializeObject<List<AedInfo>>(response);
		}

		/// <summary>
		/// AED位置情報取得API
		/// "api/id/[id]/"
		/// </summary>
		/// <param name="id">Id</param>
		public async Task<List<AedInfo>> IdAsync(int id)
		{
			var requestUri = $"api/id/{id}/";
			var response = await httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
			return JsonConvert.DeserializeObject<List<AedInfo>>(response);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			httpClient?.Dispose();
		}
	}
}
