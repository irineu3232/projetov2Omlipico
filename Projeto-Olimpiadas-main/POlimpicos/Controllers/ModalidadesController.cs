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
            var lista = new List<Modalidades>();

            using (var conn = db.GetConnection())
            using (var cmd = new MySqlCommand(@"
                        Select Distinct
                        m.codModalidade as modalidade, m.nomeModalidade as nome
                        From Modalidades m
                        Inner Join Provas p on p.codModalidade = m.codModalidade
                        Inner Join Resultadosatletas r on r.codProva = p.codProva
                        Inner Join Atletas a on a.codAtleta = r.codAtleta
                        Order by m.nomeModalidade;", conn
                    ))
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    lista.Add(new Modalidades
                    {
                        codModalidade = rd.GetInt32("modalidade"),
                        nomeModalidade = rd["nome"] as string

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
