using Microsoft.AspNetCore.Mvc;
using POlimpicos.Data;
using MySql.Data.MySqlClient;
using POlimpicos.Models;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace POlimpicos.Controllers
{
    public class ProvasController : Controller
    {
        private readonly Database db = new Database();

        public IActionResult Index(int page = 1, int pageSize = 10, string? q = null)
        {
            page = page < 1 ? 1 : page;

            pageSize = pageSize <= 0 ? 50 : pageSize;

            int totalitems = 0;

            var itens = new List<Provas>();

            using (var conn = db.GetConnection())
            {
                string where = "";
                if (!string.IsNullOrWhiteSpace(q))
                    where = "Where p.nomeProva Like @q Or m.nomeModalidade Like @q";

                //Contador
                using (var cmdCount = new MySqlCommand($@"
                 Select Count(*) From Provas p
                 Left Join Modalidades m on p.codProva = m.codModalidade
                 {where}", conn))
                {
                    if (!string.IsNullOrWhiteSpace(q))
                        cmdCount.Parameters.AddWithValue("@q", "%" + q + "%");

                    totalitems = Convert.ToInt32(cmdCount.ExecuteScalar());
                }


                // Ajuste de página
                int totalPages = (int)Math.Ceiling(totalitems / (double)pageSize);

                if (totalPages == 0) totalPages = 1;
                if (page > totalPages) page = totalPages;

                //Pagina
                // No IFNULL(e.nomeEstado, [Usa aspas simples].
                using (var cmd = new MySqlCommand($@"
                Select p.codProva, p.codModalidade, p.nomeProva, IFNULL(m.nomeModalidade,'') as nomeModalidade 
                from Provas p
                Left Join Modalidades m on p.codProva = m.codModalidade
                {where}
                Order by p.codProva
                Limit @limit OFFSET @offset;", conn))
                {
                    if (!string.IsNullOrWhiteSpace(q))
                        cmd.Parameters.AddWithValue("@q", "%" + q + "%");
                    cmd.Parameters.AddWithValue("@limit", pageSize);
                    cmd.Parameters.AddWithValue("@offset", (page - 1) * pageSize);


                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            itens.Add(new Provas
                            {
                                codProva = r.GetInt32("codProva"),
                                nomeProva = r.GetString("nomeProva"),
                                codModalidade = r.GetInt32("codModalidade")
                            });
                        }
                    }
                }

                //*Metadados da paginação via ViewBag
                // ViewBags podem mandar variavéis ou funções para a página desejada.
                ViewBag.Page = page;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalItems = totalitems;
                ViewBag.TotalPages = (int)Math.Ceiling(totalitems / (double)pageSize);
                ViewBag.Query = q;

                return View(itens);
            }
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Modalidades = GetModalidades();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Provas provas)
        {
            using (var conn = db.GetConnection())
            {
                var sql = @"Insert into Provas(nomeProva, codModalidade)
                            Values(@nome,@cod)";

                var cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nome", provas.nomeProva);

                cmd.Parameters.AddWithValue("@cod", provas.codModalidade);

                
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }



        private List<Modalidades> GetModalidades()
        {
            List<Modalidades> modalidades = new List<Modalidades>();
            using (var conn = db.GetConnection())
            {
                var sql = "Select Distinct * FROM Modalidades order by nomeModalidade";

                var cmd = new MySqlCommand(sql, conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    modalidades.Add(new Modalidades
                    {
                        codModalidade = reader.GetInt32("codModalidade"),
                        nomeModalidade = reader.GetString("nomeModalidade")

                    });
                }
            }
            return modalidades;
        }


    }
}
