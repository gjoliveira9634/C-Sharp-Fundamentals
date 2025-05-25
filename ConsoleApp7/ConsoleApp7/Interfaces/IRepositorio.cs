namespace BibliotecaDigital.Interfaces
{
    public interface IRepositorio<T>
    {
        void Adicionar(T item);
        void Atualizar(T item);
        T? ObterPorId(string id);
        IEnumerable<T> ObterTodos();
        void RegistrarOperacao(string operacao);
    }
}