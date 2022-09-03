using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using TZApp.Model;

namespace TZApp;

public partial class LoginPage : ContentPage
{
	private string _login;
	private string _password;
	public LoginPage()
	{
		InitializeComponent();
	}

	private void login_TextChanged(object sender, TextChangedEventArgs e)
	{
		_login = login.Text;
	}

	private void password_TextChanged(object sender, TextChangedEventArgs e)
	{
		_password = password.Text;
	}

	private void sendRequest_Clicked(object sender, EventArgs e)
	{
        LoginData data = new LoginData()
        {
            Login = _login,
            Password = _password
        };
        var jsonData = JObject.FromObject(data);


		JObject responseJson = null;
        using (HttpClient client = new HttpClient())
		{
			//var response = client.PostAsync("http://testwork.cloud39.ru/BonusWebApi/Account/Login", JsonContent.Create(jsonData.ToString())).Result;
			var response = client.PostAsync("http://testwork.cloud39.ru/BonusWebApi/Account/Login", new StringContent(jsonData.ToString(),Encoding.UTF8,"application/json")).Result;
            responseJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);
			var token = responseJson["Token"].ToObject<string>();
			if (token == null)
			{
				DisplayAlert("Уведомление", "Данные введены неверно", "Ок");
				return;
			}
			//response.StatusCode == HttpStatusCode.
		}
        DisplayAlert("Уведомление", $"Добро пожаловать, {responseJson["Client"]["FullName"]}", "Ок");

    }
}