using it.Mifram.Dieci3k.DTO.Anagrafiche;
using it.Mifram.Dieci3k.DTO.Presenze;
using it.Mifram.Dieci3k.DTO.Support;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TimbratureApp.Service
{
    public class Dieci3kRestService
    {
        [Inject] HttpClient _httpClient { get; set; }

        public Dieci3kRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<CompanyDTO> GetCompanyNameAsync(string companyName)
        {
            try
            {
                string url = $"/api/Company/GetByName/{companyName}";
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    var companyDTO = System.Text.Json.JsonSerializer.Deserialize<CompanyDTO>(content);
                    return companyDTO;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                Console.WriteLine(error);
            }
            return null;
        }



        public async Task<UtenteAppDTO> GetUserTokenAsync(UtenteAppDTO UtenteAppDTO)
        {
            try
            {
                var jsonContent = System.Text.Json.JsonSerializer.Serialize(UtenteAppDTO);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                Console.WriteLine(content);
                var response = await _httpClient.PostAsync("/api/Token/GetUserToken", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UtenteAppDTO>(responseContent);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.Error.WriteLine($"API Error: {response.StatusCode} - {errorContent}");
                    throw new Exception($"API call failed: {response.StatusCode}"); // Or return null
                }
            }
            catch (Exception ex)
            {
                // This will catch other exceptions (network issues, etc.)
                Console.Error.WriteLine($"Error in GetUserTokenAsync: {ex.Message}");
                return null; // Or re-throw
            }
        }


        public async Task<int> FaiTimbratura(string token, TimbraturaDTO timbratura)
        {
            
                int returnValue;

                StringContent content = new StringContent(JsonConvert.SerializeObject(timbratura), Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                Console.WriteLine(content);
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                response = await _httpClient.PostAsync("/api/Timbratura", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<int>(responseContent);
                }
                else
                {
                    returnValue = -1;

                }

            }
            catch (Exception ex)
            {
                // This will catch other exceptions (network issues, etc.)
                Console.Error.WriteLine($"Error in GetUserTokenAsync: {ex.Message}");
                return -1; // Or re-throw
            }
            return returnValue;


        }
        //public async Task<int> Timbratura_Set1(string token, TimbraturaDTO timbratura)
        //{
        //    int returnValue;
        //    if (string.IsNullOrEmpty(token) || timbratura == null)
        //    {
        //        return -1;
        //    }
        //    StringContent httpContent = new StringContent(JsonConvert.SerializeObject(timbratura), Encoding.UTF8, "application/json");
        //    Uri uri = new Uri(await GetCurrentWsAddress() + "Timbratura"); // /Salva


        //    HttpResponseMessage response;
        //    try
        //    {
        //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //        response = await _httpClient.PostAsync(uri, httpContent);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<int>(content);

        //        }
        //        else
        //            returnValue = -1;
        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e.Message);
        //        Shared.WriteErrorLog(string.Format("{0} : {1}", this.GetType().Name, e.Message));
        //        returnValue = -101;
        //    }
        //    return returnValue;
        //}

    }


}

