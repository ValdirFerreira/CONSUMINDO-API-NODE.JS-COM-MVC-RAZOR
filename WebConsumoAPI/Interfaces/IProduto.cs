using WebConsumoAPI.Models;

namespace WebConsumoAPI.Interfaces
{
    public interface IProduto
    {

        List<Produto> List();

        Produto Create(Produto produto);

        Produto Update(Produto produto);

        Produto GetOne(int Codigo);

        Produto Delete(int Codigo);
    }
}
