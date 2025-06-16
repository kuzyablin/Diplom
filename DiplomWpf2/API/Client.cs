using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DiplomWpf2.DTO;
using DiplomWpf2.Tools;
using Newtonsoft.Json;

namespace DiplomWpf2.API
{
    class Client
    {
        HttpClient httpClient = new HttpClient();


        private Client()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7245/api/");
        }

        static Client instance = new();
        public static Client Instance
        {
            get
            {
                if (instance == null)
                    instance = new Client();
                return instance;
            }
        }

        //ВЫВОДЫ

        public async Task<List<BuketDTO>> GetBuket()

        {
            try
            {
                var response = await httpClient.GetAsync("Buket");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<BuketDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task<List<KrossBuketDTO>> GetKrossBukets()

        {
            try
            {
                var response = await httpClient.GetAsync("KrossBuket");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<KrossBuketDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<OrderDTO>> GetOrder()

        {
            try
            {
                var response = await httpClient.GetAsync("Order");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<OrderDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<StatusDTO>> GetStatus()

        {
            try
            {
                var response = await httpClient.GetAsync("Status");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<StatusDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<SkidkaDTO>> GetSkidka()

        {
            try
            {
                var response = await httpClient.GetAsync("Skidka");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<SkidkaDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<TovarDTO>> GetTovar()

        {
            try
            {
                var response = await httpClient.GetAsync("Tovar");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<TovarDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<TovarDTO>> GetTovar1(int typeTovar)

        {
            try
            {
                var response = await httpClient.GetAsync("Tovar/GetTovarByTypeTovar?typeTovar=" + typeTovar);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<TovarDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<TypeTovarDTO>> GetType()

        {
            try
            {
                var response = await httpClient.GetAsync("TypeTovar");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<TypeTovarDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<UserDTO>> GetUser()

        {
            try
            {
                var response = await httpClient.GetAsync("User");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<UserDTO>>(content);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //ВЫВОДЫ ПО ID

        public async Task<BuketDTO> GetBuket(int id)

        {
            HttpResponseMessage responseId = await httpClient.GetAsync($"Buket/GetBuket/{id}");
            if (responseId.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve user information");
            }
            var content = await responseId.Content.ReadAsStringAsync();
            var buket = JsonConvert.DeserializeObject<BuketDTO>(content);

            return buket;
        }

        public async Task<OrderDTO> GetOrder(int id)

        {
            HttpResponseMessage responseId = await httpClient.GetAsync($"Order/GetOrder/{id}");
            if (responseId.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve user information");
            }
            var content = await responseId.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDTO>(content);

            return order;
        }

        public async Task<SkidkaDTO> GetSkidka(int id)

        {
            HttpResponseMessage responseId = await httpClient.GetAsync($"Skidka/GetSkidka/{id}");
            if (responseId.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve user information");
            }
            var content = await responseId.Content.ReadAsStringAsync();
            var skidka = JsonConvert.DeserializeObject<SkidkaDTO>(content);

            return skidka;
        }

        public async Task<TovarDTO> GetTovar(int id)

        {
            HttpResponseMessage responseId = await httpClient.GetAsync($"Tovar/GetTovar/{id}");
            if (responseId.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve user information");
            }
            var content = await responseId.Content.ReadAsStringAsync();
            var tovar = JsonConvert.DeserializeObject<TovarDTO>(content);

            return tovar;
        }

        public async Task<TypeTovarDTO> GetTypeTovar(int id)

        {
            HttpResponseMessage responseId = await httpClient.GetAsync($"TypeTovar/GetTypeTovar/{id}");
            if (responseId.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve user information");
            }
            var content = await responseId.Content.ReadAsStringAsync();
            var typetovar = JsonConvert.DeserializeObject<TypeTovarDTO>(content);

            return typetovar;
        }

        public async Task<UserDTO> GetUser(int id)

        {
            HttpResponseMessage responseId = await httpClient.GetAsync($"User/GetUser/{id}");
            if (responseId.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve user information");
            }
            var content = await responseId.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(content);

            return user;
        }

        //ДОБАВЛЕНИЕ

        public async Task AddBuketAsync(BuketDTO buket)
        {
            var jsonContent = JsonConvert.SerializeObject(buket);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("Buket/AddBuket", httpContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Не удалось создать букет.");
            }
        }

        public async Task AddOrderAsync(OrderDTO order)
        {
            var jsonContent = JsonConvert.SerializeObject(order);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("Order", httpContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Не удалось создать заказ.");
            }
            else
            {
                order.IdOrder = await response.Content.ReadFromJsonAsync<int>();
            }
        }

        //public async Task AddTovarAsync(KrossOrderDTO krossOrder)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var jsonContent = JsonConvert.SerializeObject(krossOrder);
        //        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await httpClient.PostAsync("KrossOrder/AddTovar", httpContent);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            throw new Exception("Не удалось добавить в заказ.");
        //        }
        //    }
        //}

        public async Task AddBuketToOrder(OrderDTO order, BuketDTO buket, int count)
        {
            var jsonContent = JsonConvert.SerializeObject(buket);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await httpClient.PostAsync($"KrossOrder/AddBuketToOrder/{order.IdOrder}/{buket.IdBuket}/{count}", httpContent);
            response.EnsureSuccessStatusCode();
            // MessageBox.Show(response.StatusCode.ToString());
            return;
        }

        public async Task AddTovarToOrder(OrderDTO order, TovarDTO tovar, int count)
        {
            var jsonContent = JsonConvert.SerializeObject(tovar);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await httpClient.PostAsync($"KrossOrder/AddTovarToOrder/{order.IdOrder}/{tovar.IdTovar}/{count}", httpContent);
            response.EnsureSuccessStatusCode();
            // MessageBox.Show(response.StatusCode.ToString());
            return;
        }

        //РЕДАКТИРОВАНИЕ

        public async Task<BuketDTO> EditBuket(BuketDTO buket, int id)
        {
            var shit = System.Text.Json.JsonSerializer.Serialize(buket);
            using StringContent jsonContent = new(
                   shit,
                   Encoding.UTF8,
                   "application/json");
            using HttpResponseMessage response = await httpClient.PutAsync("Buket/" + buket.IdBuket, jsonContent);
            response.EnsureSuccessStatusCode();
            // MessageBox.Show(response.StatusCode.ToString());
            return buket;
        }

        public async Task<OrderDTO> EditOrder(OrderDTO order, int id)
        {
            var shit = System.Text.Json.JsonSerializer.Serialize(order);
            using StringContent jsonContent = new(
                   shit,
                   Encoding.UTF8,
                   "application/json");
            using HttpResponseMessage response = await httpClient.PutAsync("Order/" + order.IdOrder, jsonContent);
            response.EnsureSuccessStatusCode();
            // MessageBox.Show(response.StatusCode.ToString());
            return order;
        }

        //УДАЛЕНИЕ

        public async Task DeleteBuketInOrder(int id)
        {
            using HttpResponseMessage response = await httpClient.DeleteAsync("KrossOrder/DeleteBuketInOrder/" + id);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTovarInOrder(int id)
        {
            using HttpResponseMessage response = await httpClient.DeleteAsync("KrossOrder/DeleteTovarInOrder/" + id);
            response.EnsureSuccessStatusCode();
        }
        //ЮЗЕР

        //public async Task RegisterUserAsync(UserDTO user)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var jsonContent = JsonConvert.SerializeObject(user);
        //        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await httpClient.PostAsync("User/RegisterUser", httpContent);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            throw new Exception("Не удалось добавить юзера.");
        //        }
        //    }
        //}

        public async Task<UserDTO> Login(string login, string password, string mail)
        {
            var authData = new UserDTO
            {
                NameUser = login,
                ParolUser = password,
                EmailUser = mail,
                NumberUser = ""
            };

            //JsonContent content = JsonContent.Create(authData);
            //var jsonContent = JsonConvert.SerializeObject(authData);
            //var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsJsonAsync("Auth/login", authData);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Неправильный логин или пароль");
            }
            TokenDTO tokenDTO = await response.Content.ReadFromJsonAsync<TokenDTO>();
            //string token = await response.Content.ReadAsStringAsync();
            ClientData.Id = tokenDTO.Id;
            authData.IdUser = tokenDTO.Id;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenDTO.Token);
            return authData;
        }

        public static async Task<bool> RegisterUserAsync(RegistUser registUser)
        {
            var url = $"User"; // или тот путь, который у вас есть
            var json = JsonConvert.SerializeObject(registUser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            registUser.kod = "0";
            //var response = await Client.Instance.httpClient.PostAsync(url, content);
            var response = await Client.Instance.httpClient.PostAsJsonAsync("User", registUser);
            return response.IsSuccessStatusCode; // возвращает true, если успешно
        }
        public async Task<UserDTO> GetUserById()
        {
            UserDTO userDTO = await httpClient.GetFromJsonAsync<UserDTO>($"User/{ClientData.Id}");
            return userDTO;
        }

        public static async Task<bool> VerifyCodeAsync(string email, string code)
        {
            var url = $"User/vashkod"; // путь для проверки кода
            var requestObj = new VerifyCodeRequest
            {
                EmailUser = email,
                Code = code
            };
            var json = JsonConvert.SerializeObject(requestObj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.Instance.httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                // Можно дополнительно обработать ответ, если нужно
                return true;
            }
            return false;
        }

        public class VerifyCodeRequest
        {
            public string EmailUser { get; set; }
            public string Code { get; set; }
        }
        //public async Task? EditUser(UserDTO user)
        //{
        //    var userDTO = new UserDTO
        //    {
        //        IdUser = user.IdUser,
        //        ParolUser = user.ParolUser,
        //        NameUser = user.NameUser,
        //        EmailUser = user.EmailUser,
        //        NumberUser = user.NumberUser,
        //    };
        //    HttpResponseMessage response = await httpClient.PutAsJsonAsync($"User/EditUser/{user.IdUser}", userDTO);
        //    if (!response.IsSuccessStatusCode)
        //        MessageBox.Show("Не получилось перезаписать новый пароль", "Неудача", MessageBoxButton.OK, MessageBoxImage.Error);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        MessageBox.Show("Данные изменены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //}
    }
}
