using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AedOpenDataApiWrapper;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnitTest
{
	[TestClass]
	public class ApiTest
	{
		[TestMethod]
		[DeploymentItem("JsonResult/CountryList.json")]
		public void 登録済国コード取得API()
		{
			var json = new StreamReader("CountryList.json").ReadToEnd();
			var list = JsonConvert.DeserializeObject<List<Country>>(json).Select(x => x.CountryCode);
			var apiResult = new ApiClient().CountryListAsync().Result;
			Assert.IsTrue(list.SequenceEqual(apiResult));
		}

		[TestMethod]
		[DeploymentItem("JsonResult/PerfectureList_jp.json")]
		public void 国コード指定都道府県一覧取得API()
		{
			var json = new StreamReader("PerfectureList_jp.json").ReadToEnd();
			var list = JsonConvert.DeserializeObject<List<Perfecture>>(json);
			var apiResult = new ApiClient().PerfectureListAsync("jp").Result;
			Assert.IsTrue(list.SequenceEqual(apiResult));
		}

		[TestMethod]
		[DeploymentItem("JsonResult/aedgroup.json")]
		public void 市町村区単位での登録件数API()
		{
			var json = new StreamReader("aedgroup.json").ReadToEnd();
			var list = JsonConvert.DeserializeObject<List<City>>(json);
			var apiResult = new ApiClient().AedGroupAsync().Result;
			Assert.IsTrue(list.SequenceEqual(apiResult));
		}

		[TestMethod]
		[DeploymentItem("JsonResult/aedinfo_福井県.json")]
		public void 都道府県単位でのAED位置情報取得API()
		{
			var json = new StreamReader("aedinfo_福井県.json").ReadToEnd();
			var list = JsonConvert.DeserializeObject<List<AedInfo>>(json);
			var apiResult = new ApiClient().AedInfoAsync("福井県").Result;
			Assert.IsTrue(list.SequenceEqual(apiResult));
		}

		[TestMethod]
		[DeploymentItem("JsonResult/aedinfo_福井県_鯖江市.json")]
		public void 市町村区単位でのAED位置情報取得API()
		{
			var json = new StreamReader("aedinfo_福井県_鯖江市.json").ReadToEnd();
			var list = JsonConvert.DeserializeObject<List<AedInfo>>(json);
			var apiResult = new ApiClient().AedInfoAsync("福井県", "鯖江市").Result;
			Assert.IsTrue(list.SequenceEqual(apiResult));
		}

		[TestMethod]
		[DeploymentItem("JsonResult/AEDSearch_lat=35.96&lng=136.185&r=300.json")]
		public void 周辺AED位置情報取得API()
		{
			var json = new StreamReader("AEDSearch_lat=35.96&lng=136.185&r=300.json").ReadToEnd();
			var list = JsonConvert.DeserializeObject<List<AedInfo>>(json);
			var apiResult = new ApiClient().AedSearchAsync(35.96, 136.185, 300).Result;
			Assert.IsTrue(list.SequenceEqual(apiResult));
		}

		[TestMethod]
		[DeploymentItem("JsonResult/NearAED_lat=35.96&lng=136.185.json")]
		public void 直近AED位置情報取得API()
		{
			var json = new StreamReader("NearAED_lat=35.96&lng=136.185.json").ReadToEnd();
			var list = JsonConvert.DeserializeObject<List<AedInfo>>(json);
			var apiResult = new ApiClient().NearAedAsync(35.96, 136.185).Result;
			Assert.IsTrue(list.SequenceEqual(apiResult));
		}

		[TestMethod]
		[DeploymentItem("JsonResult/id_2907.json")]
		public void AED位置情報取得API()
		{
			var json = new StreamReader("id_2907.json").ReadToEnd();
			var list = JsonConvert.DeserializeObject<List<AedInfo>>(json);
			var apiResult = new ApiClient().IdAsync(2907).Result;
			Assert.IsTrue(list.SequenceEqual(apiResult));
		}
	}
}
