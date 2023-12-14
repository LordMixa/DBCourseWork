using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace DBCourseWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programLogic=new ProgramLogic();
            Menu menu=new Menu();
        }
    }
}