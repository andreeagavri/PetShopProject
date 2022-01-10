using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopModel.Data;
using PetShopModel.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace PetShop.Controllers
{
    [Authorize(Policy = "SalesManager")]
    public class ClientsController : Controller
    {
        private readonly PetShopContext _context;
        private string _baseUrl = "http://localhost:8308/api/Clients";

        public ClientsController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            var Httpclient = new HttpClient();
            var response = await Httpclient.GetAsync(_baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var clients = JsonConvert.DeserializeObject<List<Client>>(await response.Content.ReadAsStringAsync());
                return View(clients);
            }
            return NotFound();
        }
        // GET: Inventory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var Httpclient = new HttpClient();
            var response = await Httpclient.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var client = JsonConvert.DeserializeObject<Client>(
                await response.Content.ReadAsStringAsync());
                return View(client);
            }
            return NotFound();
        }
        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ClientID,Name,Adress,BirthDate")] Client client)
        {
            if (!ModelState.IsValid) return View(client);
            try
            {
                var Httpclient = new HttpClient();
                string json = JsonConvert.SerializeObject(client);
                var response = await Httpclient.PostAsync(_baseUrl,
                new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record:{ ex.Message}");
            }
            return View(client);
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var Httpclient = new HttpClient();
            var response = await Httpclient.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var client = JsonConvert.DeserializeObject<Client>(
                await response.Content.ReadAsStringAsync());
                return View(client);
            }
            return new NotFoundResult();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ClientID,Name,Adress,BirthDate")] Client client)
        {
            if (!ModelState.IsValid) return View(client);
            var Httpclient = new HttpClient();
            string json = JsonConvert.SerializeObject(client);
            var response = await Httpclient.PutAsync($"{_baseUrl}/{client.ClientID}",
            new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(client);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var Httpclient = new HttpClient();
            var response = await Httpclient.GetAsync($"{_baseUrl}/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var client = JsonConvert.DeserializeObject<Client>(await
                response.Content.ReadAsStringAsync());
                return View(client);
            }
            return new NotFoundResult();
        }
        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind("ClientID")] Client client)
        {
            try
            {
                var Httpclient = new HttpClient();
                HttpRequestMessage request =
                new HttpRequestMessage(HttpMethod.Delete,
                $"{_baseUrl}/{client.ClientID}")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(client),
                Encoding.UTF8, "application/json")
                };
                var response = await Httpclient.SendAsync(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to delete record: { ex.Message}");
            }
            return View(client);
        }
    }
}
