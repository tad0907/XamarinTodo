using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinTodo.Domain.Models.Todos;
using XamarinTodo.Domain.Services;
using XamarinTodo.InMemory.Persistence.Todos;
using XamarinTodo.UseCase.UseCases.Todos;
using XamarinTodo.UseCase.UseCases.Todos.Save;

namespace XamarinTodo.UseCase.Test.Cases.Todos
{
    [TestClass]
    public class TodoTestCase
    {
        private ITodoFactory _todoFactory;
        private ITodoRepository _todoRepository;
        private TodoService _todoService;
        private TodoUseCase _todoUseCase;

        [TestInitialize]
        public void Initialize()
        {
            _todoFactory = new InMemoryTodoFactory();
            _todoRepository = new InMemoryTodoRepository();
            _todoService = new TodoService(_todoRepository);
            _todoUseCase = new TodoUseCase(_todoFactory, _todoRepository, _todoService);
        }

        [TestMethod]
        public void TestSuccessMinTodoTitle()
        {
            // 最短のユーザ名（３文字）のユーザが正常に生成できるか
            var title = "あいう";
            var deadline = DateTime.Now;
            var inputData = new TodoSaveCommand(title, deadline);
            var outputData = _todoUseCase.Save(inputData);
            Assert.IsNotNull(outputData.CreatedId);

            // ユーザが正しく保存されているか
            var createdTitle = new TodoTitle(title);
            var createdTodo = _todoRepository.Find(createdTitle);
            Assert.IsNotNull(createdTodo);
        }

        [TestMethod]
        public void TestSuccessMaxTodoTitle()
        {
            // 最短のユーザ名（２０文字）のユーザが正常に生成できるか
            var title = "あいうえおかきくけこさしすせそたちつてと";
            var deadline = DateTime.Now;
            var inputData = new TodoSaveCommand(title, deadline);
            var outputData = _todoUseCase.Save(inputData);
            Assert.IsNotNull(outputData.CreatedId);

            // ユーザが正しく保存されているか
            var createdTitle = new TodoTitle(title);
            var createdTodo = _todoRepository.Find(createdTitle);
            Assert.IsNotNull(createdTodo);
        }
    }
}
