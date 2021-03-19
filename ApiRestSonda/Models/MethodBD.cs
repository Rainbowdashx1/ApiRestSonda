using ApiRestSonda.Models.ConnectionBD;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ApiRestSonda.Models.Entities;

namespace ApiRestSonda.Models
{
    public class MethodBD : ConMySql
    {
        string SqlValidateUser;
        string SqlCreateUser;
        string SqlCreateUserDocument;
        string SqlCreateUserEmail;
        public MethodBD(RequestLogin RL) 
        {
            SqlValidateUser = string.Format("Select * from cli_client where email = '{0}' and password = '{1}'", RL.data.userlogin.email, RL.data.userlogin.password);
        }
        public MethodBD(RequestCreateUser RCU)
        {
            SqlCreateUser = string.Format("insert into cli_client(code,password,name,lastname,email) select '{0}','{1}','{2}','{3}','{4}'", RCU.data.user.numberDoc, RCU.data.user.password, RCU.data.user.name, RCU.data.user.lastName, RCU.data.user.email);
            SqlCreateUserDocument = string.Format("Select * from cli_client where email = '{0}'",RCU.data.user.email);
            SqlCreateUserEmail = string.Format("Select * from cli_client where code = '{0}'", RCU.data.user.numberDoc);
        }

        public JsonResponse ValidateLogin() 
        {
            try
            {
                MySqlCommand conmmand = Conn.CreateCommand();
                conmmand.CommandText = SqlValidateUser;
                Conn.Open();

                MySqlDataReader reader = conmmand.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    return new JsonResponse() { msg = new message() { msg = "login success", code = "200" } };
                }
                else
                {
                    return new JsonResponse() { msg = new message() { msg = "Email or password is incorrect", code = "401" } };
                }
            }
            catch (Exception ex) 
            {
                return new JsonResponse() { msg = new message() { msg = "Error server", code = "500" } };
            }
        }

        public JsonResponse CreateUser()
        {
            try
            {
                int Result = ValidateCreateUser();
                switch (Result) 
                {
                    case 1:
                        return new JsonResponse() { msg = new message() { msg = "Number document already exists!", code = "409" } };
                    case 2:
                        return new JsonResponse() { msg = new message() { msg = "Email already exists!", code = "409" } };
                    case 3:
                        return new JsonResponse() { msg = new message() { msg = "Create usr success", code = "200" } };
                    default:
                        return new JsonResponse() { msg = new message() { msg = "Error server", code = "500" } };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse() { msg = new message() { msg = "Error server", code = "500" } };
            }
        }

        public int ValidateCreateUser() 
        {
            try
            {
                MySqlCommand conmmand0 = Conn.CreateCommand();
                conmmand0.CommandText = SqlCreateUserDocument;
                Conn.Open();
                MySqlDataReader reader0 = conmmand0.ExecuteReader();
                reader0.Read();

                if (reader0.HasRows)
                {
                    return 1;
                }
                Conn.Close();

                MySqlCommand conmmand1 = Conn.CreateCommand();
                conmmand1.CommandText = SqlCreateUserEmail;
                Conn.Open();
                MySqlDataReader reader1 = conmmand1.ExecuteReader();
                reader1.Read();

                if (reader1.HasRows)
                {
                    return 2;
                }
                Conn.Close();

                MySqlCommand conmmand2 = Conn.CreateCommand();
                conmmand2.CommandText = SqlCreateUser;
                Conn.Open();
                MySqlDataReader reader2 = conmmand2.ExecuteReader();
                return 3;

            }
            catch (Exception ex) 
            {
                return 0;
            }
        }

    }
}