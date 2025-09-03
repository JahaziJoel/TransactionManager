using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class TransaccionService
{
    private readonly HttpClient http;

    public TransaccionService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<List<Transaccion>> ObtenerTodasAsync()
    {
        return await http.GetFromJsonAsync<List<Transaccion>>("api/transacciones") ?? new();
    }

    public async Task<decimal> TotalIngresosAsync()
    {
        var transacciones = await ObtenerTodasAsync();
        return transacciones.Where(t => t.Tipo == "Ingreso").Sum(t => t.Monto);
    }

    public async Task<decimal> TotalGastosAsync()
    {
        var transacciones = await ObtenerTodasAsync();
        return transacciones.Where(t => t.Tipo == "Gasto").Sum(t => t.Monto);
    }

    public async Task AgregarAsync(Transaccion t)
    {
        await http.PostAsJsonAsync("api/transacciones", t);
    }

    public async Task EliminarAsync(int id)
    {
        await http.DeleteAsync($"api/transacciones/{id}");
    }

    public async Task EditarAsync(int id, Transaccion t)
    {
        await http.PutAsJsonAsync($"api/transacciones/{id}", t);
    }

    public async Task ActualizarAsync(Transaccion transaccion)
    {
        var response = await http.PutAsJsonAsync($"api/transacciones/{transaccion.Id}", transaccion);
        response.EnsureSuccessStatusCode();
    }
}
