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
        public void Todo全件取得()
        {
            var title = "タイトル";
            var deadline = new DateTime(2021,12,31);
            var count = 3;
            try
            {
                for (var i = 0; i < count; i++)
                {
                    var command = new TodoSaveCommand(title, deadline);
                    _todoUseCase.Save(command);
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            var result = _todoUseCase.GetAll();

            Assert.AreEqual(count, result.Todos.Count);

            foreach(var todo in result.Todos)
            {
                Assert.AreEqual(title, todo.Title);
                Assert.AreEqual(deadline, todo.Deadline);
                Assert.AreEqual(false, todo.IsCompleted);
            }
        }

        [TestMethod]
        public void Todoタイトル_未入力()
        {
            bool exceptionOccured = false;
            try
            {
                var deadline = DateTime.Now;
                var command = new TodoSaveCommand(null, deadline);
                _todoUseCase.Save(command);
            }
            catch (Exception e)
            {
                Assert.AreEqual("タイトルを入力してください。", e.Message);
                exceptionOccured = true;
            }

            Assert.IsTrue(exceptionOccured);
        }

        [TestMethod]
        public void Todoタイトル_最大桁_20_入力()
        {
            var title = "あいうえおかきくけこさしすせそたちつてと";
            var deadline = DateTime.Now;
            var command = new TodoSaveCommand(title, deadline);
            var result = _todoUseCase.Save(command);
            Assert.IsNotNull(result.CreatedId);

            // ユーザが正しく保存されているか
            var createdTitle = new TodoTitle(title);
            var createdTodo = _todoRepository.Find(createdTitle);
            Assert.IsNotNull(createdTodo);
        }

        [TestMethod]
        public void Todoタイトル_最大桁_20_超過入力()
        {
            bool exceptionOccured = false;
            try
            {
                var title = "あいうえおかきくけこさしすせそたちつてとな";
                var deadline = DateTime.Now;
                var command = new TodoSaveCommand(title, deadline);
                _todoUseCase.Save(command);
            }
            catch(Exception e)
            {
                Assert.AreEqual("タイトルを20文字以内で入力してください。", e.Message);
                exceptionOccured = true;
            }

            Assert.IsTrue(exceptionOccured);
        }
    }
}
