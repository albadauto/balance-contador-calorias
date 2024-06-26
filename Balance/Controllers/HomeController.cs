using Balance.Data;
using Balance.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;

namespace Balance.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMongoCollection<Alimento>? _collection;

        public HomeController(MongoDBService mongoDBService)
        {
            _collection = mongoDBService.Database?.GetCollection<Alimento>("alimento");
        }
        public async Task<IActionResult> Index()
        {
            var resultado = await _collection.Find(FilterDefinition<Alimento>.Empty).ToListAsync() ?? new List<Alimento>();  
            return View(resultado);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Adicionar registros para a base
        [HttpGet]
        public async Task<IActionResult> AdicionarDados()
        {
            Alimento alimento = new Alimento
            {
                Id = 1.ToString(),
                KCAL = 199,
                Nome = "Beterraba"
            };
            if(_collection != null)
                await _collection.InsertOneAsync(alimento);
            return RedirectToAction("Index");
        }

        //Procurar um registro
        private async Task<bool> VerificarRegistro(Alimento alimento)
        {
            var filter = Builders<Alimento>.Filter.Eq(a => a.Nome, alimento.Nome);
            return await _collection.FindAsync(filter) != null;
        }
    }
}
