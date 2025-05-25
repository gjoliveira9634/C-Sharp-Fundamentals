namespace BibliotecaDigital.Interfaces
{
    public interface IIdentificavel
    {
        string Id { get; }
        string ObterDetalhes();
    }
}