using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestSonda.Models.ConnectionBD
{
    public class ConMySql
    {
        protected MySqlConnection Conn;
        public ConMySql() 
        {
            string conn_string = "server=localhost;port=3306;database=cloudtecnologias;username=root;password=$$123abc;";
            Conn = new MySqlConnection(conn_string);
        }
    }
}