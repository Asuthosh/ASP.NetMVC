﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_Album.Models
{
    /// <summary>
    /// User Class Corresponding to the API https://jsonplaceholder.typicode.com/Users
    /// </summary>
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }

    public class Geo
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }

}