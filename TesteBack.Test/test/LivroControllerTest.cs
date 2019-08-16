
using TesteBack.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using TesteBack.Model.Model;
using TesteBack.WebAPI.Controllers;

namespace TesteBack.Test.test
{
    public class LivroControllerTest
    {
        #region property
        private Livro livormock; 
        #endregion

        #region testMetods
        [Fact]
        public void TesteGetAll()
        {

            var mockRepo = new Mock<ILivroRepository>();

            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestLivros());

            var controller = new LivroController(mockRepo.Object);

            var result = controller.Get();

            var items = Assert.IsType<List<Livro>>(GetTestLivros());

            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void TesteGet()
        {

            var mockRepo = new Mock<ILivroRepository>();

            livormock = GetByIdMok();

            mockRepo.Setup(repo => repo.GetById(livormock.Id))
                .ReturnsAsync(GetByIdMok());


            var controller = new LivroController(mockRepo.Object);

            var result = controller.Get(livormock.Id).Result as OkObjectResult;

            Assert.IsType<Livro>(result.Value);
            Assert.Equal(livormock.Id, (result.Value as Livro).Id);
        }

        [Fact]
        public void TestePost()
        {

            var mockRepo = new Mock<ILivroRepository>();

            livormock = GetByIdMok();

            mockRepo.Setup(repo => repo.Create(livormock));


            var controller = new LivroController(mockRepo.Object);

            var result = controller.Post(livormock);
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void TesteDelete()
        {

            var mockRepo = new Mock<ILivroRepository>();

            livormock = GetByIdMok();

            mockRepo.Setup(repo => repo.Delete(livormock.Id));

            var controller = new LivroController(mockRepo.Object);

            var result = controller.Delete(livormock.Id);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void TestePut()
        {

            var mockRepo = new Mock<ILivroRepository>();

            livormock = GetByIdMok();

            mockRepo.Setup(repo => repo.Create(livormock));

            var controller = new LivroController(mockRepo.Object);

            var result = controller.Post(livormock);
            Assert.IsType<Task<IActionResult>>(result);

            mockRepo.Setup(repo => repo.Update(livormock.Id, livormock));

            controller = new LivroController(mockRepo.Object);

            livormock.Titulo = "alterado";

            result = controller.Put(livormock.Id, livormock);
            Assert.IsType<Task<IActionResult>>(result);

        }

        #endregion

        #region mock
        private Livro GetByIdMok()
        {
            return new Livro()
            {
                Titulo = "TesteTituloMock1",
                Autor = "TesteAutorMock",
                Id = 1,
                Genero = "XXXX",
                Editora = "TesteEditoraMock",
                DataPublicacao = DateTime.Now
            };
        }


        private List<Livro> GetTestLivros()
        {
            var livros = new List<Livro>()
            {
                new Livro()
                {
                    Titulo = "TesteTituloMock1",
                Autor = "TesteAutorMock",
                Id = 1,
                Genero = "XXXX",
                Editora = "TesteEditoraMock",
                DataPublicacao = DateTime.Now
                }
             ,
              new Livro()
              {
                  Titulo = "TesteTituloMock2",
                  Autor = "TesteAutorMock",
                  Id = 2,
                  Genero = "XXXX",
                  Editora = "TesteEditoraMock",
                  DataPublicacao = DateTime.Now

              }
            };


            return livros;
        } 
        #endregion

    }
}
