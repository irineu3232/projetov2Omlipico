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

        public IActionResult Index(int? codEstado, int? codModalidade)
        {
            var lista = new List<Atletas>();


            if(codEstado != null)
            {
                using (var conn = db.GetConnection())
                {
                    string query = @"Select Distinct
                        a.codAtleta, a.nomeAtleta, a.dataNascimento, a.sexo, a.altura, a.peso, a.codCidade, c.nomeCidade as CidadeNascimento, e.nomeEstado as EstadoNascimento, 
                        m.nomeModalidade as modalidade
                        From Atletas a
                        Inner Join resultadosatletas r on a.codAtleta = r.codAtleta
                        Inner Join provas p on r.codProva = p.codProva
                        Inner Join modalidades m on p.codModalidade = m.codModalidade
                        Left Join cidades c on a.codCidade = c.codCidade
                        Left Join estados e on c.codEstado = e.codEstado
                        where c.codEstado = @codEstado
                        Order by a.nomeAtleta
                       ;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codEstado", codEstado);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Atletas
                            {
                                codAtleta = rd.GetInt32("codAtleta"),
                                nomeAtleta = rd["nomeAtleta"] as string,
                                dataNascimento = rd["dataNascimento"] as string,
                                sexo = rd.IsDBNull(rd.GetOrdinal("sexo")) ? (char?)null : rd.GetChar("sexo"),
                                altura = rd.IsDBNull(rd.GetOrdinal("altura")) ? (decimal?)null : rd.GetDecimal("altura"),
                                peso = rd.IsDBNull(rd.GetOrdinal("peso")) ? (decimal?)null : rd.GetDecimal("peso"),
                                codCidade = rd.IsDBNull(rd.GetOrdinal("codCidade")) ? (int?)null : rd.GetInt32("codCidade"),
                                CidadeNascimento = rd["CidadeNascimento"] as string,
                                modalidade = rd["modalidade"] as string


                            });
                        }
                    }
                }
                return View(lista);
            }
            else if (codModalidade != null)
            {
                using (var conn = db.GetConnection())
                {
                    string query = @"Select Distinct
                        a.codAtleta, a.nomeAtleta, a.dataNascimento, a.sexo, a.altura, a.peso, a.codCidade, c.nomeCidade as CidadeNascimento, e.nomeEstado as EstadoNascimento, 
                        m.nomeModalidade as modalidade
                        From Atletas a
                        Inner Join resultadosatletas r on a.codAtleta = r.codAtleta
                        Inner Join provas p on r.codProva = p.codProva
                        Inner Join modalidades m on p.codModalidade = m.codModalidade
                        Left Join cidades c on a.codCidade = c.codCidade
                        Left Join estados e on c.codEstado = e.codEstado
                        where m.codModalidade = @codMod
                        Order by a.nomeAtleta
                       ;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codMod", codModalidade);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Atletas
                            {
                                codAtleta = rd.GetInt32("codAtleta"),
                                nomeAtleta = rd["nomeAtleta"] as string,
                                dataNascimento = rd["dataNascimento"] as string,
                                sexo = rd.IsDBNull(rd.GetOrdinal("sexo")) ? (char?)null : rd.GetChar("sexo"),
                                altura = rd.IsDBNull(rd.GetOrdinal("altura")) ? (decimal?)null : rd.GetDecimal("altura"),
                                peso = rd.IsDBNull(rd.GetOrdinal("peso")) ? (decimal?)null : rd.GetDecimal("peso"),
                                codCidade = rd.IsDBNull(rd.GetOrdinal("codCidade")) ? (int?)null : rd.GetInt32("codCidade"),
                                CidadeNascimento = rd["CidadeNascimento"] as string,
                                modalidade = rd["modalidade"] as string
                            });
                        }
                    }
                }
                return View(lista);
            }
             else
            using (var conn = db.GetConnection())
            using (var cmd = new MySqlCommand(@"
                        Select Distinct
                        a.codAtleta, a.nomeAtleta, a.dataNascimento, a.sexo, a.altura, a.peso, a.codCidade, c.nomeCidade as CidadeNascimento, e.nomeEstado as EstadoNascimento, 
                        m.nomeModalidade as modalidade
                        From Atletas a
                        Inner Join resultadosatletas r on a.codAtleta = r.codAtleta
                        Inner Join provas p on r.codProva = p.codProva
                        Inner Join modalidades m on p.codModalidade = m.codModalidade
                        Left Join cidades c on a.codCidade = c.codCidade
                        Left Join estados e on c.codEstado = e.codEstado
                        Order by a.nomeAtleta;", conn
                    ))
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    lista.Add(new Atletas
                    {
                        codAtleta = rd.GetInt32("codAtleta"),
                        nomeAtleta = rd["nomeAtleta"] as string,
                        dataNascimento = rd["dataNascimento"] as string,
                        sexo = rd.IsDBNull(rd.GetOrdinal("sexo")) ? (char?)null : rd.GetChar("sexo"),
                        altura = rd.IsDBNull(rd.GetOrdinal("altura")) ? (decimal?)null : rd.GetDecimal("altura"),
                        peso = rd.IsDBNull(rd.GetOrdinal("peso")) ? (decimal?)null : rd.GetDecimal("peso"),
                        codCidade = rd.IsDBNull(rd.GetOrdinal("codCidade")) ? (int?)null : rd.GetInt32("codCidade"),
                        CidadeNascimento = rd["CidadeNascimento"] as string,
                        modalidade = rd["modalidade"] as string


                    });
                }
            }

            return View(lista);
        }


        public IActionResult IndexEst(int? id)
        {
            var lista = new List<Atletas>();

            if (id != null)
            {
                using (var conn = db.GetConnection())
                {
                    string query = @"Select Distinct
                        a.codAtleta, a.nomeAtleta, a.dataNascimento, a.sexo, a.altura, a.peso, a.codCidade, c.nomeCidade as CidadeNascimento, e.nomeEstado as EstadoNascimento, 
                        m.nomeModalidade as modalidade
                        From Atletas a
                        Inner Join resultadosatletas r on a.codAtleta = r.codAtleta
                        Inner Join provas p on r.codProva = p.codProva
                        Inner Join modalidades m on p.codModalidade = m.codModalidade
                        Left Join cidades c on a.codCidade = c.codCidade
                        Left Join estados e on c.codEstado = e.codEstado
                        where c.codEstado = @codEstado
                        Order by a.nomeAtleta
                       ;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codEstado", id);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Atletas
                            {
                                codAtleta = rd.GetInt32("codAtleta"),
                                nomeAtleta = rd["nomeAtleta"] as string,
                                dataNascimento = rd["dataNascimento"] as string,
                                sexo = rd.IsDBNull(rd.GetOrdinal("sexo")) ? (char?)null : rd.GetChar("sexo"),
                                altura = rd.IsDBNull(rd.GetOrdinal("altura")) ? (decimal?)null : rd.GetDecimal("altura"),
                                peso = rd.IsDBNull(rd.GetOrdinal("peso")) ? (decimal?)null : rd.GetDecimal("peso"),
                                codCidade = rd.IsDBNull(rd.GetOrdinal("codCidade")) ? (int?)null : rd.GetInt32("codCidade"),
                                CidadeNascimento = rd["CidadeNascimento"] as string,
                                modalidade = rd["modalidade"] as string


                            });
                        }
                    }
                }
                return View(lista);
            }
            else 
            {

                return BadRequest();
            
            }
        }


        public IActionResult IndexMod(int? id)
        {
            var lista = new List<Atletas>();

            if (id != null)
            {
                using (var conn = db.GetConnection())
                {
                    string query = @"Select Distinct
                        a.codAtleta, a.nomeAtleta, a.dataNascimento, a.sexo, a.altura, a.peso, a.codCidade, c.nomeCidade as CidadeNascimento, e.nomeEstado as EstadoNascimento, 
                        m.nomeModalidade as modalidade
                        From Atletas a
                        Inner Join resultadosatletas r on a.codAtleta = r.codAtleta
                        Inner Join provas p on r.codProva = p.codProva
                        Inner Join modalidades m on p.codModalidade = m.codModalidade
                        Left Join cidades c on a.codCidade = c.codCidade
                        Left Join estados e on c.codEstado = e.codEstado
                        where m.codModalidade = @codMod
                        Order by a.nomeAtleta
                       ;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codMod", id);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Atletas
                            {
                                codAtleta = rd.GetInt32("codAtleta"),
                                nomeAtleta = rd["nomeAtleta"] as string,
                                dataNascimento = rd["dataNascimento"] as string,
                                sexo = rd.IsDBNull(rd.GetOrdinal("sexo")) ? (char?)null : rd.GetChar("sexo"),
                                altura = rd.IsDBNull(rd.GetOrdinal("altura")) ? (decimal?)null : rd.GetDecimal("altura"),
                                peso = rd.IsDBNull(rd.GetOrdinal("peso")) ? (decimal?)null : rd.GetDecimal("peso"),
                                codCidade = rd.IsDBNull(rd.GetOrdinal("codCidade")) ? (int?)null : rd.GetInt32("codCidade"),
                                CidadeNascimento = rd["CidadeNascimento"] as string,
                                modalidade = rd["modalidade"] as string
                            });
                        }
                    }
                }
                return View(lista);
            }
            else
            {

                return BadRequest();

            }
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
