using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using POlimpicos.Data;
using POlimpicos.Models;

namespace POlimpicos.Controllers
{
    public class ModalidadesController : Controller
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
        public IActionResult Cadastrar(Modalidades modalidades)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"Insert into Modalidades (nomeModalidade)
                            Values(@nome)";

                var cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nome", modalidades.nomeModalidade);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");

        }




    }
}
