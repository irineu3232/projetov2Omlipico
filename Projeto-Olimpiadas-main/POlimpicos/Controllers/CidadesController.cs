using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using POlimpicos.Data;
using POlimpicos.Models;

namespace POlimpicos.Controllers
{
    public class CidadesController : Controller
    {
        private readonly Database db = new Database();
        public IActionResult Index(int page = 1, int pageSize = 10, string? q = null)
        {
            page = page < 1 ? 1  : page;

            pageSize = pageSize <= 0 ? 50 : pageSize;

            int totalitems = 0;
            
            var itens = new List<Cidade>();

            using(var conn = db.GetConnection())
            {
                string where = "";
                if(!string.IsNullOrWhiteSpace(q))
                where = "Where c.nomeCidade Like @q Or e.nomeEstado Like @q";

                //Contador
                using (var cmdCount = new MySqlCommand($@"
                 Select Count(*) From cidades c
                 Left Join estados e on c.codEstado = e.codEstado
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
                Select c.codCidade, c.nomeCidade, IFNULL(e.nomeEstado,'') as nomeEstado 
                from cidades c
                Left Join estados e on c.codEstado = e.codEstado
                {where}
                Order by c.codCidade
                Limit @limit OFFSET @offset;", conn))
                {
                    if(!string.IsNullOrWhiteSpace(q))
                    cmd.Parameters.AddWithValue("@q", "%" + q + "%"); 
                    cmd.Parameters.AddWithValue("@limit", pageSize); 
                    cmd.Parameters.AddWithValue("@offset", (page - 1) * pageSize);


                    using (var r = cmd.ExecuteReader())
                    {
                        while(r.Read())
                        {
                            itens.Add(new Cidade
                            {
                                CodCidade = r.GetInt32("codCidade"),
                                NomeCidade = r.GetString("nomeCidade"),
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
               
            }


            return View(itens); //Model = lista simples 
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Estados = GetEstados();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cidade cidade)
        {
          using (var conn = db.GetConnection())
            {
                var sql = @"Insert into Cidades (nomeCidade, codEstado)
                            Values(@nome, @estado)";

                var cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nome", cidade.NomeCidade);
                cmd.Parameters.AddWithValue("@estado", cidade.CodEstado);

                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }


        List<Estado> GetEstados()
        {
            List<Estado> estados = new List<Estado>();

            using (var conn = db.GetConnection())
            {
                var sql = "Select Distinct * from Estados order by nomeEstado";

                var cmd = new MySqlCommand(sql, conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    estados.Add(new Estado
                    {
                        codEstado = reader.GetInt32("codEstado"),
                        nomeEstado = reader.GetString("nomeEstado")
                    });
                }
            }
            return estados;
        }
    }

}
