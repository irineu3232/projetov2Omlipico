using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using POlimpicos.Data;
using POlimpicos.Models;
using System.Data.SqlTypes;

namespace POlimpicos.Controllers
{
    public class AtletasController : Controller
    {
        private readonly Database db = new Database();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            ViewBag.Cidades = GetCidades();
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Atletas atletas)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"Insert into Atletas(nomeAtleta, dataNascimento, sexo, altura, peso, codCidade)
                            Values(@nome, @data, @sexo, @altura, @peso, @cidade)";

                var cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nome", atletas.nomeAtleta);

                cmd.Parameters.AddWithValue("@data", atletas.dataNascimento);

                cmd.Parameters.AddWithValue("@sexo", atletas.sexo);

                cmd.Parameters.AddWithValue("@altura", atletas.altura);

                cmd.Parameters.AddWithValue("@peso", atletas.peso);

                cmd.Parameters.AddWithValue("@cidade", atletas.codCidade);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        private List<Cidade> GetCidades()
        {
            List<Cidade> cidades = new List<Cidade>();
            using (var conn = db.GetConnection())
            {
                var sql = "Select Distinct * FROM Cidades order by nomeCidade";

                var cmd = new MySqlCommand(sql, conn);

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    cidades.Add(new Cidade
                    {
                        CodCidade = reader.GetInt32("codCidade"),
                        NomeCidade = reader.GetString("nomeCidade"),
                        CodEstado = reader.GetInt32("codEstado")
                    });
                }
            }
            return cidades;
        }




    }
}
