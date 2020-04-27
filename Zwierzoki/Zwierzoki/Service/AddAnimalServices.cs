using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Zwierzoki.DTOs;

namespace Zwierzoki.Service
{
    public class AddAnimalServices : IAddAnimaleService
    {
        public string connectionS = "Data Source=db-mssql;Initial Catalog=s19562;Integrated Security=True";

        public string AddAnimale(AddAnimalRequest request)
        {
            using (var con = new SqlConnection(connectionS))
            using (var com = new SqlCommand())
            {

                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();
                com.Transaction = tran;

                //musisz sprawdzic najpierw czy id owner istnieje jak nie to dodac nowy 
                //wiec to co z tymi badankami juz mi sie nie chce robic 
                //--> sprawdz czy jest jak jest to git jak nie ma to nowy 

                    com.CommandText = "SET IDENTITY_INSERT Animal ON INSERT INTO Animal(IdAnimal, Name, Type, AdmissionDate, IdOwner)" +
                        "VALUES(@IdAnimal, @Name, @Type, @AdmissionDate , @IdOwner)";
                    com.Parameters.AddWithValue("IdAnimal", request.IdAnimal);
                    com.Parameters.AddWithValue("Name", request.Name);
                    com.Parameters.AddWithValue("Type", request.Type);
                    com.Parameters.AddWithValue("AdmissionDate", request.AdmissionDate);
                    com.Parameters.AddWithValue("IdOwner", request.IdOwner);

                    Console.WriteLine("Dodano zwierzaka do bazy"); //why to sie nie wyswitle ?

                    com.ExecuteNonQuery();
                    //tran.Commit();

                    com.CommandText = "select IdProcedure from Procesja where IdProcedure=@IdProcedure";
                    com.Parameters.AddWithValue("IdProcedure", request.IdProcedure);

                    var dr = com.ExecuteReader();

                    if (!dr.Read())
                    {
                        dr.Close();
                        //tran.Rollback();
                       
                    }
                    else
                    {
                        com.CommandText = "INSERT INTO Procedure_Animal(Procedure_IdProcedure, Animal_IdAnimal, Date) VALUES(@Procedure_IdProcedure,@Animal_IdAnimal,@Date)";
                        com.Parameters.AddWithValue("Procedure_IdProcedure", request.IdProcedure);
                        com.Parameters.AddWithValue("Animal_IdAnimal", request.IdAnimal);
                        com.Parameters.AddWithValue("Date", request.Date);
                        dr.Close();
                        com.ExecuteNonQuery();

                   
                    
                        
                    }
                    tran.Commit();
                    con.Close(); //dodane

                
               /* catch(SqlException exc)
                {
                    exc.ErrorCode.ToString();
                }*/
                //no i z tymi bledami to sie troche poddaje jest stabilnie ale no [*]

                return "zoba czy sie dodal";



            }

        }



    }
}
