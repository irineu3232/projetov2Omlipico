using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using POlimpicos.Data;
using POlimpicos.Models;

namespace POlimpicos.Controllers
{
    public class EstadosController : Controller
    {
        private readonly Database db = new Database();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Estado estado)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"Insert into Estados(nomeEstado)
                            Values(@nome)";

                var cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nome", estado.nomeEstado);
               
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }


   

    }
}
