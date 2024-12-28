using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoAPi.Interfaces;
using TodoAPi.Models;
using TodoAPI.AppDataContext;
using TodoAPI.Contracts;

namespace TodoAPI.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly TodoDbContext _context;
        private readonly ILogger<TodoServices> _logger;
        private readonly IMapper _mapper;

        public TodoServices(TodoDbContext context, ILogger<TodoServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateTodoAsync(CreateTodoRequestDTO request)
        {
            try
            {
                var todo = _mapper.Map<Todo>(request);
                todo.CreatedAt = DateTime.UtcNow;
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao criar o item Todo.");
                throw new Exception("Ocorreu um erro ao criar o item Todo.");
            }
        }
        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var todo = await _context.Todos.ToListAsync();
            if (todo == null)
            {
                throw new Exception("Nenhum item encontrado.");
            }
            return todo;
        }

        public Task DeleteTodoAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<Todo> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTodoAsync(Guid id, UpdateTodoRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}