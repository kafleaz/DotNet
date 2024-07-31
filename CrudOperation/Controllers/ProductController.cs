using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CrudOperation.Controllers
{
    public class ProductController : Controller
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=DotNet_Lab;Trusted_Connection=True;MultipleActiveResultSets=true";

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Products (Name, Price, Description) VALUES (@Name, @Price, @Description)";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products";
                using SqlCommand command = new SqlCommand(query, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Description = reader["Description"].ToString()
                    };
                    products.Add(product);
                }
            }
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            Product product = new Product();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE Id = @Id";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.Id = Convert.ToInt32(reader["Id"]);
                    product.Name = reader["Name"].ToString();
                    product.Price = Convert.ToDecimal(reader["Price"]);
                    product.Description = reader["Description"].ToString();
                }
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Products WHERE Id = @Id";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}

