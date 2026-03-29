using System;
using RestSharp;
using System.Net;
using System.Text.Json;
using NUnit.Framework;
using proyecto.Tests.Test.API.Dtos;

namespace Proyecto.Tests.Test.API
{
    public class ApiTest
    {
        private const string BaseUrl = "https://fakestoreapi.com";

        private static RestClient CreateClient() => new(BaseUrl);

        private static RestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            return request;
        }

        [Test]
        public async Task PruebaGET()
        {
            var client = CreateClient();
            var request = CreateRequest("/products/9", Method.Get);

            var response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            // Deserializar el JSON a tu clase
            var Productget = JsonSerializer.Deserialize<GetDto>(
                response.Content!,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Validaciones con Assert.That

            Assert.That(Productget.id, Is.EqualTo(9));
            Assert.That(Productget.title, Does.Contain("WD 2TB Elements"));
            Assert.That(Productget.price, Is.EqualTo(64));
            Assert.That(Productget.category, Is.EqualTo("electronics"));
            Assert.That(Productget.rating.rate, Is.EqualTo(3.3).Within(0.01));
            Assert.That(Productget.rating.count, Is.GreaterThan(200));


        }

        [Test]
        public async Task PruebaPost()
        {

            var client = CreateClient();
            var request = CreateRequest("/products", Method.Post);
          
            // Datos de entrada
            var newProduct = new PostDto
            {
                id = 22,
                title = "Repuesto",
                price = 100.1,
                description = "Motor",
                category = "Vehiculo",
                image = "prueba"
            };

            // Agregar el body en formato JSON
            request.AddJsonBody(newProduct);

            // Ejecutar la petición
            var response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));



            // Deserializar el JSON a tu clase
            var Post = JsonSerializer.Deserialize<GetDto>(
        response.Content!,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            // Validaciones con Assert.That
           
            Assert.That(Post.id, Is.EqualTo(21));
            Assert.That(Post.title, Is.EqualTo("Repuesto"));
            Assert.That(Post.price, Is.EqualTo(100.1));
            Assert.That(Post.description, Is.EqualTo("Motor"));
            Assert.That(Post.category, Is.EqualTo("Vehiculo"));
            Assert.That(Post.image, Is.EqualTo("prueba"));
        }
        [Test]
        public async Task PruebaPut()
        {

            var client = CreateClient();
            var request = CreateRequest("/products/9", Method.Put);

            // Datos de entrada
            var newProduct = new PutDto
            {
                id = 10,
                title = "Repuesto1",
                price = 1300.1,
                description = "caja",
                category = "Vehiculo",
                image = "prueba"
            };

            // Agregar el body en formato JSON
            request.AddJsonBody(newProduct);

            // Ejecutar la petición
            var response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


            // Deserializar el JSON a tu clase
            var put = JsonSerializer.Deserialize<GetDto>(
        response.Content!,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Validaciones con Assert.That

            Assert.That(put.id, Is.EqualTo(9));
            Assert.That(put.title, Is.EqualTo("Repuesto1"));
            Assert.That(put.price, Is.EqualTo(1300.1));
            Assert.That(put.description, Is.EqualTo("caja"));
            Assert.That(put.category, Is.EqualTo("Vehiculo"));
            Assert.That(put.image, Is.EqualTo("prueba"));
        }
        [Test]
        public async Task PruebaDelete()
        {


            var client = CreateClient();
            var request = CreateRequest("/products/9", Method.Delete);

            var response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            // Deserializar el JSON a tu clase
            var Productdelete = JsonSerializer.Deserialize<GetDto>(
                response.Content!,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Validaciones con Assert.That

            Assert.That(Productdelete.id, Is.EqualTo(9));
            Assert.That(Productdelete.title, Does.Contain("WD 2TB Elements"));
            Assert.That(Productdelete.price, Is.EqualTo(64));
            Assert.That(Productdelete.category, Is.EqualTo("electronics"));
            Assert.That(Productdelete.rating.rate, Is.EqualTo(3.3).Within(0.01));
            Assert.That(Productdelete.rating.count, Is.GreaterThan(200));

        }

    }




}
