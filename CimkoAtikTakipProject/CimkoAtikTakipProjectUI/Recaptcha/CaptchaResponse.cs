using Newtonsoft.Json;

namespace CimkoAtikTakipProjectUI.Recaptcha
{
	public class CaptchaResponse
	{
		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("error-codes")]
		public List<string> ErrorCodes { get; set; }
	}
}
