using SmsIrRestful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinBot.Utility
{
 public	class SendSms
	{
		Token tk = new Token();

		public string userApiKey { get; } = "785d4086e66492f9924f4083";
		public string secretKey { get; } = "sarzamintrjaratDeveloper";
		public long AdminMobile { get; } = 09136569769;
		public string LineNumber { get; } = "30004747475123";

		public string GetToken(string userApiKey, string secretKey)
		{
			string result = tk.GetToken(userApiKey, secretKey);
			return result;
		}
		public void CallSmSMethod(long MobileNumber, int TemplateId, string ParameterName, string ParameterValue)
		{
			var ultraFastSend = new UltraFastSend()
			{
				Mobile = MobileNumber,
				TemplateId = TemplateId,
				ParameterArray = new List<UltraFastParameters>()
				{

				 new UltraFastParameters()
				  {
				   Parameter = ParameterName , ParameterValue = ParameterValue
				  }
				 }.ToArray()
			};
			UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(tk.GetToken(userApiKey, secretKey), ultraFastSend);
		}

	}
}
