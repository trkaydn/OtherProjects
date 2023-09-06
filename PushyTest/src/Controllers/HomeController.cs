using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Pushy;

namespace WebApplication2.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
            //SendSamplePush();
			return View();
		}


       [HttpPost]
        public  /*static*/ JsonResult SendSamplePush(string devicetoken)
        {
            // Prepare array of target device tokens
            List<string> deviceTokens = new List<string>();

            // Add your device tokens here
            // deviceTokens.Add("0987f5d2ebd54595c87334");  //KENDİ TOKENİM
            deviceTokens.Add(devicetoken);

            // Açıklama: Görüldüğü gibi her cihaza bir kimlik (token) atıyor. Bu tokenleri veritabanına kayıt edebiliriz profilid/firmaid ile, bir de tip sütunu açarız.
            //mesaj gönderme eventinde o profilid'in tokeni varsa sendsamplepush metodu ile push atabilir miyiz alıcıya ? 

            // Convert to string[] array
            string[] to = deviceTokens.ToArray(); //eğer yaparsak bunu db'den çekcez alıcı tokenini

            // Optionally, send to a publish/subscribe topic instead
            // string to = '/topics/news';

            // Set payload (it can be any object)
            var payload = new Dictionary<string, string>();

            // Add message parameter to dictionary
            payload.Add("title", "Yeni Mesajın Var!");
            payload.Add("url", "https://www.google.com.tr"); //opens when tapped
            payload.Add("message", "Mesaj içeğini görmek için tıklayın.");
            payload.Add("image", "https://www.bakiciburada.com/images/bakiciburada+ico.ico");

            // iOS notification fields
            var notification = new Dictionary<string, object>();

            notification.Add("badge", 1);
            notification.Add("sound", "ping.aiff");
            notification.Add("title", "Test Notification");
            notification.Add("body", "Hello World \u270c");
            notification.Add("url", "https://www.bakiciburada.com/images/bakiciburada+ico.ico");

            // Prepare the push HTTP request
            PushyPushRequest push = new PushyPushRequest(payload, to, notification);

            try
            {
                // Send the push notification
                PushyAPI.SendPush(push);

            }
            catch (Exception exc)
            {
                // Write error to console
                Console.WriteLine(exc);
            }
            return Json(1);

        }
    }
}