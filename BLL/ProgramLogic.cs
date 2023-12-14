using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Collections;

namespace BLL
{
    public class ProgramLogic
    {
        private readonly string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=DBCourseEnd;";
        DataAccessLayer _layer;
        public ProgramLogic() 
        {
            _layer=new DataAccessLayer(connectionString);
        }
        public void SearchSubscriber(string typesearch,string data)
        {
            if(typesearch=="firstname")
            {
                string query = "SELECT * FROM Subscribers WHERE First_Name = @FirstName";
                SqlParameter[] parameters = {
                    new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if(typesearch == "lastname")
            {
                string query = "SELECT * FROM Subscribers WHERE Last_Name = @LastName";
                SqlParameter[] parameters = {
                    new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if (typesearch == "town")
            {
                string query = "SELECT * FROM Subscribers WHERE Town = @Town";
                SqlParameter[] parameters = {
                    new SqlParameter("@Town", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if (typesearch == "postmen")
            {
                string query = "SELECT DISTINCT Subscribers.* FROM Subscribers JOIN Subscriptions ON Subscribers.Mailbox = Subscriptions.MailBox " +
                    "JOIN Postmens ON Subscriptions.Postmen = Postmens.Postmen_ID WHERE Postmens.Last_Name = @LastName ";
                SqlParameter[] parameters = {
                    new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if (typesearch == "magazine")
            {
                string query = "SELECT Subscribers.* FROM Subscribers JOIN Subscriptions ON Subscribers.Mailbox = Subscriptions.MailBox " +
                    "JOIN Magazines ON Subscriptions.Magazine = Magazines.Magazine_ID WHERE Magazines.Magazine_Name = @Magazine_Name; ";
                SqlParameter[] parameters = {
                    new SqlParameter("@Magazine_Name", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if (typesearch == "mailbox")
            {
                string query = "SELECT Subscribers.* FROM Subscribers WHERE Subscribers.Mailbox IS NOT NULL ORDER BY Last_Name ASC; ";
                DataTable dataTable = _layer.ExecuteQuery(query);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if (typesearch == "premium")
            {
                string query = "SELECT Subscribers.* FROM Subscribers JOIN PremiumSubscriber ON Subscribers.Subscriber_ID = PremiumSubscriber.Subscriber; ";
                DataTable dataTable = _layer.ExecuteQuery(query);
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            if(typesearch == "task1")
            {
                string query = "SELECT Subscribers.* FROM Subscribers JOIN PremiumSubscriber ON Subscribers.Subscriber_ID = PremiumSubscriber.Subscriber " +
                    "JOIN Subscriptions ON Subscribers.Mailbox = Subscriptions.MailBox JOIN Postmens ON Subscriptions.Postmen = Postmens.Postmen_ID " +
                    "JOIN Departments ON Postmens.Department = Departments.Department_ID WHERE Departments.Department_Address = @Street; ";
                SqlParameter[] parameters = {
                    new SqlParameter("@Street", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                if (dataTable.Rows.Count == 0)
                    Console.WriteLine("No found");
                else
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            Console.Write($"{col.ColumnName}: {row[col]} ");
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                }
            }
            if (typesearch == "task2")
            {
                string query = "SELECT Magazines.Magazine_Type, COUNT(Subscribers.Subscriber_ID) AS Subscriber_Count FROM Subscriptions " +
                    "JOIN Magazines ON Subscriptions.Magazine = Magazines.Magazine_ID JOIN Subscribers ON Subscriptions.MailBox = Subscribers.Mailbox " +
                    "GROUP BY Magazines.Magazine_Type; ";
                DataTable dataTable = _layer.ExecuteQuery(query);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
        }
        public void SearchSubscriberComplex(string typesearch, List<string> data)
        {
            if (typesearch == "address")
            {
                string query = "SELECT Subscribers.* FROM Subscribers WHERE Subscribers.Street = @Street AND Subscribers.House_Num = @House " +
                    "AND Subscribers.Flat_Num = @Flat; ";
                SqlParameter[] parameters = {
                    new SqlParameter("@Street", SqlDbType.NVarChar) { Value = data[0] },
                    new SqlParameter("@House", SqlDbType.NVarChar) { Value = data[1] },
                    new SqlParameter("@Flat", SqlDbType.NVarChar) { Value = data[2] }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if (typesearch == "fullname")
            {
                string query = "SELECT * FROM Subscribers WHERE First_Name = @FirstName AND Last_Name = @LastName ";
                SqlParameter[] parameters = {
                    new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = data[0] },
                    new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = data[1] }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
        }
        public void SearchPostmen(string typesearch, string data)
        {
            if (typesearch == "firstname")
            {
                string query = "SELECT * FROM Postmens WHERE First_Name = @FirstName";
                SqlParameter[] parameters = {
                    new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if (typesearch == "lastname")
            {
                string query = "SELECT * FROM Postmens WHERE Last_Name = @LastName";
                SqlParameter[] parameters = {
                    new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            if (typesearch == "depart")
            {
                string query = "SELECT * FROM Postmens WHERE Department IN (SELECT Department_ID FROM Departments WHERE Department_Num = @Department)";
                SqlParameter[] parameters = {
                    new SqlParameter("@Department", SqlDbType.NVarChar) { Value = data }
                };
                DataTable dataTable = _layer.ExecuteParameterizedQuery(query, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.Write($"{col.ColumnName}: {row[col]} ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
        }
        public void ShowAllEntities(string entity)
        {
            string table = entity;
            DataTable dataTable = _layer.ExecuteQuery($"SELECT * FROM {table}");
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write($"{col.ColumnName}: {row[col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
