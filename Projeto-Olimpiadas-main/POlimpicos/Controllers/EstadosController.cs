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
            var lista = new List<Estado>();

            using (var conn = db.GetConnection())
            using (var cmd = new MySqlCommand(@"
                        Select Distinct
                        e.codEstado, e.nomeEstado
                        From Estados e
                        Inner Join Cidades c on c.codEstado = e.codEstado
                        Inner Join Atletas a on c.codCidade = a.codCidade
                        Order by e.nomeEstado;", conn
                    ))
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    lista.Add(new Estado
                    {
                        codEstado = rd.GetInt32("codEstado"),
                        nomeEstado = rd["nomeEstado"] as string

                    });
                }
            }

            return View(lista);
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
