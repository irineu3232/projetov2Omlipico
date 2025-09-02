using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using POlimpicos.Data;
using POlimpicos.Models;

namespace POlimpicos.Controllers
{
    public class AdminController : Controller
    {
        private readonly Database db = new Database();

        private static readonly string[] Roles = new[] { "Admin", "Gerente", "Leitor" };

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public IActionResult Login(string username, string password, string? returnUrl = null)

        {

            int userId = 0;

            string? hash = null;

            string? role = null;

            bool ativo = false;


            using (var conn = db.GetConnection())

            using (var cmd = new MySqlCommand(@"

                   SELECT id, password_hash, role, ativo

                   FROM usuarios

                   WHERE username = @u

                   LIMIT 1;", conn))

            {

                cmd.Parameters.AddWithValue("@u", username);

                using var r = cmd.ExecuteReader();

                if (r.Read())

                {

                    userId = r.GetInt32("id");

                    hash = r["password_hash"] as string;

                    role = r["role"] as string;

                    ativo = r.GetBoolean("ativo");

                }

            }


            if (userId == 0 || !ativo || string.IsNullOrEmpty(hash) || !BCrypt.Net.BCrypt.Verify(password, hash))

            {

                ModelState.AddModelError("", "Usuário ou senha inválidos.");

                return View();

            }


            // Grava MÍNIMO necessário na sessão

            HttpContext.Session.SetInt32("UserId", userId);

            HttpContext.Session.SetString("Username", username);

            HttpContext.Session.SetString("Role", role ?? "Leitor");


            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))

                return Redirect(returnUrl);


            return RedirectToAction("Index", "Home");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }


        // GET: /Admin/NovoUsuario

        [HttpGet]

        public IActionResult NovoUsuario()

        {

            return View(new Usuario());

        }


        // POST: /Admin/NovoUsuario

        [HttpPost]

        public IActionResult NovoUsuario(Usuario vm)

        {

            if (string.IsNullOrWhiteSpace(vm.Username) || string.IsNullOrWhiteSpace(vm.Password))

            {

                ViewBag.Erro = "Preencha usuário e senha.";

                return View(vm);

            }


            var hash = BCrypt.Net.BCrypt.HashPassword(vm.Password);


            using (var conn = db.GetConnection())

            using (var cmd = new MySqlCommand(@"

                    INSERT INTO usuarios (username, password_hash, role, ativo)

                     (@u, @h, @r, 1);", conn))

            {

                cmd.Parameters.AddWithValue("@u", vm.Username);

                cmd.Parameters.AddWithValue("@h", hash);

                cmd.Parameters.AddWithValue("@r", vm.Role);


                cmd.ExecuteNonQuery();

            }


            ViewBag.Sucesso = "Usuário cadastrado com sucesso!";

            return View(new Usuario());

        }

    }

}




