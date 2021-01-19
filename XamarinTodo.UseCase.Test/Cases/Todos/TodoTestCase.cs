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
            var title1 = "1番目のタイトル";
            var deadline1 = DateTime.Now;
            var command1 = new TodoSaveCommand(title1, deadline1);

            var title2 = "2番目のタイトル";
            var deadline2 = DateTime.Now;
            var command2 = new TodoSaveCommand(title2, deadline2);

            var title3 = "3番目のタイトル";
            var deadline3 = DateTime.Now;
            var command3 = new TodoSaveCommand(title3, deadline3);
            try
            {
                _todoUseCase.Save(command1);
                _todoUseCase.Save(command2);
                _todoUseCase.Save(command3);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            var result = _todoUseCase.GetAll();

            Assert.AreEqual(title1, result.Todos[0].Title);
            Assert.AreEqual(deadline1, result.Todos[0].Deadline);

            Assert.AreEqual(title2, result.Todos[1].Title);
            Assert.AreEqual(deadline2, result.Todos[1].Deadline);

            Assert.AreEqual(title3, result.Todos[2].Title);
            Assert.AreEqual(deadline3, result.Todos[2].Deadline);
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
