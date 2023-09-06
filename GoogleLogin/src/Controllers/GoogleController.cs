using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Caching;
using System.Linq;

namespace WebApplication1.Controllers
{
	public class GoogleController : Controller
	{
		// GET: Google
		[Route("/google")]
		public ActionResult Index()
		{
			var response = GoogleLoginService.GetAuthUrl();
			ViewBag.response = response;
			return View();
		}

		public async Task<ActionResult> SignUpGoogle(string code)
		{
			string rtnurl = "/home/index";
			try
			{
				//get google user
				var token = await GoogleLoginService.GetAuthAccessToken(code);
				var jsonData = await GoogleLoginService.GetProfileResponseAsync(token.AccessToken.ToString());
				GoogleUser user = JsonConvert.DeserializeObject<GoogleUser>(jsonData);

				//validate user info
				if (user == null || string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.family_name) || string.IsNullOrEmpty(user.given_name))
					return Redirect(rtnurl);

				//login or register
				var cc = user.given_name + " " + user.family_name;

				return Redirect(rtnurl);
			}
			catch (Exception)
			{
				return Redirect(rtnurl);
			}
		}

		public JsonResult test()
		{
			return Json("merhaba");
		}
		public ActionResult test2()
		{
			string result = test().Data.ToString(); // merhaba
			return View();
		}
	}

	public static class GoogleLoginService
	{
		#region fields
		private const string ClientId = "1016530904974-m0fnrahqcmkesbb6efereogpvkq0bbps.apps.googleusercontent.com";
		private const string ClientSecret = "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";
		private static string RedirectUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/google/signupgoogle";
		private const string AuthUrl = "https://accounts.google.com/o/oauth2/v2/auth";
		private const string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";
		private const string Scope = "https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email";
		private const string TokenUrl = "https://www.googleapis.com/oauth2/v4/token";
		#endregion

		public static string GetAuthUrl()
		{
			return AuthUrl + "?response_type=code&client_id=" + ClientId + "&redirect_uri=" + RedirectUrl + "&scope=" + Scope;
		}

		public static async Task<string> GetProfileResponseAsync(string accessToken)
		{
			HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, UserInfoUrl)
			{
				Headers = {
				{
					"Authorization",
					"Bearer " + accessToken
				} }
			};

			HttpClient client = new HttpClient();
			HttpResponseMessage res = await client.SendAsync(req);

			if (HttpStatusCode.OK != res.StatusCode)
			{
				throw new Exception($"Failed to get access token res: {res.ReasonPhrase}");
			}

			return await res.Content.ReadAsStringAsync();
		}

		public static async Task<AuthTokenResponse> GetAuthAccessToken(string code)
		{
			Dictionary<string, string> pars = new Dictionary<string, string>
			{
				["grant_type"] = "authorization_code",
				["code"] = code,
				["client_id"] = ClientId,
				["client_secret"] = ClientSecret,
				["scope"] = Scope,
				["redirect_uri"] = RedirectUrl
			};
			HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, TokenUrl)
			{
				Content = new FormUrlEncodedContent(pars)
			};
			HttpClient client = new HttpClient();
			HttpResponseMessage res = await client.SendAsync(req);

			if (HttpStatusCode.OK != res.StatusCode)
			{
				throw new Exception($"Failed to get access token res: {res.ReasonPhrase}");
			}

			return AuthTokenResponse.FromJSON(await res.Content.ReadAsStringAsync());
		}
	}

	public class AuthTokenResponse
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }

		[JsonProperty("scope")]
		public string Scope { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		public static AuthTokenResponse FromJSON(string source)
		{
			return JsonConvert.DeserializeObject<AuthTokenResponse>(source);
		}
	}
	public class GoogleUser
	{
		public string id { get; set; }
		public string email { get; set; }
		public bool verified_email { get; set; }
		public string name { get; set; }
		public string given_name { get; set; }
		public string family_name { get; set; }
		public string picture { get; set; }
		public string locale { get; set; }
	}
}