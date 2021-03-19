using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestSonda.Models
{
    public class Entities
    {

        public class RequestLogin
        {
            public Header header { get; set; }
            public Data_RequestLogin data { get; set; }
        }
        public class RequestCreateUser
        {
            public Header header { get; set; }
            public Data_RequestCreateUser data { get; set; }
        }

        public class Header
        {
            public string invokeMethod { get; set; }
            public string channel { get; set; }
            public string operationSystem { get; set; }
            public string deviceModel { get; set; }
            public string applicationVersion { get; set; }
            public int osType { get; set; }
        }

        public class Data_RequestLogin
        {
            public Userlogin userlogin { get; set; }
        }
        public class Data_RequestCreateUser
        {
            public UserCreate user { get; set; }
        }
        public class UserCreate 
        {
            public string name { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string numberDoc { get; set; }
            public string password { get; set; }
        }
        public class Userlogin
        {
            public string email { get; set; }
            public string password { get; set; }
        }
        public class JsonResponse
        {
            public message msg { get; set; }
        }
        public class message
        {
            public string code { get; set; }
            public string msg { get; set; }
        }
    }
}