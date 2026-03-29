using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace Proyecto.Tests.Test.API.Dtos
{
    public class DeleteDto
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public double price { get; set; }
        public string description { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;

        public Rating rating { get; set; } = new Rating();
    }

    public class Rating
    {
        public double rate { get; set; }
        public int count { get; set; }
    }
}
