using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Zwierzoki.Models;
using Zwierzoki.Service;

namespace Zwierzoki.Controllers
{
    public class AnimalServices : IAnimalService
    {
        public string connectionS = "Data Source=db-mssql;Initial Catalog=s19562;Integrated Security=True";
        public IEnumerable<Animal> GetAnimals(string sortBy)
        {
            
            var animale = new List<Animal>();

            using (var con = new SqlConnection(connectionS))
            using (var com = new SqlCommand())
            {

                if (sortBy == null)
                {
                    sortBy = "AdmissionDate";
                }

                com.Connection = con;
                com.CommandText = "select an.Name, an.Type, an.AdmissionDate, ow.LastName from Animal an join Owner ow on " +
                    " an.idOwner = ow.idOwner "+" order by "+sortBy+" ASC";
                com.Parameters.AddWithValue("sortBy", sortBy);

                //com.CommandText = $"Select * from Animal order by {sortBy}";
                //com.Parameters.AddWithValue("ascDesc", ascDesc);

                con.Open();
                var dr = com.ExecuteReader();
                

                while (dr.Read())
                {
                    var an = new Animal();

                    an.Name = dr["Name"].ToString();
                    an.Type = dr["Type"].ToString();
                    an.AdmissionDate = (DateTime)dr["AdmissionDate"];
                    an.LastName = dr["LastName"].ToString();
                    Console.WriteLine(animale);
                    animale.Add(an);
                }
                return animale;
            }
        }
    }
}
