using Consumir.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Consumir.Method
{
    public class MethodsEmpleados
    {
        Uri Url = new Uri("https://localhost:7248/api/Empleados");
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options;
        public MethodsEmpleados()
        {
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = Url;
        }

        public async Task< IEnumerable<EmpleadoViewModel>> Leer()
        {
            var clt = await _httpClient.GetAsync(Url);
            var DatosString = await clt.Content.ReadAsStringAsync();
            var Resultado = JsonSerializer.Deserialize<IEnumerable<EmpleadoViewModel>>(DatosString, options);

            return Resultado;
        }

        public async void Guardar( EmpleadoViewModelPost empleado)
        {
            var Serial = JsonSerializer.Serialize(empleado);
            StringContent content = new StringContent(Serial, Encoding.UTF8, "application/json");
            var Accion = await _httpClient.PostAsync(_httpClient.BaseAddress, content);

        }

        public async Task<EmpleadoViewModel> CargarDato(int id)
        {
            var Get = await _httpClient.GetAsync(_httpClient.BaseAddress+"/"+ id);
            var Str = await Get.Content.ReadAsStringAsync();
            var Datos = JsonSerializer.Deserialize<EmpleadoViewModel>(Str, options);

            return Datos;
        }

        public async Task<Boolean> Update(EmpleadoViewModel empleado)
        {
            if(empleado == null)
            {
                return false;
            }
            var serial = JsonSerializer.Serialize(empleado);
            StringContent content = new StringContent(serial, Encoding.UTF8, "application/json");
            var Datos = await _httpClient.PutAsync(_httpClient.BaseAddress, content);

            return true;
        }

        public async void Eliminar(int? id)
        {
            var Serial = _httpClient.BaseAddress + "/" + id;
            var resultado = await _httpClient.DeleteAsync(Serial);
            await Leer();
        }
    }
}
