using AtrinBot.Data;
using AtrinBot.Model;
using AtrinBot.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace AtrinBot
{
	class Program
	{

		static string BotToken = "1103832529:AAGuadimQKtGtS3OgAF7MFjjfX7ohK_bmjc";
		static TelegramBotClient Bot = new TelegramBotClient(BotToken);
	    static Volunteers _volunteers = new Volunteers();
		static Volunteers _volunteeritem = new Volunteers();
		static BotContext db = new BotContext();
		static ReplyKeyboardMarkup rkm = new ReplyKeyboardMarkup();
		

		static void Main(string[] args)
		{
		 rkm.Keyboard =
       new KeyboardButton[][]
       {
		new KeyboardButton[]
		{
			new KeyboardButton("پست یا استوری اینستاگرام"),
	
		},
		new KeyboardButton[]
		{
			new KeyboardButton("انتشار متن در پیام رسان ها (داخلی و خارجی)")
		}
		,
		  new KeyboardButton[]
		{
		    new KeyboardButton("تولید محتوای رسانه ای (کلیپ و پوستر)")
		},
		new KeyboardButton[]
		{

			new KeyboardButton("توییت"),
		},
			new KeyboardButton[]
		{

		
			new KeyboardButton("بازنشر محتواهای رضوی")
		}


		};


			Bot.StartReceiving();
			Bot.OnMessage += Bot_Message;
			Console.ReadLine();
		}

		private static void Bot_Message(object sender, MessageEventArgs e)
		{


			try
			{


				if (string.IsNullOrEmpty(e.Message.Chat.Username))
				{
					Bot.SendTextMessageAsync(e.Message.Chat.Id, string.Format("اکانت تلگرام شما {0} ندارد ، لطفا برای اکانت تلگرام خود یک {0} ایجاد کنید و مجددا {1} بزنید", "ای دی", "/start"));
					return;
				}
				if (db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username) &&
				   db.Volunteers.Where(s => s.UserName == e.Message.Chat.Username)
					.FirstOrDefault().AlreadyRegistered == true)
				{
					Bot.SendTextMessageAsync(e.Message.Chat.Id, "شما قبلا اعلام همکاری نموده اید و اطلاعات شما برای ادمین ارسال گردیده است .");
					return;
				}
				else
				{
					switch (e.Message.Text)
					{
						case "/start":
							Bot.SendTextMessageAsync(e.Message.Chat.Id, $"با سلام ، برای مشارکت در پویش سفیران رضوی ، ابتدا نام و نام خانوادگی خود را وارد کنید.");
							Console.WriteLine(e.Message.Chat.Username);
							break;
						case "پست یا استوری اینستاگرام":
							if (db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username))
							{
								_volunteeritem = db.Volunteers.Where(s => s.UserName == e.Message.Chat.Username).FirstOrDefault();
								if (_volunteeritem != null)
								{
									_volunteeritem.CooperationType = Cooperation.PostOrInstagramStory;
								}

								db.SaveChanges();
								Bot.SendTextMessageAsync(e.Message.Chat.Id, $"خدمت انتخابی {e.Message.Text}  است ،در صورت تمایل  به عضویت در سامانه پیامکی سفیران رضوی، شماره تلفن همراه خود را به اعداد لاتین ، به  ما اعلام کنید در غیر این صورت بر روی skip کلیک کنید. /skip");
							}
							else
							{
								Bot.SendTextMessageAsync(e.Message.Chat.Id, "شما باید ابتدا ثبت نام کنید ، لطفا روی /start  کلیک کنید.");
							}
							break;
						case "انتشار متن در پیام رسان ها (داخلی و خارجی)":
							if (db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username))
							{
								_volunteeritem = db.Volunteers.Where(s => s.UserName == e.Message.Chat.Username).FirstOrDefault();
								if (_volunteeritem != null)
								{
									_volunteeritem.CooperationType = Cooperation.ShareTextInInputOrOutputMassengers;
								}

								db.SaveChanges();
								Bot.SendTextMessageAsync(e.Message.Chat.Id, $"خدمت انتخابی {e.Message.Text}  است ، در صورت تمایل  به عضویت در سامانه پیامکی سفیران رضوی، شماره تلفن همراه خود را به اعداد لاتین ، به ما اعلام کنید در غیر این صورت بر روی skip کلیک کنید. /skip");



							}
							else
							{
								Bot.SendTextMessageAsync(e.Message.Chat.Id, "شما باید ابتدا ثبت نام کنید ، لطفا روی /start  کلیک کنید.");

							}
							break;
						case "تولید محتوای رسانه ای (کلیپ و پوستر)":
							if (db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username))
							{
								_volunteeritem = db.Volunteers.Where(s => s.UserName == e.Message.Chat.Username).FirstOrDefault();
								if (_volunteeritem != null)
								{
									_volunteeritem.CooperationType = Cooperation.ContentProductionClipOrPoster;
								}

								db.SaveChanges();
								Bot.SendTextMessageAsync(e.Message.Chat.Id, $"خدمت انتخابی {e.Message.Text}  است ،  در صورت تمایل  به عضویت در سامانه پیامکی سفیران رضوی، شماره تلفن همراه خود را  به اعداد لاتین ، به ما اعلام کنید در غیر این صورت بر روی skip کلیک کنید. /skip");

							}
							else
							{
								Bot.SendTextMessageAsync(e.Message.Chat.Id, "شما باید ابتدا ثبت نام کنید ، لطفا روی /start  کلیک کنید.");

							}
							break;
						case "توییت":
							if (db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username))
							{
								_volunteeritem = db.Volunteers.Where(s => s.UserName == e.Message.Chat.Username).FirstOrDefault();
								if (_volunteeritem != null)
								{
									_volunteeritem.CooperationType = Cooperation.Tweet;
								}
								db.SaveChanges();
								Bot.SendTextMessageAsync(e.Message.Chat.Id, $"خدمت انتخابی {e.Message.Text}  است ،در صورت تمایل  به عضویت در سامانه پیامکی سفیران رضوی، شماره تلفن همراه خود را  به اعداد لاتین ، به ما اعلام کنید در غیر این صورت بر روی skip کلیک کنید. /skip");

							}
							else
							{
								Bot.SendTextMessageAsync(e.Message.Chat.Id, "شما باید ابتدا ثبت نام کنید ، لطفا روی /start  کلیک کنید.");
							}
							break;
						case "بازنشر محتواهای رضوی":
							if (db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username))
							{
								_volunteeritem = db.Volunteers.Where(s => s.UserName == e.Message.Chat.Username).FirstOrDefault();
								if (_volunteeritem != null)
								{
									_volunteeritem.CooperationType = Cooperation.ReshareRazaviContent;
								}

								db.SaveChanges();
								Bot.SendTextMessageAsync(e.Message.Chat.Id, $"خدمت انتخابی {e.Message.Text}  است ، حالا که نوع خدمت مجازی خود به امام الرئوف را انتخاب کرده اید ، شماره تلفن همراه خود را  به اعداد لاتین ، به ما اعلام کنید در غیر این صورت بر روی skip کلیک کنید. /skip");


							}
							else
							{
								Bot.SendTextMessageAsync(e.Message.Chat.Id, "شما باید ابتدا ثبت نام کنید ، لطفا روی /start  کلیک کنید.");
							}
							break;
						case "/skip":
							Bot.SendTextMessageAsync(e.Message.Chat.Id, "حالا که نوع خدمت مجازی خود به امام الرئوف را انتخاب کرده اید، در صورت تمایل، لینکی از خدمت رسانی مجازی خود در اختیار ما قرار دهید تا آن را با دیگران اشتراک گذاری کنیم،در غیر این صورت بر روی end کلیک کنید. /end");

							break;

						case "/end":
							Bot.SendTextMessageAsync(e.Message.Chat.Id, "با تشکر از شما ، اطلاعات ثبت و برای ادمین ارسال گردید.");
							if (db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username))
							{
								var UserItem = db.Volunteers.Where(s => s.UserName == e.Message.Chat.Username).FirstOrDefault();
								UserItem.AlreadyRegistered = true;
								db.SaveChanges();
							}

							break;
						default:
							if (db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username) == false)
							{
								_volunteers.FullName = e.Message.Text;
								_volunteers.CreateDate = DateTime.Now;
								_volunteers.Link = string.Empty;
								_volunteers.CooperationType = Cooperation.empty;
								_volunteers.UserName = e.Message.Chat.Username;
								_volunteers.Mobile = "0";
								_volunteers.AlreadyRegistered = false;
								db.Volunteers.Add(_volunteers);
								db.SaveChanges();
								Bot.SendTextMessageAsync(e.Message.Chat.Id, "لطفا نوع خدمت خود را انتخاب کنید.", replyMarkup: rkm);
							}
							else  /*(db.Volunteers.Any(s => s.UserName == e.Message.Chat.Username))*/
							{

								var UserItem = db.Volunteers.Where(s => s.UserName == e.Message.Chat.Username).FirstOrDefault();
								if (IsPhoneNumber(e.Message.Text) && UserItem != null && UserItem.Mobile == "0")
								{
									UserItem.Mobile = ConvertPersianNumberToEnglish(e.Message.Text);
									db.SaveChanges();
									Bot.SendTextMessageAsync(e.Message.Chat.Id, "حالا که نوع خدمت مجازی خود به امام الرئوف را انتخاب کرده اید، در صورت تمایل، لینکی از خدمت رسانی مجازی خود در اختیار ما قرار دهید تا آن را با دیگران اشتراک گذاری کنیم،در غیر این صورت بر روی end کلیک کنید. /end");
								}
								if (IsPhoneNumber(e.Message.Text) == false && UserItem != null && UserItem.CooperationType != Cooperation.empty && string.IsNullOrEmpty(UserItem.Link))
								{
									UserItem.Link = e.Message.Text;
									UserItem.AlreadyRegistered = true;
									db.SaveChanges();
									Bot.SendTextMessageAsync(e.Message.Chat.Id, "با تشکر از شما ، اطلاعات ثبت و برای ادمین ارسال گردید.");
								}
							}
							break;
					}
				}
			}
			catch(Exception ex)
			{

			}
			}

		public static bool IsPhoneNumber(string number)
		{

			long n;

	     	if(!long.TryParse(number, out n))
			{
				return false;
			}
			if(number.Length == 11 || number.Length == 10)
			{
				return true;

			}

			return false; 
			//if (string.IsNullOrEmpty(number))
			//{
			//	number = "0";
			//}

			//number = 	ConvertPersianNumberToEnglish(number);
			//if(! string.IsNullOrEmpty(number) && number.Substring(0) != "0")
			//{
			//	number = number.Insert(0, "0");
			//}
			//if(number.Length ==11 || number.Length == 10 || number == "0" )
			//{
			//	return true;
			//}
			//else
			//{
			//	return false; 
			//}

			//return Regex.Match(number, @"^(?:(\u0660\u0669[\u0660-\u0669][\u0660-\u0669]{8})|(\u06F0\u06F9[\u06F0-\u06F9][\u06F0-\u06F9]{8})|(09[0-9][0-9]{8}))$").Success;
		}
	
		public static string ConvertPersianNumberToEnglish(string input)
		{
			string EnglishNumbers = "";
			for (int i = 0; i < input.Length; i++)
			{
				if (Char.IsDigit(input[i]))
				{
					EnglishNumbers += char.GetNumericValue(input, i);

				}
				else
				{
					EnglishNumbers += input[i].ToString();
				}
			}
			return EnglishNumbers;
		}

	}
}
