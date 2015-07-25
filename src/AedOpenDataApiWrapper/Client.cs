using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AedOpenDataApiWrapper
{
	public class Client :IDisposable
    {
		private HttpClient httpClient = new HttpClient();

		public string BaseUri { get; }

		public Client(string baseUri = "https://aed.azure-mobile.net")
		{
			BaseUri = baseUri;
        }

		/// <summary>
		/// 登録済国コード取得API
		/// "/api/CountryList"
		/// </summary>
		/// <returns></returns>
		public async Task<List<string>> CountryList()
		{
			var response = await httpClient.GetStringAsync(BaseUri + "/api/CountryList");
			return JsonConvert.DeserializeObject<List<Country>>(response)
				.Select(x => x.CountryCode).ToList();
		}

		/// <summary>
		/// 国コード指定都道府県一覧取得API
		/// "/api/PerfectureList/[国コード]"
		/// </summary>
		/// <param name="countryCode">国コード(e.g. jp, tw)</param>
		/// <returns></returns>
		public async Task<List<Perfecture>> PerfectureList(string countryCode)
		{
			var requestUri = $"{BaseUri}/api/PerfectureList/{WebUtility.UrlEncode(countryCode)}";
			var response = await httpClient.GetStringAsync(requestUri);
			return JsonConvert.DeserializeObject<List<Perfecture>>(response);
		}

		/// <summary>
		/// 市町村区単位での登録件数API
		/// "/api/aedgroup"
		/// </summary>
		/// <returns></returns>
		public async Task<List<City>> AedGroup()
		{
            var response = await httpClient.GetStringAsync(BaseUri + "/api/aedgroup");
            return JsonConvert.DeserializeObject<List<City>>(response);
        }

        /// <summary>
        /// 都道府県単位でのAED位置情報取得API
        /// "/api/aedinfo/[県名]/"
        /// </summary>
        /// <param name="perfecture">都道府県名</param>
        /// <returns></returns>
        public async Task<List<AedInfo>> AedInfo(string perfecture)
		{
            var requestUri = $"{BaseUri}/api/aedinfo/{WebUtility.UrlEncode(perfecture)}/";
            var response = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<List<AedInfo>>(response);
        }

        /// <summary>
        /// 市町村区単位でのAED位置情報取得API
        /// "/api/aedinfo/[県名]/[市町村区名]"
        /// </summary>
        /// <param name="perfecture">都道府県名</param>
        /// <param name="city">市区町村名</param>
        /// <returns></returns>
        public async Task<List<AedInfo>> AedInfo(string perfecture, string city)
		{
            var requestUri = $"{BaseUri}/api/aedinfo/{WebUtility.UrlEncode(perfecture)}/{WebUtility.UrlEncode(city)}/";
            var response = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<List<AedInfo>>(response);
        }

        /// <summary>
        /// 周辺AED位置情報取得API
        /// "/api/AEDSearch?lat=[緯度]&lng=[経度]&r=[検索半径(m)]"
        /// </summary>
        /// <param name="latitude">緯度</param>
        /// <param name="longitude">経度</param>
        /// <param name="radius">半径(m)</param>
        /// <returns></returns>
        public async Task<List<AedInfo>> AedSearch(double latitude, double longitude, int radius = 1000)
		{
            var requestUri = $"{BaseUri}/api/AEDSearch?lat={latitude}&lng={longitude}&r={radius}";
            var response = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<List<AedInfo>>(response);
        }

        /// <summary>
        /// 直近AED位置情報取得API
        /// "/api/NearAED?lat=[緯度]&lng=[経度]"
        /// </summary>
        /// <param name="latitude">緯度</param>
        /// <param name="longitude">経度</param>
        /// <returns></returns>
        public async Task<List<AedInfo>> NearAed(double latitude, double longitude)
		{
            var requestUri = $"{BaseUri}/api/NearAED?lat={latitude}&lng={longitude}";
            var response = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<List<AedInfo>>(response);
        }

        /// <summary>
        /// AED位置情報取得API
        /// "/api/id/[id]/"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<AedInfo>> Id(int id)
		{
            var requestUri = $"{BaseUri}/api/id/{id}/";
            var response = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<List<AedInfo>>(response);
        }

        public void Dispose()
		{
			httpClient?.Dispose();
		}
	}
}
